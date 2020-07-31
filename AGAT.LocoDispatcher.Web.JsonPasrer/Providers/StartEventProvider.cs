using AGAT.LocoDispatcher.Data.Helpers.LogicHelpers;
using AGAT.LocoDispatcher.Data.Managers;
using AGAT.LocoDispatcher.Web.JsonPasrer.Interfaces;
using AGAT.LocoDispatcher.Web.JsonPasrer.Models.EventModels;
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
        public StartEventProvider()
        {
            _manager = new DataManager();
            _helper = new EventHelper();
        }
        public async Task Create(IEvent _event)
        {
            try
            {
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
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
    }
}
