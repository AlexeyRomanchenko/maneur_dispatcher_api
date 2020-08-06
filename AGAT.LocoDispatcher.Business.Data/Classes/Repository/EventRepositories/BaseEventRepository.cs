using AGAT.LocoDispatcher.Data.Models.EventModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Data.Classes.Repository.EventRepositories
{
    public class BaseEventRepository
    {
        public async Task<MoveEventBase> GetLastEventByShiftIdAsync(int shiftId)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                MoveEventBase lastEvent = await context.Events
                    .Where(e => e.ShiftId == shiftId && e.CheckPointNumber != null)
                    .OrderByDescending(e => e.Timestamp).FirstOrDefaultAsync();
                return lastEvent;
            }
        }
    }
}
