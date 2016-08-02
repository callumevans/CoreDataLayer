using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDataLayer
{
    public interface IDataContext
    {
        DbConnection Connection { get; }

        IEnumerable<T> ExecuteReadProcedure<T>(string procedure, object parameters = null);

        Task<IEnumerable<T>> ExecuteReadProcedureAsync<T>(string procedure, object parameters = null);

        int ExecuteWriteProcedure(string procedure, object parameters = null);

        Task<int> ExecuteWriteProcedureAsync(string procedure, object parameters = null);
    }
}
