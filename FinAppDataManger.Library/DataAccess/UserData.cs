using FinAppDataManger.Library.Internals.DataAccess;
using FinAppDataManger.Library.Models;
using System.Linq;

namespace FinAppDataManger.Library.DataAccess
{
    public sealed class UserData
    {
        public UserModel GetUserData(string id)
        {
            SqlDataAccess sql = new SqlDataAccess();
            var p = new { Id = id };
            var output = sql.LoadData<UserModel, dynamic>("spUsers_GetById", p, "FinAppData").FirstOrDefault();
            return output;
        }
    }
}
