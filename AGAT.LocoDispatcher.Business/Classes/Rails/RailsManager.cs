using AGAT.LocoDispatcher.Business.Config;
using AGAT.LocoDispatcher.Business.Models.RailsModels;
using AGAT.LocoDispatcher.Data.Classes.Repository;
using AGAT.LocoDispatcher.Data.Interfaces;
using System.Collections.Generic;

namespace AGAT.LocoDispatcher.Business.Classes
{
    public class RailsManager
    {
        RailsRepository _repository;
        public RailsManager()
        {
            _repository = new RailsRepository();
        }
        public IEnumerable<Rail> GetRailsScheme()
        {
            IEnumerable<Rail> rails = new List<Rail>();
            return rails;
        }

        public void CreateRail(int stationId, Rail rail)
        {
            Data.Models.Rails.Rail railDbo = Mapper.GetMapperInstance().Map<Data.Models.Rails.Rail>(rail);
            railDbo.StationId = stationId;
            railDbo.RailCode = rail.Id.ToString();
            _repository.Create(railDbo);
        }
    }
}
