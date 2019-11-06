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
    public class WalletController : ApiController
    {
        [HttpGet] 
        public List<WalletModel> GetWallets()
        {
            string id = RequestContext.Principal.Identity.GetUserId();
            DapperWalletData data = new DapperWalletData();
            List<WalletModel> output = data.GetCurrentUsersWallets(id);
            return output;
        }
    }
}
