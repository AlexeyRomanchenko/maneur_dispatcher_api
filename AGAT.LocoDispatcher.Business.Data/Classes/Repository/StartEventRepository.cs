using AGAT.LocoDispatcher.Data.Models.EventModels;
using System;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Data.Classes.Repository
{
    public class StartEventRepository
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
    }
}
