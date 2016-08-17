using MySql.Data.MySqlClient;
using Npgsql;
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
        private IDataContext context;

        [Fact]
        public void ConnectToSqlServer()
        {
            context = new DataContext<SqlConnection>(@"Server=(local)\SQL2016;Database=master;User ID=sa;Password=Password12!");

            context.Connection.Open();
            context.Connection.Close();
        }

        [Fact]
        public void ConnectToMySql()
        {
            context = new DataContext<MySqlConnection>(@"Server=localhost;Database=TestDatabase;Uid=root;Pwd=Password12!;");

            context.Connection.Open();
            context.Connection.Close();
        }

        [Fact]
        public void ConnectToPostgreSql()
        {
            context = new DataContext<NpgsqlConnection>(@"User ID=postgres;Password=Password12!;Host=localhost;Port=5432;Database=TestDatabase;");

            context.Connection.Open();
            context.Connection.Close();
        }
    }
}
