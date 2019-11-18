using FinAppDataManger.Library.Internals.DataAccess;
using FinAppDataManger.Library.Models;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace FinAppDataManger.Library.DataAccess
{
    public sealed class UserData
    {
        private readonly IConfiguration _config;

        public UserData(IConfiguration config)
        {
            _config = config;
        }
        public UserModel GetUserData(string id)
        {
            SqlDataAccess sql = new SqlDataAccess(_config);
            var p = new { Id = id };
            var output = sql.LoadData<UserModel, dynamic>("spUsers_GetById", p, "FinAppData").FirstOrDefault();
            return output;
        }
    }
}
