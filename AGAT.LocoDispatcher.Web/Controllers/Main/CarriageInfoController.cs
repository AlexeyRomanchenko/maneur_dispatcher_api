using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AGAT.LocoDispatcher.Business.Classes.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AGAT.LocoDispatcher.Web.Controllers.Main
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarriageInfoController : ControllerBase
    {
        private CarriageManager _manager;
        public CarriageInfoController(CarriageManager manager)
        {
            _manager = manager;
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var carInformation = _manager.GetCarriageInfoByRouteId(id);
                return Ok(carInformation);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
