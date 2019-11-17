using FinAppDataManger.Library.DataAccess;
using FinAppDataManger.Library.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
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
            WalletData data = new WalletData();
            List<WalletModel> output = data.GetCurrentUsersWallets(id);
            return output;
        }

        [HttpPost]
        public void PostWallet(WalletModel wallet)
        {
            WalletData data = new WalletData();
            string id = RequestContext.Principal.Identity.GetUserId();
            data.AddWallet(wallet, id);
        }
    }
}
