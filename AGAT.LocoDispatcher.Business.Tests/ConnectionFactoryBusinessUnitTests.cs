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
            ConnectionFacade.SetConnectionString(connection);
            Assert.Equal(connection, ConnectionFacade.GetConnectionString());
        }

        [Fact]
        public void SetConnectionStringTrimmedOK()
        {
            string connection = " sdfsf   ";
            ConnectionFacade.SetConnectionString(connection);
            connection = connection.Trim();
            Assert.Equal(connection, ConnectionFacade.GetConnectionString());
        }

        [Fact]
        public void SetConnectionStringThrowsArgumentNullExceptionOK()
        {
            string connection = "    ";
            Assert.Throws<ArgumentNullException>(() => ConnectionFacade.SetConnectionString(connection));
        }
    }
}
