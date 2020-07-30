using AGAT.LocoDispatcher.Constants;
using AGAT.LocoDispatcher.Web.JsonPasrer.Interfaces;
using AGAT.LocoDispatcher.Web.JsonPasrer.Models.EventModels;
using AGAT.LocoDispatcher.Web.JsonPasrer.Providers;
using System;

namespace AGAT.LocoDispatcher.Web.JsonPasrer.Utils
{
    public class ProviderFactory
    {
        public IProvider GetProviderFactory(IEvent _event)
        {
            switch (_event.Type)
            {
                case EventConstants.StartMoveEvent:
                   return new StartEventProvider();
                case EventConstants.StopMoveEvent:
                    return new StopEventProvider();
                case EventConstants.StopOutsideStation:
                    return new StopEventProvider();
                case EventConstants.PassCheckpoint:
                    return new CheckpointProvider();
                case EventConstants.Emergency:
                    return new EmergencyProvider();
                default:
                    Console.WriteLine("");
                    return null;
            }
        }
    }
}
