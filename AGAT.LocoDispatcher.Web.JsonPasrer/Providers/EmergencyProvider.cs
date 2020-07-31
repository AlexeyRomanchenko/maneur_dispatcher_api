using AGAT.LocoDispatcher.Data.Helpers.LogicHelpers;
using AGAT.LocoDispatcher.Data.Managers;
using AGAT.LocoDispatcher.Web.JsonPasrer.Interfaces;
using AGAT.LocoDispatcher.Web.JsonPasrer.Models.EventModels;
using System;
using System.Threading.Tasks;
using EmergencyModel = AGAT.LocoDispatcher.Data.Models.EventModels.EmergencyEvent;

namespace AGAT.LocoDispatcher.Web.JsonPasrer.Providers
{
    public class EmergencyProvider : IProvider
    {
        private DataManager _manager;
        private EventHelper helper;
        public EmergencyProvider()
        {
            _manager = new DataManager();
            helper = new EventHelper();
        }
        public async Task Create(IEvent _event)
        {
            try
            {
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
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
