using Something.Domain.Models;
using Something.UI.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Something.UI
{
    public class SomethingService : ISomethingService
    {
        public SomethingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private readonly HttpClient _httpClient;
        public SomethingElse[] SomethingElses { get; private set; }

        public void Run(string[] args, Token token)
        {
            string requestEndpoint = string.Empty;
            foreach (string cmd in args)
            {
                if (cmd.StartsWith("/"))
                {
                    switch (cmd.Substring(1))
                    {
                        case "a":
                            requestEndpoint = "/api/thingselse";
                            break;
                        default:
                            break;
                    }
                }
            }
            if (requestEndpoint == "") return;
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.access_token);
                SomethingElses = _httpClient.GetFromJsonAsync<SomethingElse[]>(requestEndpoint).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString() + _httpClient.BaseAddress + requestEndpoint);
            }
        }
    }
}
