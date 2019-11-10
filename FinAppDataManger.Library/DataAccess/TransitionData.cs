using FinAppDataManger.Library.Internals.DataAccess;
using FinAppDataManger.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinAppDataManger.Library.DataAccess
{
    public class TransitionData
    {
        public List<TransitionModel> GetTransitionsByWallet(int WalletId)
        {
            SqlDataAccess sql = new SqlDataAccess();
            var p = new { WalletId = WalletId };
            var outuput = sql.LoadData<TransitionModel, dynamic>("spTransitionsGetByWallet", p, "FinAppData");
            return outuput;
        }
    }
}
