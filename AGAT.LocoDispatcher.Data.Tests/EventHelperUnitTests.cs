using AGAT.LocoDispatcher.Data.Helpers.LogicHelpers;
using AGAT.LocoDispatcher.Data.Models.EventModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AGAT.LocoDispatcher.Data.Tests
{

    public class EventHelperUnitTests
    {
        private EventHelper helper;
        public EventHelperUnitTests()
        {
            helper = new EventHelper();
        }
       
        [Theory]
        [InlineData("test")]
        public async Task GetShiftIdOk(string locoNumber)
        {
            int shiftId = await helper.GetLocoShiftIdByLocoNumber(locoNumber);
            //using (DatabaseContext context = new DatabaseContext())
            //{
            //    IEnumerable<LocoShiftEvent> events = await context.LocoShiftEvents.Where(e => e.TrainNumber == "test").ToListAsync();
            //    context.RemoveRange(events);
            //    await context.SaveChangesAsync();
            //}
            Assert.NotEqual(0, shiftId);
        }
    }
}
