using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace FinAppDataManger.Library.Internals.DataAccess
{
    public class DapperSqlDataAccess : IDataAccess, IDapperDataAccess
    {
        public string GetDataBaseAddress(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
        public IEnumerable<T> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName)
        {
            var connectionString = GetDataBaseAddress(connectionStringName);
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var rows = connection.Query<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure).ToList();
                return rows;
            }
        }

        public void SaveData<T>(string storedProcedure, T parameters, string connectionStringName)
        {
            string connectionString = GetDataBaseAddress(connectionStringName);
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
