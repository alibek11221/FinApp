using FinAppDataManger.Library.Internals.DataAccess;
using FinAppDataManger.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinAppDataManger.Library.DataAccess
{
    public sealed class DapperUserData : DapperBase
    {
        public IUserModel GetUserById(string id)
        {
            var p = new { Id = id };
            var output = _dataAccess.LoadData<IUserModel, dynamic>("spUsers_GetById", p, "FinAppData").FirstOrDefault();
            return output;
        }
        public void AddInfoAboutUser(IUserModel user,string firstName, string lastName)
        {
            user.CreateDate = DateTime.UtcNow;
            user.FirstName = firstName;
            user.LastName = lastName;
            _dataAccess.SaveData("spUsers_AddInfo", user, "FinAppData");
        }
        public DapperUserData()
        {

        }
    }
}
