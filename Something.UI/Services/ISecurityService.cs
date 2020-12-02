using Something.UI.Models;
using System.Threading.Tasks;

namespace Something.UI.Services
{
    public interface ISecurityService
    {
        Token SecurityHeader { get; }

        Task GetHeader();
    }
}