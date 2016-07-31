using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace CoreDataLayer
{
    public class DataContext<ConnectionType> : IDataContext 
        where ConnectionType : DbConnection
    {
        public DbConnection Connection { get; private set; }

        public DataContext(string connectionString)
        {
            this.Connection = (DbConnection)Activator.CreateInstance(typeof(ConnectionType), connectionString);
        }

        public IEnumerable<T> ExecuteReadProcedure<T>(string procedure, object parameters)
        {
            var inputs = new DynamicParameters();

            if (parameters != null)
            {
                inputs.AddDynamicParams(parameters);
            }

            var results = Connection.Query<T>(procedure, inputs, commandType: CommandType.StoredProcedure);
            return results;
        }

        public int ExecuteWriteProcedure(string procedure, object parameters)
        {
            var inputs = new DynamicParameters();

            if (parameters != null)
            {
                inputs.AddDynamicParams(parameters);
            }

            int index = Connection.Execute(procedure, inputs, commandType: CommandType.StoredProcedure);
            return index;
        }
    }
}
