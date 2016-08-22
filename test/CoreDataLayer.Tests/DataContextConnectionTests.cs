using MySql.Data.MySqlClient;
using Npgsql;
using System;
using System.Data.SqlClient;
using Xunit;

namespace CoreDataLayer.Tests
{
    public class DataContextConnectionTests
    {
        private IDataContext context;

        [Fact]
        public void ConnectToSqlServer()
        {
            context = new DataContext<SqlConnection>(@"Server=(local)\SQL2016;Database=master;User ID=sa;Password=Password12!");

            context.Connection.Open();
            context.Connection.Close();
        }

        [Theory]
        [InlineData(@"Server = (local)\SQL2016;Database = master;User ID = sa;Password = INCORRECT")]
        [InlineData(@"Server = (local)\SQL2016;Database = master;User ID = INCORRECT;Password = Password12!")]
        [InlineData(@"Server = (local)\SQL2016;Database = INCORRECT;User ID = sa;Password = Password12!")]
        [InlineData(@"Server = INCORRECT;Database = master;User ID = sa;Password = Password12!")]
        public void FailConnectionToSqlServer(string connectionString)
        {
            context = new DataContext<SqlConnection>(connectionString);

            Assert.ThrowsAny<Exception>(() =>
            {
                context.Connection.Open();
                context.Connection.Close();
            });
        }

        [Fact]
        public void ConnectToMySql()
        {
            context = new DataContext<MySqlConnection>(@"Server=localhost;Database=TestDatabase;Uid=root;Pwd=Password12!;");

            context.Connection.Open();
            context.Connection.Close();
        }

        [Theory]
        [InlineData(@"Server=localhost;Database=TestDatabase;Uid=root;Pwd=INCORRECT;")]
        [InlineData(@"Server=localhost;Database=TestDatabase;Uid=INCORRECT;Pwd=Password12!;")]
        [InlineData(@"Server=localhost;Database=INCORRECT;Uid=root;Pwd=Password12!;")]
        [InlineData(@"Server=INCORRECT;Database=TestDatabase;Uid=root;Pwd=Password12!;")]
        public void FailConnectionToMySql(string connectionString)
        {
            context = new DataContext<MySqlConnection>(connectionString);

            Assert.ThrowsAny<Exception>(() =>
            {
                context.Connection.Open();
                context.Connection.Close();
            });
        }

        [Fact]
        public void ConnectToPostgreSql()
        {
            context = new DataContext<NpgsqlConnection>(@"User ID=postgres;Password=Password12!;Host=localhost;Port=5432;Database=TestDatabase;");

            context.Connection.Open();
            context.Connection.Close();
        }

        [Theory]
        [InlineData(@"User ID=postgres;Password=Password12!;Host=localhost;Port=5432;Database=INCORRECT;")]
        [InlineData(@"User ID=postgres;Password=Password12!;Host=INCORRECT;Port=5432;Database=TestDatabase;")]
        [InlineData(@"User ID=postgres;Password=INCORRECT;Host=localhost;Port=5432;Database=TestDatabase;")]
        [InlineData(@"User ID=INCORRECT;Password=Password12!;Host=localhost;Port=5432;Database=TestDatabase;")]
        public void FailConnectionToPostgreSql(string connectionString)
        {
            context = new DataContext<NpgsqlConnection>(connectionString);

            Assert.ThrowsAny<Exception>(() =>
            {
                context.Connection.Open();
                context.Connection.Close();
            });
        }
    }
}
