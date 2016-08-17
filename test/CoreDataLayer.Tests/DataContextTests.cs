using CoreDataLayer;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CoreDataLayer.Tests
{
    public class DataContextTests
    {
        private IDataContext dataContext;

        public DataContextTests()
        {
            dataContext = new DataContext<SqliteConnection>("Data Source=:memory:");
        }

        [Fact]
        public void DoTest()
        {
            var output = dataContext.ExecuteReadProcedure<string>("", new
            {

            });

            var t = output;

            Assert.Equal(true, true);
        }
    }
}
