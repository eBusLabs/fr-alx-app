using FRAlexaApp.Services.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FRAlexaApp.Services
{
    public class OpenidService
    {
        internal Task<HttpResponseMessage> OpenIdConfig(OpenBankingClient client)
        {
            throw new NotImplementedException();
        }

        internal Task<HttpResponseMessage> OpenIdConfigJwks(OpenBankingClient client)
        {
            throw new NotImplementedException();
        }

        internal async Task<HttpResponseMessage> TokenAsync(OpenBankingClient client, string authorizeHeader, Dictionary<string, string> body)
        {
            await client.CreateToken();
            throw new NotImplementedException();
        }

        internal async Task<HttpResponseMessage> UserInfoAsync(OpenBankingClient client, string accessToken)
        {
            await client.GetUserInfo();
            throw new NotImplementedException();
        }

        internal async Task<HttpResponseMessage> AuthorizeAsync(OpenBankingClient client, Dictionary<string, string> queryParameters)
        {
            await client.CreateAccountRequest();

            throw new NotImplementedException();
        }
    }
}
