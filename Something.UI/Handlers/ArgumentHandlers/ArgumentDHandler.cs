using ConsoleTables;
using Something.Domain.Models;
using Something.UI.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace Something.UI.Handlers.ArgumentHandlers
{
    public class ArgumentDHandler : ArgumentHandler
    {
        public ArgumentDHandler(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private readonly HttpClient _httpClient;

        private readonly Random _random = new Random();

        public override void Handle(string[] args, Token token)
        {
            foreach (string cmd in args)
            {
                if (cmd.StartsWith("/") && cmd.Substring(1) == "d") 
                {

                    string requestEndpoint = @"/api/things";
                    try
                    {
                        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.access_token);
                        var value = new Dictionary<string, string>
                            {
                                { "Name", RandomString(RandomNumber(10,20),true) }
                            };

                        var content = new FormUrlEncodedContent(value);
                        var response = _httpClient.PostAsync(requestEndpoint, content).Result;
                        Domain.Models.Something[] Somethings = response.Content.ReadFromJsonAsync<Something.Domain.Models.Something[]>().Result;
                        ConsoleTable
                            .From<Something.Domain.Models.Something>(Somethings)
                            .Configure(o => o.NumberAlignment = Alignment.Right)
                            .Write(Format.MarkDown);
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

        private int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        private string RandomString(int size, bool lowerCase = false)
        {
            var builder = new StringBuilder(size);

            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26;

            for (var i = 0; i < size; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }
    }
}
