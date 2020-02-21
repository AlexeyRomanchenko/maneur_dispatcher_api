using AGAT.LocoDispatcher.Data.Models;
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

        [Fact]
        public void CastingTests()
        {
            Main.MainMethod();
            var res = GC.GetTotalMemory(false);
        }
    }
}
