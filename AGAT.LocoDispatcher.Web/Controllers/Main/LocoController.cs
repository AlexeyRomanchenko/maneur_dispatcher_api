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
        private PointManager _pointManager;
        public LocoController()
        {
            _pointManager = new PointManager();
        }
        private List<Locomotive> locomotives = new List<Locomotive>
                {
                    new Locomotive
                    {
                        Id = 1,
                        Code = "346",
                        Name = "ВЛ-10",
                        Status = true,
                        Coords = new Coords{X = 20,Y = 200},
                        Speed = 15
                    },
                        new Locomotive
                    {
                        Id = 1,
                        Code = "125",
                        Name = "ВЛ-10",
                        Status = true,
                        Speed = 15
                    }
                };
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                Random rnd = new Random();
                foreach (var loco in locomotives)
                {

                    loco.PointId = rnd.Next(1, 37).ToString();
                    Point point = await _pointManager.GetPointByCode(loco.PointId.ToString());
                    if (point != null)
                    {
                        loco.Coords = point.Coord;
                        loco.Angle = point.Angle;
                    }

                }
                return Ok(locomotives);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                if (id > 0)
                {
                    Random rnd = new Random();
                    var loco = locomotives.Where(e => e.Id == id).FirstOrDefault();
                    loco.PointId = rnd.Next(1, 37).ToString();
                    Point point = await _pointManager.GetPointByCode(loco.PointId.ToString());
                    if (point != null)
                    {
                        loco.Coords = point.Coord;
                        loco.Angle = point.Angle;
                    }
                    return Ok(loco);
                }
                else
                {
                    throw new ArgumentNullException("id is not valid");
                }
            }
            catch (Exception ex)
            { 
                return BadRequest(ex.Message);
            }
        }
    }
}
