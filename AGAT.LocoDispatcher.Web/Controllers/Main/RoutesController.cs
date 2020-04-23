using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AGAT.LocoDispatcher.Business.Classes.Managers;
using AGAT.LocoDispatcher.Business.Models.RouteModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AGAT.LocoDispatcher.Web.Controllers.Main
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutesController : ControllerBase
    {
        private RoutesManager _routesManager;
        public RoutesController(RoutesManager routesManager)
        {
            _routesManager = routesManager;
        }
        [HttpGet("{id}")]
        public IEnumerable<Route> Get(int id)
        {
            if (id > 0)
            {
                return _routesManager.GetRoutesByParkId(id);
            }
            else
            {
                throw new ArgumentNullException("Sorry, code is undefined");
            }
        }
    }
}