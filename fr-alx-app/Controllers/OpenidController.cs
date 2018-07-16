using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FRAlexaApp.Services;
using FRAlexaApp.Services.Clients;
using FRAlexaApp.Services.Config;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static FRAlexaApp.Services.Config.Lookup;

namespace FRAlexaApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenidController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly OpenBankingClient _client;

        public OpenidController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _client = DetermineClient(Request);
        }

        private OpenBankingClient DetermineClient(HttpRequest request)
        {
            // How do we find out the client from the request?
            // Well-knowns - ??
            // Authorize  - query parameters will contain the client-id
            // Token - body will contain the client-id (or from the authorize header)
            // UserInfo - ??

            SupportedClients x = SupportedClients.FR;
            HttpClient c;
            switch (x)
            {
                case SupportedClients.DB:
                    c =_httpClientFactory.CreateClient("DBClient");
                    break;
                case SupportedClients.FR:
                    c = _httpClientFactory.CreateClient("FRClient");
                    break;
                default:
                    c = _httpClientFactory.CreateClient("FRClient");
                    break;
            }

            return new OpenBankingClient(c, new LoggerFactory().CreateLogger<OpenBankingClient>());
        }

        [HttpGet]
        [Route(".well-known/openid-configuration")]
        public async Task<HttpResponseMessage> GetOpenIdConfig() => await new OpenidService().OpenIdConfig(_client);

        [HttpGet]
        [Route(".well-known/openid-configuration/jwks")]
        public async Task<HttpResponseMessage> GetOpenIdConfigJwks() => await new OpenidService().OpenIdConfigJwks(_client);

        // Here we should just redirect after adding request-jwt
        [HttpGet]
        [Consumes("application/x-www-form-urlencoded")]
        [Route("authorize")]
        public async Task<HttpResponseMessage> Authorize([FromQuery] Dictionary<string, string> query) => await new OpenidService().AuthorizeAsync(_client, query);

        // token end-point should support both client-credentials for account-request and auth code for PSU signin
        [HttpPost]
        [Consumes("application/x-www-form-urlencoded")]
        [Route("token")]
        public async Task<HttpResponseMessage> Token([FromHeader] string authorizeHeader, [FromBody] Dictionary<string, string> body) => await new OpenidService().TokenAsync(_client, authorizeHeader, body);

        // do we need to implement this?
        [HttpGet]
        [Consumes("application/x-www-form-urlencoded")]
        [Route("userinfo")]
        public async Task<HttpResponseMessage> UserInfo([FromHeader] string accessToken, [FromBody] Dictionary<string, string> body) => await new OpenidService().UserInfoAsync(_client, accessToken);
    }
}
