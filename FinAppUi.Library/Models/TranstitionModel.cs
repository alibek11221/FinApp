using System;
using System.Collections.Generic;
using System.Text;

namespace FinAppUi.Library.Models
{
    public class TranstitionModel
    {
        public ArticleModel Article { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransitionDate { get; set; }
    }
}
