using AGAT.LocoDispatcher.Business.Classes;
using System;
using Xunit;

namespace AGAT.LocoDispatcher.Business.Tests
{
    public class ConnectionFactoryBusinessUnitTests
    {
        [Fact]
        public void SetConnectionStringOK()
        {
            string connection = "sdfsf";
            ConnectionFactory.SetConnectionString(connection);
            Assert.Equal(connection, ConnectionFactory.GetConnectionString());
        }

        [Fact]
        public void SetConnectionStringTrimmedOK()
        {
            string connection = " sdfsf   ";
            ConnectionFactory.SetConnectionString(connection);
            connection = connection.Trim();
            Assert.Equal(connection, ConnectionFactory.GetConnectionString());
        }

        [Fact]
        public void SetConnectionStringThrowsArgumentNullExceptionOK()
        {
            string connection = "    ";
            Assert.Throws<ArgumentNullException>(() => ConnectionFactory.SetConnectionString(connection));
        }
    }
}
