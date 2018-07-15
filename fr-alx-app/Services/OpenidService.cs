using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FRAlexaApp.Services
{
    public class OpenidService
    {
        internal Task<HttpResponseMessage> GetOpenIdConfig()
        {
            throw new NotImplementedException();
        }

        internal Task<HttpResponseMessage> GetOpenIdConfigJwks()
        {
            throw new NotImplementedException();
        }

        internal Task<HttpResponseMessage> CreateAuthToken()
        {
            throw new NotImplementedException();
        }

        internal Task<HttpResponseMessage> GetUserInfo()
        {
            throw new NotImplementedException();
        }

        internal Task<HttpResponseMessage> Authorize()
        {
            throw new NotImplementedException();
        }
    }
}
