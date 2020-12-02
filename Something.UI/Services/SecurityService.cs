using Something.UI.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Something.UI.Services
{
    public class SecurityService : ISecurityService
    {
        public SecurityService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private readonly HttpClient _httpClient;

        public Token SecurityHeader { get; private set; }

        public async Task GetHeader()
        {
            string requestEndpoint = @"/home/authenticate";
            try
            {
                HttpResponseMessage response = _httpClient.GetAsync(requestEndpoint).Result;
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                SecurityHeader = JsonSerializer.Deserialize<Token>(responseBody);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString() + _httpClient.BaseAddress + requestEndpoint);
            }
        }
    }
}
