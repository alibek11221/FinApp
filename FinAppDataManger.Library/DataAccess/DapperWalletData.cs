using FinAppDataManger.Library.Internals.DataAccess;
using FinAppDataManger.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinAppDataManger.Library.DataAccess
{
    public sealed class DapperWalletData : DapperBase
    {
        public List<WalletModel> GetCurrentUsersWallets(string id) 
        {
            var p = new { Id = id };
            var output = _dataAccess.LoadData<WalletModel, dynamic>("spWallets_GetWalletsByUser", p, "FinAppData");
            return output;
        }
        public DapperWalletData()
        {
        }
    }
}
