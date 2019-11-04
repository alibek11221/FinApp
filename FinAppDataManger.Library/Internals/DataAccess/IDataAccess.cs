using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinAppDataManger.Library.Internals.DataAccess
{
    public interface IDataAccess
    {
        string GetDataBaseAddress(string name);
    }
}
