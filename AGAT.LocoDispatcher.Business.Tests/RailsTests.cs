using AGAT.LocoDispatcher.Business.Classes;
using Xunit;

namespace AGAT.LocoDispatcher.Business.Tests
{
    public class RailsTests
    {
        [Fact]
        public void GetStationRailsOk()
        {
            RailsManager railManager = new RailsManager();
            var stationScheme = railManager.GetRailsScheme();
            Assert.NotEmpty(stationScheme);
        }
    }
}
