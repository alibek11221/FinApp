using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinAppDataManger.Library.Models
{
    public class WalletDBModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string WalletName { get; set; }
        public decimal CurrentAmoun { get; set; } = 0M;
        public DateTime CreateDate { get; set; }
    }
}
