using Dapper;
using FinAppDataManger.Library.Internals.DataAccess;
using FinAppDataManger.Library.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace FinAppDataManger.Library.DataAccess
{
    public sealed class WalletData
    {
        private readonly IConfiguration _config;

        public WalletData(IConfiguration config)
        {
          _config = config;
        }
        public void AddWallet(WalletModel wallet, string id)
        {
            SqlDataAccess sql = new SqlDataAccess(_config);
            var p = new DynamicParameters();
            p.Add("UserId", id);
            p.Add("WalletName", wallet.WalletName);
            p.Add("CurrentAmount", wallet.CurrentAmount);
            sql.SaveData("spWallets_AddWallet", p, "FinAppData");
        }
        public List<WalletModel> GetCurrentUsersWallets(string id)
        {
            SqlDataAccess sql = new SqlDataAccess(_config);
            var p = new { Id = id };
            var output = sql.LoadData<WalletModel, dynamic>("spWallets_GetWalletsByUser", p, "FinAppData");
            return output;
        }
    }
}
