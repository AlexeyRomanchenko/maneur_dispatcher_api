using AGAT.LocoDispatcher.AsusData.Models;
using AGAT.LocoDispatcher.AsusData.Repository;
using AGAT.LocoDispatcher.Business.Config;
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
        public async Task<IEnumerable<Models.AssignmentModels.Assignment>> GetAsync()
        {
            var _assignments =  await repository.GetActiveAsync();
            IEnumerable<Models.AssignmentModels.Assignment> assignments = 
                Mapper.GetMapperInstance().Map<IEnumerable<Models.AssignmentModels.Assignment>>(_assignments);
            return assignments;
        }
    }
}
