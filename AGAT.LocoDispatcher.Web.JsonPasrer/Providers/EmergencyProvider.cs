using AGAT.LocoDispatcher.Data.Helpers.LogicHelpers;
using AGAT.LocoDispatcher.Data.Managers;
using AGAT.LocoDispatcher.Web.JsonPasrer.Interfaces;
using AGAT.LocoDispatcher.Web.JsonPasrer.Models.EventModels;
using AGAT.LocoDispatcher.Web.JsonPasrer.Utils;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using EmergencyModel = AGAT.LocoDispatcher.Data.Models.EventModels.EmergencyEvent;

namespace AGAT.LocoDispatcher.Web.JsonPasrer.Providers
{
    public class EmergencyProvider : IProvider
    {
        private DataManager _manager;
        private EventHelper helper;
        private ILogger<ParseJob> logger;
        public EmergencyProvider(ILogger<ParseJob> _logger)
        {
            logger = _logger;
            _manager = new DataManager();
            helper = new EventHelper();
        }
        public async Task Create(IEvent _event)
        {
            try
            {
                logger.LogInformation($"{DateTime.Now} Invoked {_event.Type} event PROVIDER {_event.Timestamp}");

                EmergencyEvent emergencyEvent = (EmergencyEvent)_event;
                int shiftId = await helper.GetLocoShiftIdByLocoNumber(emergencyEvent.TrainId);
                EmergencyModel emergency = new EmergencyModel
                {
                    Type = emergencyEvent.Type,
                    CheckPointNumber = emergencyEvent.CheckPointNumber,
                    ShiftId = shiftId,
                    EmergencyStatus = emergencyEvent.EmergencyStatus,
                    EmergencyType = emergencyEvent.EmergencyType,
                    Message = emergencyEvent.Message,
                    Timestamp = emergencyEvent.Timestamp,
                    TrackNumber = emergencyEvent.TrackNumber
                };
                await _manager.emergencyRepository.CreateAsync(emergency);
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
