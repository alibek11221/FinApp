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
        public IUserModel GetById()
        {
            string id = RequestContext.Principal.Identity.GetUserId();
            DapperUserData user = new DapperUserData();
            return user.GetUserById(id);
        }
        [HttpPost]
        public void PopulateInfoAboutUser(string firstName, string lastName)
        {
            string id = RequestContext.Principal.Identity.GetUserId();
            DapperUserData data = new DapperUserData();
            IUserModel user = data.GetUserById(id);
            data.AddInfoAboutUser(user, firstName, lastName);
        }
    }
}
