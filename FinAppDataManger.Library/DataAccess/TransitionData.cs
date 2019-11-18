using FinAppDataManger.Library.Internals.DataAccess;
using FinAppDataManger.Library.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace FinAppDataManger.Library.DataAccess
{
    public class TransitionData
    {
        private readonly IConfiguration _config;

        public TransitionData(IConfiguration config)
        {
            _config = config;
        }
        public List<TransitionModel> GetTransitionsByWallet(int WalletId)
        {
            SqlDataAccess sql = new SqlDataAccess(_config);
            var p = new { WalletId = WalletId };
            var outuput = sql.LoadData<TransitionModel, dynamic>("spTransitionsGetByWallet", p, "FinAppData");
            return outuput;
        }
    }
}
