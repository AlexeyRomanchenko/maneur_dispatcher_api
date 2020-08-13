using AGAT.LocoDispatcher.Data.Helpers.LogicHelpers;
using AGAT.LocoDispatcher.Data.Managers;
using AGAT.LocoDispatcher.Web.JsonPasrer.Interfaces;
using AGAT.LocoDispatcher.Web.JsonPasrer.Models.EventModels;
using AGAT.LocoDispatcher.Web.JsonPasrer.Utils;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using IEvent = AGAT.LocoDispatcher.Web.JsonPasrer.Models.EventModels.IEvent;
using StartModel = AGAT.LocoDispatcher.Data.Models.EventModels.StartMoveEvent;

namespace AGAT.LocoDispatcher.Web.JsonPasrer.Providers
{
    public class StartEventProvider : IProvider
    {
        private DataManager _manager;
        private EventHelper _helper;
        private ILogger<ParseJob> logger;
        public StartEventProvider(ILogger<ParseJob> _logger)
        {
            _manager = new DataManager();
            _helper = new EventHelper();
            logger = _logger;
        }
        public async Task Create(IEvent _event)
        {
            try
            {
                logger?.LogInformation($"{DateTime.Now} Invoked {_event.Type} event PROVIDER {_event.Timestamp}");
                StartMoveEvent startMove = (StartMoveEvent)_event;
                int shiftId = await _helper.GetLocoShiftIdByLocoNumber(startMove.TrainId);
                StartModel moveEvent = new StartModel
                {
                    Type = startMove.Type,
                    CheckPointNumber = startMove.CheckPointNumber,
                    Direction = startMove.Direction,
                    DirectionParity = startMove.DirectionParity,
                    Timestamp = startMove.Timestamp,
                    ShiftId = shiftId,
                    TrackNumber = startMove.TrackNumber,
                    Message = startMove.Message
                };
                
                await _manager.startEventRepository.CreatAsync(moveEvent);
            }
            catch (FormatException ex)
            {
                logger?.LogError($" {DateTime.Now} {_event.Type} FORMAT ERROR {ex.Message}");
                throw ex;
            }
            catch (Exception ex)
            {
                logger?.LogError($" {DateTime.Now} {_event.Type} ELSE ERROR {ex.Message}");
                throw ex;
            }
           
        }
    }
}
