using FinAppDataManger.Library.Internals.DataAccess;
using FinAppDataManger.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinAppDataManger.Library.DataAccess
{
    public sealed class UserData
    {
        public UserModel GetUserById(string id)
        {
            SqlDataAccess sql = new SqlDataAccess();
            var p = new { Id = id };
            var output = sql.LoadData<UserModel, dynamic>("spUsers_GetById", p, "FinAppData").FirstOrDefault();
            return output;
        }
    }
}
