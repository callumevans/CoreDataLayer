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

        int ExecuteWriteProcedure(string procedure, object parameters = null);

        IEnumerable<T> ExecuteReadProcedure<T>(string procedure, object parameters = null);
    }
}
