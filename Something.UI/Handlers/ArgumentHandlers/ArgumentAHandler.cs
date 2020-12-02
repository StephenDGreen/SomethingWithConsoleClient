using ConsoleTables;
using Something.Domain.Models;
using Something.UI.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Something.UI
{
    public class ArgumentAHandler : ArgumentHandler
    {
        public ArgumentAHandler(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public SomethingElse[] SomethingElses { get; private set; }

        private readonly HttpClient _httpClient;

        public override void Handle(string[] args, Token token)
        {
            foreach (string cmd in args)
            {
                if (cmd.StartsWith("/") && cmd.Substring(1) == "a") 
                {
                    string requestEndpoint = "/api/thingselse";
                    try
                    {
                        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.access_token);
                        SomethingElses = _httpClient.GetFromJsonAsync<SomethingElse[]>(requestEndpoint).Result;
                        if (!(SomethingElses is null))
                        {
                            foreach (var item in SomethingElses)
                            {
                                Console.WriteLine(@"# {0}", item.Name);
                                Console.WriteLine("");
                                ConsoleTable
                                    .From<Something.Domain.Models.Something>(item.Somethings)
                                    .Configure(o => o.NumberAlignment = Alignment.Right)
                                    .Write(Format.MarkDown);
                            }
                            Console.ReadKey();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString() + _httpClient.BaseAddress + requestEndpoint);
                    }
                } 
                else
                    { base.Handle(args,token); }
            }
        }
    }
}
