using AGAT.LocoDispatcher.Constants;
using AGAT.LocoDispatcher.Data.Classes.Repository;
using AGAT.LocoDispatcher.Data.Models.EventModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Web.JsonPasrer.Utils
{
    public class EventProvider
    {
        private EventRepository _repository;
        public EventProvider()
        {
            _repository = new EventRepository();
        }
        public async Task StartEventProvider(IEvent _event)
        {
            try
            {
                switch (_event.Type)
                {
                    case EventConstants.StartMoveEvent:
                        try
                        {
                            StartMoveEvent startMove = new StartMoveEvent
                            {
                                Type = _event.Type,
                                
                                
                            };
                            await _repository.CreateStartEventAsync(startMove);
                            break;
                        }
                        catch(Exception ex)
                        {
                            throw ex;
                        }
                        
                    default:
                        Console.WriteLine("Entered default ");
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
          
        }
    }
}
