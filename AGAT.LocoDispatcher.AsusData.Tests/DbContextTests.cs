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

        [Theory]
        [InlineData("14043")]
        public void GetRailsByParkId(string code)
        {
            List<StationPark> parks = new List<StationPark>();
            List<Route> routes = new List<Route>();
            using (AsusDataContext context = new AsusDataContext())
            {
                parks = context.Parks.Where(e => e.StationCode == code).ToList();
            }
            foreach (var park in parks)
            {
                using (AsusDataContext context = new AsusDataContext())
                {
                    routes = context.Routes.Where(e => e.ParkId == park.Id).ToList();
                }
            }
            Assert.NotEmpty(routes);
        }
    }
}
