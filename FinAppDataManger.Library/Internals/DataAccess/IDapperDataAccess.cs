using System;
using System.Collections;
using System.Collections.Generic;

namespace FinAppDataManger.Library.Internals.DataAccess
{
     public interface IDapperDataAccess : IDataAccess
    {
        void SaveData<T>(string storedProcedure, T parameters, string connectionStringName);
        List<T> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName);
    }
}