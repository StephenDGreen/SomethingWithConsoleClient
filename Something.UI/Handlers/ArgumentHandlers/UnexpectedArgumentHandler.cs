using Something.UI.Models;
using System;


namespace Something.UI.Handlers.ArgumentHandlers
{
    public class UnexpectedArgumentHandler : ArgumentHandler
    {
        public override void Handle(string[] args, Token token)
        {
            Console.WriteLine("Options:");
            Console.WriteLine("\t/a - Get SomethingElse Listing");
            Console.WriteLine("\t/d - Create and Get SomethingElse Dummy Data");
            Console.Write("\nPress any key to exit...");
            Console.ReadKey(true);
        }
    }
}
