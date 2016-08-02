using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

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

        public IEnumerable<T> ExecuteReadProcedure<T>(string procedure, object parameters = null)
        {
            var inputs = new DynamicParameters();

            if (parameters != null)
            {
                inputs.AddDynamicParams(parameters);
            }

            var results = Connection.Query<T>(procedure, inputs, commandType: CommandType.StoredProcedure);
            return results;
        }

        public async Task<IEnumerable<T>> ExecuteReadProcedureAsync<T>(string procedure, object parameters = null)
        {
            var inputs = new DynamicParameters();

            if (parameters != null)
            {
                inputs.AddDynamicParams(parameters);
            }

            var results = await Connection.QueryAsync<T>(procedure, inputs, commandType: CommandType.StoredProcedure);
            return results;
        }

        public int ExecuteWriteProcedure(string procedure, object parameters = null)
        {
            var inputs = new DynamicParameters();

            if (parameters != null)
            {
                inputs.AddDynamicParams(parameters);
            }

            int index = Connection.Execute(procedure, inputs, commandType: CommandType.StoredProcedure);
            return index;
        }

        public async Task<int> ExecuteWriteProcedureAsync(string procedure, object parameters = null)
        {
            var inputs = new DynamicParameters();

            if (parameters != null)
            {
                inputs.AddDynamicParams(parameters);
            }

            int index = await Connection.ExecuteAsync(procedure, inputs, commandType: CommandType.StoredProcedure);
            return index;
        }
    }
}
