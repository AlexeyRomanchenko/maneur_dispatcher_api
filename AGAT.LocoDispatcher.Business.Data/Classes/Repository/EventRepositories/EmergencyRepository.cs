using AGAT.LocoDispatcher.Data.Models.EventModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Data.Classes.Repository.EventRepositories
{
    public class EmergencyRepository
    {
        private DatabaseContext _context;
        public EmergencyRepository()
        {
            _context = new DatabaseContext();
        }
        public async Task CreateAsync(EmergencyEvent _event)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                _event.CreatedAt = DateTime.Now;
                context.EmergencyEvents.Add(_event);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<EmergencyEvent>> GetAsync()
        {
            return await _context.EmergencyEvents.ToListAsync();
        }
    }
}
