using Something.UI.Models;

namespace Something.UI
{
    public interface IHandler
    {
        IHandler SetNext(IHandler next);
        void Handle(string[] args, Token token);
    }
}
