using Something.UI.Models;
using System;


namespace Something.UI.Handlers.ArgumentHandlers
{
    public class UnexpectedArgumentHandler : ArgumentHandler
    {
        public override void Handle(string[] args, Token token)
        {
            Console.WriteLine("Options:");
            Console.WriteLine("\t/a - Get Something-Else Listing");
            Console.Write("\nPress any key to exit...");
            Console.ReadKey(true);
        }
    }
}
