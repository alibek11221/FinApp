using FinAppDataManger.Library.DataAccess;
using FinAppDataManger.Library.Models;
using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace FinAppApi.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
        [HttpGet]
        public UserModel GetById()
        {
            string id = RequestContext.Principal.Identity.GetUserId();
            UserData user = new UserData();
            return user.GetUserData(id);
        }
    }
}
