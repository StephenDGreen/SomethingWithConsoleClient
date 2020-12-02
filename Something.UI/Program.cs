using Microsoft.Extensions.DependencyInjection;
using Something.UI.Services;
using System;
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
            services.AddSingleton<IHandler, ArgumentAHandler>();
            var provider = services.BuildServiceProvider();
            var somethingService = provider.GetService<ISomethingService>();
            var securityService = provider.GetService<ISecurityService>();
            try
            {
                securityService.GetHeader();
                somethingService.Run(args, securityService.SecurityHeader);
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
