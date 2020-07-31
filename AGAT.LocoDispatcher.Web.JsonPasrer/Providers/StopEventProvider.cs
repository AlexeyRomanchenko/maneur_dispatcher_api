using AGAT.LocoDispatcher.Data.Managers;
using AGAT.LocoDispatcher.Web.JsonPasrer.Interfaces;
using AGAT.LocoDispatcher.Web.JsonPasrer.Models.EventModels;
using System.Threading.Tasks;
using StopModel = AGAT.LocoDispatcher.Data.Models.EventModels.StopMoveEvent;

namespace AGAT.LocoDispatcher.Web.JsonPasrer.Providers
{
    public class StopEventProvider : IProvider
    {
        private DataManager _manager;
        public StopEventProvider()
        {
            _manager = new DataManager();
        }
        public async Task Create(IEvent _event)
        {
            StopMoveEvent stopMove = (StopMoveEvent)_event;
            StopModel stopMoveEvent = new StopModel
            {
                Type = stopMove.Type,
                CheckPointNumber = stopMove.CheckPointNumber,
                Distance = stopMove.Distance,
                Message = stopMove.Message,
                Timestamp = stopMove.Timestamp,
                TrackNumber = stopMove.TrackNumber
            };
            await _manager.stopEventRepository.CreatAsync(stopMoveEvent);
        }
    }
}
