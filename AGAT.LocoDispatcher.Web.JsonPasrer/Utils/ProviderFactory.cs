using AGAT.LocoDispatcher.Constants;
using AGAT.LocoDispatcher.Web.JsonPasrer.Interfaces;
using AGAT.LocoDispatcher.Web.JsonPasrer.Models.EventModels;
using AGAT.LocoDispatcher.Web.JsonPasrer.Providers;
using Microsoft.Extensions.Logging;
using System;

namespace AGAT.LocoDispatcher.Web.JsonPasrer.Utils
{
    public class ProviderFactory
    {
        private ILogger<ParseJob> logger;
        public ProviderFactory(ILogger<ParseJob> _logger)
        {
            logger = _logger;
        }
        public IProvider GetProviderFactory(IEvent _event)
        {
            switch (_event.Type)
            {
                case EventConstants.StartMoveEvent:
                   return new StartEventProvider(logger);
                case EventConstants.StopMoveEvent:
                    return new StopEventProvider(logger);
                case EventConstants.StopOutsideStation:
                    return new StopEventProvider(logger);
                case EventConstants.PassCheckpoint:
                    return new CheckpointProvider(logger);
                case EventConstants.Emergency:
                    return new EmergencyProvider(logger);
                case EventConstants.StartShiftLocomotives:
                    return new ShiftLocoProvider(logger);
                default:
                    logger?.LogWarning($"{DateTime.Now}  CANT GET PROVIDER OF PROVIDER FACTORY. {_event.Type}");
                    return null;
            }
        }
    }
}
