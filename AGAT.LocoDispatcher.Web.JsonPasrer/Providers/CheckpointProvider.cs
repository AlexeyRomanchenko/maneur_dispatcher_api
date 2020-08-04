using AGAT.LocoDispatcher.Data.Helpers.LogicHelpers;
using AGAT.LocoDispatcher.Data.Managers;
using AGAT.LocoDispatcher.Web.JsonPasrer.Interfaces;
using AGAT.LocoDispatcher.Web.JsonPasrer.Models.EventModels;
using AGAT.LocoDispatcher.Web.JsonPasrer.Utils;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using CheckpointModel = AGAT.LocoDispatcher.Data.Models.EventModels.CheckpointEvent;

namespace AGAT.LocoDispatcher.Web.JsonPasrer.Providers
{
    public class CheckpointProvider : IProvider
    {
        private DataManager _manager;
        private EventHelper helper;
        private ILogger<ParseJob> logger;
        public CheckpointProvider(ILogger<ParseJob> _logger)
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
                CheckpointEvent checkpointEvent = (CheckpointEvent)_event;
                int shiftId = await helper.GetLocoShiftIdByLocoNumber(checkpointEvent.TrainId);
                CheckpointModel checkpoint = new CheckpointModel
                {
                    Type = checkpointEvent.Type,
                    CheckPointNumber = checkpointEvent.CheckPointNumber,
                    Message = checkpointEvent.Message,
                    Speed = checkpointEvent.Speed,
                    ShiftId = shiftId,
                    Timestamp = checkpointEvent.Timestamp,
                    TrackNumber = checkpointEvent.TrackNumber
                };
                await _manager.checkpointEventRepository.CreatAsync(checkpoint);
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
