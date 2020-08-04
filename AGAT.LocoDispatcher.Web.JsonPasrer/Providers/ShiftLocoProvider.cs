using AGAT.LocoDispatcher.Data.Helpers.LogicHelpers;
using AGAT.LocoDispatcher.Data.Managers;
using AGAT.LocoDispatcher.Data.Models.EventModels;
using AGAT.LocoDispatcher.Web.JsonPasrer.Interfaces;
using AGAT.LocoDispatcher.Web.JsonPasrer.Models.EventModels;
using AGAT.LocoDispatcher.Web.JsonPasrer.Utils;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Web.JsonPasrer.Providers
{
    public class ShiftLocoProvider : IProvider
    {
        private LocoShiftHelper helper;
        private ILogger<ParseJob> logger;
        public ShiftLocoProvider(ILogger<ParseJob> _logger)
        {
            logger = _logger;
            helper = new LocoShiftHelper();
        }
        public async Task Create(IEvent _event)
        {
            try
            {
                logger.LogInformation($"{DateTime.Now} Invoked {_event.Type} event PROVIDER {_event.Timestamp}");
                ShiftLocomotiveEvent shiftLocomotive = (ShiftLocomotiveEvent)_event;
                foreach (var train in shiftLocomotive.Trains)
                {
                    LocoShiftEvent locoShift = new LocoShiftEvent
                    {
                        TrainNumber = train,
                        ESR = shiftLocomotive.ESR,
                    };
                    await helper.AddLocoShiftAsync(locoShift, shiftLocomotive.Timestamp);
                }
            }
            catch (FormatException ex)
            {
                logger.LogError($" {DateTime.Now} {_event.Type} FORMAT ERROR {ex.Message}");
                throw ex;
            }
            catch (Exception ex)
            {
                logger.LogError($" {DateTime.Now} {_event.Type} ERROR {ex.Message}");
                throw ex;
            }
           

        }
    }
}
