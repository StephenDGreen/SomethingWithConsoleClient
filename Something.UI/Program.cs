using ConsoleTables;
using Microsoft.Extensions.DependencyInjection;
using Something.Domain.Models;
using Something.UI.Services;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace Something.UI
{
    class Program
    {
        public static void Main(string[] args)
        {
            var services = new ServiceCollection();
            var baseUrl = @"https://localhost:44380/";
            var baseUri = new Uri(baseUrl);
            services.AddHttpClient<ISomethingService, SomethingService>(client =>
            {
                client.BaseAddress = baseUri;
                client.DefaultRequestHeaders
                    .Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });
            services.AddHttpClient<ISecurityService, SecurityService>(client =>
            {
                client.BaseAddress = baseUri;
            });
            var provider = services.BuildServiceProvider();
            var somethingService = provider.GetService<ISomethingService>();
            var securityService = provider.GetService<ISecurityService>();
            try
            {
                securityService.GetHeader();
                somethingService.Run(args, securityService.SecurityHeader);
                var somethingElseList = somethingService.SomethingElses;
                if (!(somethingElseList is null))
                {
                    foreach (var item in somethingElseList)
                    {
                        Console.WriteLine(@"# {0}", item.Name);
                        Console.WriteLine("");
                        ConsoleTable
                            .From<Something.Domain.Models.Something>(item.Somethings)
                            .Configure(o => o.NumberAlignment = Alignment.Right)
                            .Write(Format.MarkDown);
                    }
                }

                Console.ReadKey();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }
    }
}
