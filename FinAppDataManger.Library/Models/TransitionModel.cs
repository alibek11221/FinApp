using System;

namespace FinAppDataManger.Library.Models
{
    public class TransitionModel
    {
        public int Id { get; set; }
        public ArticleModel Article { get; set; }
        public WalletModel Wallet { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransitionDate { get; set; }
        public bool TransitionType { get; set; }
    }
}
