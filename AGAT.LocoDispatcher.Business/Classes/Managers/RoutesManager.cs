using System;
using System.Collections.Generic;
using System.Text;
using AGAT.LocoDispatcher.AsusData.Models;
using AGAT.LocoDispatcher.AsusData.Repository;
using AGAT.LocoDispatcher.Business.Config;
using AGAT.LocoDispatcher.Data.Classes.Repository;

namespace AGAT.LocoDispatcher.Business.Classes.Managers
{
    public class RoutesManager
    {
        private RouteRepository _routeRepository;
        public RoutesManager()
        {
            _routeRepository = new RouteRepository();
        }

        public IEnumerable<Models.RouteModels.Route> GetRoutesByParkId(int id)
        {
           IList<Route> routesDTO = _routeRepository.GetById(id);
            return Mapper.GetMapperInstance().Map<IEnumerable<Models.RouteModels.Route>>(routesDTO);
        }
    }
}
