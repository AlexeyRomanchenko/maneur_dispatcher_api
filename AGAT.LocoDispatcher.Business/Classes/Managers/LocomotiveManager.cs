using AGAT.LocoDispatcher.Data.Classes.Repository;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Business.Classes.Managers
{
    public class LocomotiveManager
    {
        private LocomotiveRepository _repository;
        public LocomotiveManager()
        {
            _repository = new LocomotiveRepository();
        }
        public async Task GetLocomotivesAsync()
        {
            await _repository.GetLocomotives();
        }
    }
}
