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
        public IActionResult Get(int id)
        {
            try
            {
                if (id > 0)
                {
                    IEnumerable<Route> routes = _routesManager.GetRoutesByParkId(id);
                    return Ok(routes);
                }
                else
                {
                    throw new ArgumentNullException("Нераспознан код");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }   
        }
    }
}