using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinAppDataManger.Library.Models
{
    public class TransitionModel : ITransitionModel
    {
        public IArticleModel Article{ get; set; }
        public decimal Amount { get; set; }
        public DateTime TransitionDate { get; set; }
    }
}
