using System.Threading.Tasks;
using FinAppUi.Library.Models;

namespace FinAppUi.Library.Api
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string userName, string password);
    }
}