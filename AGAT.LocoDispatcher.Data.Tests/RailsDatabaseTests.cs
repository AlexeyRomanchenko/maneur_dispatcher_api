using System;
using Xunit;

namespace AGAT.LocoDispatcher.Data.Tests
{
    public class RailsDatabaseTests
    {
        [Fact]
        public void CreateDatabaseOk()
        {
            DatabaseContext db = new DatabaseContext();
        }
    }
}
