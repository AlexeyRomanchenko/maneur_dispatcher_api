using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AGAT.LocoDispatcher.Business.Classes.Managers;
using AGAT.LocoDispatcher.Business.Models.LocoModels;
using AGAT.LocoDispatcher.Business.Models.RailsModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AGAT.LocoDispatcher.Web.Controllers.Main
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocoController : ControllerBase
    {
        private LocoManager _locoManager;
        public LocoController()
        {
            _locoManager = new LocoManager();
        }
        [HttpGet("{station}")]
        public async Task<IActionResult> Get(string station)
        {
            try
            {
                string parkId = HttpContext.Request.Query["parkId"];
                int _parkId = Convert.ToInt32(parkId);
                var locomotives = await _locoManager.GetActiveByStationAsync(station, _parkId);
                return Ok(locomotives);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
