using AGAT.LocoDispatcher.Data.Models.EventModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Data.Classes.Repository.EventRepositories
{
    public class CheckpointEventRepository
    {
        private DatabaseContext _context;
        public CheckpointEventRepository()
        {
            _context = new DatabaseContext();
        }
        public async Task CreatAsync(CheckpointEvent _event)
        {
            _event.CreatedAt = DateTime.Now;
            _context.CheckpointEvents.Add(_event);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CheckpointEvent>> GetAsync()
        {
            return await _context.CheckpointEvents.ToListAsync();
        }
    }
}
