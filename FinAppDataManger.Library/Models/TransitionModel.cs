using System;

namespace FinAppDataManger.Library.Models
{
    public class TransitionModel
    {
        public ArticleModel Article { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransitionDate { get; set; }
    }
}
