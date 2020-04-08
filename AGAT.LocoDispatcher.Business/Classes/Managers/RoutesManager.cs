using System;
using System.Collections.Generic;
using System.Text;
using AGAT.LocoDispatcher.AsusData.Repository;
using AGAT.LocoDispatcher.Data.Classes.Repository;

namespace AGAT.LocoDispatcher.Business.Classes.Managers
{
    public class RoutesManager
    {
        private RouteRepository _routeRepository;
        private StationRepository _stationRepository;
        public RoutesManager()
        {
            _routeRepository = new RouteRepository();
            _stationRepository = new StationRepository();
        }

        public void GetRoutesByStationId(int id)
        {
            _stationRepository.GetStationById(id);
        }
    }
}
