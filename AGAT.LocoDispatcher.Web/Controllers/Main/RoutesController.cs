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
        [HttpGet("{station}")]
        public async Task<IActionResult> Get(string station)
        {
            try
            {
                string code = HttpContext.Request.Query["code"];
                if (!string.IsNullOrEmpty(station?.Trim()) && !string.IsNullOrEmpty(code?.Trim()))
                {
                    IEnumerable<Route> routes = await _routesManager.GetRoutesByParkCodeAsync(station, code);
                    return Ok(routes);
                }
                else
                {
                    throw new ArgumentNullException("Нераспознан код станции или парка");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }   
        }
    }
}