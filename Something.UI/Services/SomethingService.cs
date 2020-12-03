using Something.Domain.Models;
using Something.UI.Handlers.ArgumentHandlers;
using Something.UI.Models;
using System.Net.Http;

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
            var handler = new ArgumentAHandler(_httpClient);
            handler.SetNext(new ArgumentDHandler(_httpClient))
                .SetNext(new UnexpectedArgumentHandler());

            handler.Handle(args, token);
        }
    }
}
