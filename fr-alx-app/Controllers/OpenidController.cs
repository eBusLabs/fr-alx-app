using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FRAlexaApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FRAlexaApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenidController : ControllerBase
    {

        [HttpGet]
        [Route(".well-known/openid-configuration")]
        public async Task<HttpResponseMessage> GetOpenIdConfig() => await new OpenidService().GetOpenIdConfig();

        [HttpGet]
        [Route(".well-known/openid-configuration/jwks")]
        public async Task<HttpResponseMessage> GetOpenIdConfigJwks() => await new OpenidService().GetOpenIdConfigJwks();

        // Here we should just redirect
        [HttpPost]
        [Consumes("application/x-www-form-urlencoded")]
        [Route("authorize")]
        public async Task<HttpResponseMessage> Authorize([FromHeader] HttpHeaders headers, [FromBody] Dictionary<string, string> body) => await new OpenidService().Authorize();

        // token end-point should support both client-credentials for account-request and auth code for PSU signin
        [HttpPost]
        [Consumes("application/x-www-form-urlencoded")]
        [Route("token")]
        public async Task<HttpResponseMessage> Token([FromHeader] HttpHeaders headers, [FromBody] Dictionary<string, string> body) => await new OpenidService().CreateAuthToken();

        [HttpGet]
        [Consumes("application/x-www-form-urlencoded")]
        [Route("userinfo")]
        public async Task<HttpResponseMessage> UserInfo([FromHeader] HttpHeaders headers, [FromBody] Dictionary<string, string> body) => await new OpenidService().GetUserInfo();

    }
}
