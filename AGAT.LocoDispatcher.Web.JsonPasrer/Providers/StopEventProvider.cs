using AGAT.LocoDispatcher.Data.Helpers.LogicHelpers;
using AGAT.LocoDispatcher.Data.Managers;
using AGAT.LocoDispatcher.Web.JsonPasrer.Interfaces;
using AGAT.LocoDispatcher.Web.JsonPasrer.Models.EventModels;
using AGAT.LocoDispatcher.Web.JsonPasrer.Utils;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using StopModel = AGAT.LocoDispatcher.Data.Models.EventModels.StopMoveEvent;

namespace AGAT.LocoDispatcher.Web.JsonPasrer.Providers
{
    public class StopEventProvider : IProvider
    {
        private DataManager _manager;
        private EventHelper _helper;
        private ILogger<ParseJob> _logger;
        public StopEventProvider(ILogger<ParseJob> logger)
        {
            _logger = logger;
            _manager = new DataManager();
            _helper = new EventHelper();
        }
        public async Task Create(IEvent _event)
        {
            try
            {
                _logger.LogInformation($"{DateTime.Now} Invoked {_event.Type} event PROVIDER {_event.Timestamp}");
                StopMoveEvent stopMove = (StopMoveEvent)_event;
                int shiftId = await _helper.GetLocoShiftIdByLocoNumber(stopMove.TrainId);
                StopModel stopMoveEvent = new StopModel
                {
                    Type = stopMove.Type,
                    CheckPointNumber = stopMove.CheckPointNumber,
                    Distance = stopMove.Distance,
                    ShiftId = shiftId,
                    Message = stopMove.Message,
                    Timestamp = stopMove.Timestamp,
                    TrackNumber = stopMove.TrackNumber
                };
                await _manager.stopEventRepository.CreatAsync(stopMoveEvent);
            }
            catch (FormatException ex)
            {
                _logger.LogError($" {DateTime.Now} {_event.Type} FORMAT ERROR {ex.Message}");
                throw ex;
            }
            catch (Exception ex)
            {
                _logger.LogError($" {DateTime.Now} {_event.Type} ERROR {ex.Message}");
                throw ex;
            }
           
        }
    }
}
