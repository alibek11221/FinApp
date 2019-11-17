using FinAppUi.Library.Models;
using System.Threading.Tasks;

namespace FinAppUi.Library.Api
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string userName, string password);
        Task GetLoggedInUserInfo(string token);
    }
}