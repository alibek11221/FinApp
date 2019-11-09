using FinAppDataManger.Library.DataAccess;
using FinAppDataManger.Library.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
            return user.GetUserById(id);
        }
    }
}
