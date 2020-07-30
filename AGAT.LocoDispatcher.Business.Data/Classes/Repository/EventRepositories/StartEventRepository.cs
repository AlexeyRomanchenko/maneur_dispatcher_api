using AGAT.LocoDispatcher.Data.Models.EventModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Data.Classes.Repository
{
    public class StartEventRepository
    {
        private DatabaseContext _context;
        public StartEventRepository()
        {
            _context = new DatabaseContext();
        }
        public async Task CreatAsync(StartMoveEvent _event)
        {
            if (_event == null)
            {
                throw new ArgumentNullException("start event cant be null");
            }
            using (DatabaseContext context = new DatabaseContext())
            {
                _event.CreatedAt = DateTime.Now;
                context.StartEvents.Add(_event);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<StartMoveEvent>> GetAsync() 
        {
            return await _context.StartEvents.ToListAsync();
        }
    }
}
