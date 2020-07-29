using AGAT.LocoDispatcher.Data.Models.EventModels;
using System;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Data.Classes.Repository
{
    public class EventRepository
    { 
        public async Task CreateStartEventAsync(StartMoveEvent _event)
        {
            if (_event == null)
            {
                throw new ArgumentNullException("start event cant be null");
            }
            using (DatabaseContext context = new DatabaseContext())
            {
                context.StartEvents.Add(_event);
                await context.SaveChangesAsync();
            }
        }

        public async Task CreateStopEventAsync(StopMoveEvent _event)
        {
            if (_event == null)
            {
                throw new ArgumentNullException("stop event cant be null");
            }
            using (DatabaseContext context = new DatabaseContext())
            {
                context.StopEvents.Add(_event);
                await context.SaveChangesAsync();
            }
        }

        public async Task CreateCheckpointEventAsync(CheckpointEvent _event)
        {
            if (_event == null)
            {
                throw new ArgumentNullException("stop event cant be null");
            }
            using (DatabaseContext context = new DatabaseContext())
            {
                context.CheckpointEvents.Add(_event);
                await context.SaveChangesAsync();
            }
        }

        public async Task CreateEmergencyEventAsync(EmergencyEvent _event)
        {
            if (_event == null)
            {
                throw new ArgumentNullException("stop event cant be null");
            }
            using (DatabaseContext context = new DatabaseContext())
            {
                context.EmergencyEvents.Add(_event);
                await context.SaveChangesAsync();
            }
        }
    }
}
