using System;
using System.Collections.Generic;
using AGAT.LocoDispatcher.Business.Classes.Managers;
using AGAT.LocoDispatcher.Business.Models.RailsModels;
using Microsoft.AspNetCore.Mvc;

namespace AGAT.LocoDispatcher.Web.Controllers.Main
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointController : ControllerBase
    {
        private PointManager _manager;
        public PointController(PointManager manager)
        {
            _manager = manager;
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                IEnumerable<Point> points = _manager.GetPointsByParkId(id);
                return Ok(points);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]List<Point> points)
        {
            try
            {
                foreach (var point in points)
                {
                    _manager.CreatePoints(id, point);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
