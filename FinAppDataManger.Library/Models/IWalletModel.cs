using System;
using System.Collections.Generic;

namespace FinAppDataManger.Library.Models
{
    public interface IWalletModel
    {
        string WalletName { get; set; }
        decimal CurrentAmount { get; set; }
        DateTime CreateDate { get; set; }
        IEnumerable<ITransitionModel> Transitions { get; set; }
    }
}