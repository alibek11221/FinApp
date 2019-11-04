using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinAppDataManger.Library.Models
{
    public class WalletModel : IWalletModel
    {
        public string WalletName { get; set; }
        public decimal CurrentAmount { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public IEnumerable<ITransitionModel> Transitions { get; set; }
    }

}
