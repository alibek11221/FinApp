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
        public IEnumerable<IWalletModel> GetCurrentUsersWallets(string id) 
        {
            var p = new { Id = id };
            var output = _dataAccess.LoadData<IWalletModel, dynamic>("sp.Wallets_GetCurrentUsersWallets", p, "FinAppData");
            return output;
        }
        public DapperWalletData()
        {
        }
    }
}
