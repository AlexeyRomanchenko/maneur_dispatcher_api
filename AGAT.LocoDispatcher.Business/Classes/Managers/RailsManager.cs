using AGAT.LocoDispatcher.Business.Config;
using AGAT.LocoDispatcher.Business.Models.RailsModels;
using AGAT.LocoDispatcher.Data.Classes.Repository;
using AGAT.LocoDispatcher.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace AGAT.LocoDispatcher.Business.Classes
{
    public class RailsManager
    {
        RailsRepository _repository;
        public RailsManager()
        {
            _repository = new RailsRepository();
        }
        public IEnumerable<Rail> GetRailsByStationId(int id)
        {
            IEnumerable<Data.Models.Rails.Rail> _rails = _repository.GetById(id);
            return Mapper.GetMapperInstance().Map<IEnumerable<Rail>>(_rails);
        }

        public void CreateRail(int stationId, Rail rail)
        {
            Data.Models.Rails.Rail railDbo = Mapper.GetMapperInstance().Map<Data.Models.Rails.Rail>(rail);
            railDbo.StationId = stationId;
            _repository.Create(railDbo);
        }
    }
}
