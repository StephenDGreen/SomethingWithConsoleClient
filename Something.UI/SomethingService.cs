using ConsoleTables;
using Serilog;
using Something.Application;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Something.UI
{
    public class SomethingService : ISomethingService
    {
        public SomethingService(ILogger logger)
        {
            Logger = logger;
        }

        public ILogger Logger { get; }

        public async Task Run()
        {
            Console.ReadKey();
        }
    }
}
