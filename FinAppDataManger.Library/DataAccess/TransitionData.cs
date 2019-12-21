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
        public List<TransitionModel> GetTransitionsByWallet(string userId,int WalletId)
        {
            SqlDataAccess sql = new SqlDataAccess(_config);
            var p = new { UserId = userId, WalletId = WalletId };
            var outuput = sql.LoadData<TransitionModel, dynamic>("spTransitionsGetByWallet", p, "FinAppData");
            return outuput;
        }
        public void MakeTransition(TransitionModel transition, string userId)
        {
            SqlDataAccess sql = new SqlDataAccess(_config);
            var p = new
            {
                UserId = userId,
                WalletId = transition.Wallet.Id,
                TransitionAmount = transition.Amount,
                TransitionDate = transition.TransitionDate,
                TransitionType = transition.TransitionType,
                ArticleId = transition.Article.Id
            };
            sql.Execute("spTransitions_MakeTransitions", p, "FinAppData");
        }
    }
}
