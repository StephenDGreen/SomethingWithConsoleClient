using System;
using System.Net.Http;
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
        public string ResponseBody { get; private set; }

        public async Task Run(string[] args)
        {
            string requestEndpoint = string.Empty;
            ResponseBody = string.Empty;
            foreach (string cmd in args)
            {
                if (cmd.StartsWith("/"))
                {
                    switch (cmd.Substring(1))
                    {
                        case "a":
                            requestEndpoint = "";
                            break;
                        default:
                            break;
                    }
                }
            }
            if (requestEndpoint == "") return;
            try
            {
                HttpResponseMessage response = _httpClient.GetAsync(requestEndpoint).Result;
                response.EnsureSuccessStatusCode();
                ResponseBody = await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString() + _httpClient.BaseAddress + requestEndpoint);
            }
        }
    }
}
