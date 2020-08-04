using AGAT.LocoDispatcher.AsusData.Models;
using AGAT.LocoDispatcher.AsusData.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Business.Classes.Managers
{
    public class AssignmentManager
    {
        private AssignmentRepository repository;
        public AssignmentManager()
        {
            repository = new AssignmentRepository();
        }
        public async Task<IEnumerable<Assignment>> GetAsync()
        {
            return await repository.GetAsync();
        }
    }
}
