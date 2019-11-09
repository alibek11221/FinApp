using Dapper;
using FinAppDataManger.Library.Internals.DataAccess;
using FinAppDataManger.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinAppDataManger.Library.DataAccess
{
    public sealed class WalletData 
    {
        public void AddWallet(WalletModel wallet, string id)
        {
            SqlDataAccess sql = new SqlDataAccess();
            var p = new DynamicParameters();
            p.Add("UserId", id);
            p.Add("WalletName", wallet.WalletName);
            p.Add("CurrentAmount", wallet.CurrentAmount);
            sql.SaveData("spWallets_AddWallet", p, "FinAppData");
        }
        public List<WalletModel> GetCurrentUsersWallets(string id) 
        {
            SqlDataAccess sql = new SqlDataAccess();
            var p = new { Id = id };
            var output = sql.LoadData<WalletModel, dynamic>("spWallets_GetWalletsByUser", p, "FinAppData");
            return output;
        }
    }
}
