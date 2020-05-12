using AGAT.LocoDispatcher.Business.Config;
using AGAT.LocoDispatcher.Business.Models.RailsModels;
using AGAT.LocoDispatcher.Data.Classes.Repository;
using AGAT.LocoDispatcher.Data.Interfaces;
using System;
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
        public IEnumerable<Rail> GetRailsByParkId(int id)
        {
            try
            {
                IEnumerable<Data.Models.Rails.Rail> _rails = _repository.GetById(id);
                var rails = Mapper.GetMapperInstance().Map<IEnumerable<Rail>>(_rails);
                return rails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public void CreateRail(int parkId, Rail rail)
        {
            Data.Models.Rails.Rail railDbo = Mapper.GetMapperInstance().Map<Data.Models.Rails.Rail>(rail);
            railDbo.ParkId = parkId;
            _repository.Create(railDbo);
        }
    }
}
