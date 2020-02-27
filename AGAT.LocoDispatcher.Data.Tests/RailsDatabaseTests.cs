using AGAT.LocoDispatcher.Data.Classes;
using AGAT.LocoDispatcher.Data.Models;
using System;
using Xunit;

namespace AGAT.LocoDispatcher.Data.Tests
{
    public class ConnectionStringTests
    {
        [Fact]
        public void CreateDatabaseOk()
        {
            DatabaseContext db = new DatabaseContext();
        }

        [Fact]
        public void SetConnectionStringOK()
        {
            ConnectionFactory.SetConnectionString("skskskls");
            string connection = ConnectionFactory.GetConnectionString();
            Assert.NotEqual(0, connection.Length);
        }

        [Fact]
        public void SetConnectionStringThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => { ConnectionFactory.SetConnectionString(""); });
        }

        [Fact]
        public void GetConnectionStringOk()
        {
            string connection = "sdsdsdd ";
            ConnectionFactory.SetConnectionString(connection);
            string _connection = ConnectionFactory.GetConnectionString();
            connection = connection.Trim();
            Assert.Equal(connection, _connection);
        }
    }
}
