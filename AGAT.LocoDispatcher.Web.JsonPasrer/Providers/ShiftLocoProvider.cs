using AGAT.LocoDispatcher.Data.Helpers.LogicHelpers;
using AGAT.LocoDispatcher.Data.Managers;
using AGAT.LocoDispatcher.Data.Models.EventModels;
using AGAT.LocoDispatcher.Web.JsonPasrer.Interfaces;
using AGAT.LocoDispatcher.Web.JsonPasrer.Models.EventModels;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Web.JsonPasrer.Providers
{
    public class ShiftLocoProvider : IProvider
    {
        private LocoShiftHelper helper;
        public ShiftLocoProvider()
        {
            helper = new LocoShiftHelper();
        }
        public async Task Create(IEvent _event)
        {
            ShiftLocomotiveEvent shiftLocomotive = (ShiftLocomotiveEvent)_event;
            LocoShiftEvent locoShift = new LocoShiftEvent 
            {
            TrainNumber = shiftLocomotive.TrackNumber,
            ESR = shiftLocomotive.ESR,
            };
            await helper.AddLocoShiftAsync(locoShift, shiftLocomotive.Timestamp);
        }
    }
}
