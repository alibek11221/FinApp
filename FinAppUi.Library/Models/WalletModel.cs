using System;
using System.Collections.Generic;
using System.Text;

namespace FinAppUi.Library.Models
{
    public class WalletModel : IWalletModel
    {
        public int Id { get; set; }
        public string WalletName { get; set; }
        public decimal CurrentAmount { get; set; }
    }
}
