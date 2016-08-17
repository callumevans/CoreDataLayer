using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CoreDataLayer.Tests
{
    public class DataContextSqlServerTests
    {
        [Fact]
        public void ConnectToSqlServer()
        {
            IDataContext context = new DataContext<SqlConnection>(@"Server=(local)\SQL2016;Database=master;User ID=sa;Password=Password123!");

            context.Connection.Open();
        }
    }
}
