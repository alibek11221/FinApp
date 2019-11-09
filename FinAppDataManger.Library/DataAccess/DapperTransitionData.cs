using FinAppDataManger.Library.Internals.DataAccess;
using FinAppDataManger.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinAppDataManger.Library.DataAccess
{
    public class DapperTransitionData : DapperBase
    {
        public List<TransitionModel> GetTransitions(int walletId)
        {
            var p = new { walletId = walletId };
            var output = _dataAccess.LoadData<TransitionModel, dynamic>("spWallets_GetWalletsByUser", p, "FinAppData");
            return output;
        }
    }
}
