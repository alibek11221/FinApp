using FinAppDataManger.Library.Internals.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinAppDataManger.Library.DataAccess
{
    public class DapperBase
    {
        protected IDapperDataAccess _dataAccess { get; set; } = new DapperSqlDataAccess();
    }
}
