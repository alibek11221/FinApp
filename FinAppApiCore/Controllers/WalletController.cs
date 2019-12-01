using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FinAppDataManger.Library.DataAccess;
using FinAppDataManger.Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FinAppApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WalletController : ControllerBase
    {
        private readonly IConfiguration _config;

        public WalletController(IConfiguration config)
        {
            _config = config;
        }
        [HttpGet]
        public List<WalletModel> GetWallets()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            WalletData data = new WalletData(_config);
            List<WalletModel> output = data.GetCurrentUsersWallets(id);
            return output;
        }

        [HttpPost]
        public void PostWallet(WalletModel wallet)
        {
            WalletData data = new WalletData(_config);
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            data.AddWallet(wallet, id);
        }
    }
}