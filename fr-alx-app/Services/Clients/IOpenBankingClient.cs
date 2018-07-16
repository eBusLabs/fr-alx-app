using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FRAlexaApp.Services.Clients
{
    interface IOpenBankingClient
    {
        Task<string> CreateAccountRequest();

        Task<string> CreateToken();

        Task<string> GetUserInfo();
    }
}
