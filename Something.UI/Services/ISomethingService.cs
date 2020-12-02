using Something.Domain.Models;
using Something.UI.Models;
using System.Threading.Tasks;

namespace Something.UI
{
    public interface ISomethingService
    {
        SomethingElse[] SomethingElses { get; }

        void Run(string[] args, Token token);
    }
}