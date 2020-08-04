using AGAT.LocoDispatcher.AsusData.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.AsusData.Repository
{
    public class AssignmentRepository
    {
        private AsusDataContext context;
        public AssignmentRepository()
        {
            context = new AsusDataContext();
        }
        public async Task<IEnumerable<Assignment>> GetAsync()
        {
            return await context.Assignments.Where(e => e.EndDate == null).ToListAsync();
        }
    }
}
