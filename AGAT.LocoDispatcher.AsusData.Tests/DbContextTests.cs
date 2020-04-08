using AGAT.LocoDispatcher.AsusData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AGAT.LocoDispatcher.AsusData.Tests
{
    public class DbContextTests
    {
        [Fact]
        public void DatabaseConnectedOk()
        {
            using (AsusDataContext db = new AsusDataContext())
            {
                List<Route> data = db.Routes.ToList();
                Assert.NotEmpty(data);
            }
        }

        [Theory]
        [InlineData("14043")]
        public void GetParksByStationCodeOk(string code)
        {
            using (AsusDataContext context = new AsusDataContext())
            {
                var parks = context.Parks.Where(e => e.StationCode == code).ToList();
                Assert.NotEmpty(parks);
            }
        }
    }
}
