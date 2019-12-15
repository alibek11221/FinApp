using Dapper;
using FinAppDataManger.Library.Internals.DataAccess;
using FinAppDataManger.Library.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;

namespace FinAppDataManger.Library.DataAccess
{
    public sealed class WalletData
    {
        private readonly IConfiguration _config;

        public WalletData(IConfiguration config)
        {
            _config = config;
        }
        private bool WalletDoesNotExist(string nameToCheck, string userId)
        {
            SqlDataAccess dataAccess = new SqlDataAccess(_config);
            var p = new DynamicParameters();
            p.Add("@WalletName", nameToCheck);
            p.Add("@UserId", userId);
            p.Add("@Out", DbType.Int32, direction: ParameterDirection.Output);
            dataAccess.LoadData<dynamic, dynamic>("spWallets_WalletsLookUp", p, "FinAppData");
            var retval = p.Get<int>("@Out");
            if (retval == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void AddWallet(WalletModel wallet, string userId)
        {
            if (WalletDoesNotExist(wallet.WalletName, userId))
            {
                SqlDataAccess sql = new SqlDataAccess(_config);
                var p = new { UserId = userId, WalletName = wallet.WalletName, CurrentAmount = wallet.CurrentAmount };
                sql.SaveData("spWallets_AddWallet", p, "FinAppData");
            }
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
