using FRAlexaApp.Services.Helpers;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FRAlexaApp.Services.Clients
{
    public class OpenBankingClient : IOpenBankingClient
    {
        private HttpClient _client;
        private ILogger<OpenBankingClient> _logger;
        private ContentHelper _content;

        public OpenBankingClient(HttpClient client, ILogger<OpenBankingClient> logger)
        {
            _client = client;
            _logger = logger;
            _content = new ContentHelper();
        }

        public async Task<string> CreateAccountRequest()
        {
            try
            {
                var response = await _client.PostAsync("account-requests", _content.CreateAccountRequestContent());
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<string>();
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError($"An error occured connecting to account-request endpoint {ex.ToString()}");
                return String.Empty;
            }
        }

        public async Task<string> GetUserInfo()
        {
            try
            {
                var response = await _client.PostAsync("userinfo", _content.CreateAccountRequestContent());
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<string>();
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError($"An error occured connecting to account-request endpoint {ex.ToString()}");
                return String.Empty;
            }
        }

        public async Task<string> CreateToken()
        {
            try
            {
                var response = await _client.PostAsync("token", _content.CreateTokenContent());
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<string>();
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError($"An error occured connecting to token endpoint {ex.ToString()}");
                return String.Empty;
            }
        }

    }
}
