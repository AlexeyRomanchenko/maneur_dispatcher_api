using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AGAT.LocoDispatcher.AsusData.Models;
using AGAT.LocoDispatcher.AsusData.Repository;
using AGAT.LocoDispatcher.Business.Config;
using AGAT.LocoDispatcher.Data.Classes.Repository;

namespace AGAT.LocoDispatcher.Business.Classes.Managers
{
    public class RoutesManager
    {
        private RouteRepository _routeRepository;
        private StationParkRepository _parkRepository;
        public RoutesManager()
        {
            _routeRepository = new RouteRepository();
            _parkRepository = new StationParkRepository();
        }

        public async Task<IEnumerable<Models.RouteModels.Route>> GetRoutesByParkCodeAsync(string station, string code)
        {
            StationPark park = await _parkRepository.GetParkByStationAndCodeAsync(station, code);
            if (park is null)
            {
                throw new ArgumentException($"Парк {code} станции {station}  не был найден");
            }
           IList<Route> routesDTO = _routeRepository.GetByCode(park.Id, code);
            return Mapper.GetMapperInstance().Map<IEnumerable<Models.RouteModels.Route>>(routesDTO);
        }
    }
}
