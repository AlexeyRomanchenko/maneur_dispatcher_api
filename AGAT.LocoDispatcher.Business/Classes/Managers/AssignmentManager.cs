using AGAT.LocoDispatcher.AsusData.Models;
using AGAT.LocoDispatcher.AsusData.Repository;
using AGAT.LocoDispatcher.Business.Config;
using System;
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

        public async Task<IEnumerable<Models.AssignmentModels.Assignment>> GetByCodeAsync(string code)
        {
            try
            {
                if (string.IsNullOrEmpty(code?.Trim()))
                {
                    throw new ArgumentNullException("Код станции неопознан");
                }

                var _assignments = await repository.GetActiveByStationCodeAsync(code);
                IEnumerable<Models.AssignmentModels.Assignment> assignments =
                    Mapper.GetMapperInstance().Map<IEnumerable<Models.AssignmentModels.Assignment>>(_assignments);
                return assignments;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
