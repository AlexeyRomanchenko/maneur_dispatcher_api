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

    public class LocoHelperUnitTests
    {
        private LocoShiftHelper helper;
        public LocoHelperUnitTests()
        {
            helper = new LocoShiftHelper();
        }
       
        [Theory]
        [InlineData(1596180898)]
        public async Task AddLogoShiftHelperOk(int timestamp)
        {
            bool isAdded = false;            
            LocoShiftEvent loco = new LocoShiftEvent 
            {
                ESR = "140043",
                TrainNumber = "test"
            };
            await helper.AddLocoShiftAsync(loco, timestamp);
            isAdded = true;
            //using (DatabaseContext context = new DatabaseContext())
            //{
            //    IEnumerable<LocoShiftEvent> events = await context.LocoShiftEvents.Where(e => e.TrainNumber == "test").ToListAsync();
            //    context.RemoveRange(events);
            //    await context.SaveChangesAsync();
            //}
            Assert.True(isAdded);
        }
    }
}
