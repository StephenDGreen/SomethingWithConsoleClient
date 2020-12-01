using Microsoft.Extensions.DependencyInjection;
using System;

namespace Something.UI
{
    class Program
    {
        public static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddHttpClient<ISomethingService, SomethingService>();
            var provider = services.BuildServiceProvider();
            var somethingService = provider.GetService<ISomethingService>();
            try
            {
                Console.WriteLine(somethingService.Run(args));
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
