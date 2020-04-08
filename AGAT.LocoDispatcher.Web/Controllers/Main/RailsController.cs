using System;
using System.Collections.Generic;
using System.Net.Mime;
using AGAT.LocoDispatcher.Business.Classes;
using AGAT.LocoDispatcher.Business.Models.RailsModels;
using Microsoft.AspNetCore.Mvc;

namespace AGAT.LocoDispatcher.Web.Controllers
{
    [Produces(MediaTypeNames.Application.Json)]
    [ApiController]
    [Route("api/[controller]")]
    public class RailsController : ControllerBase
    {
        RailsManager _railsManager;
        public RailsController(RailsManager railsManager)
        {
            _railsManager =railsManager;
        }
        // GET: api/Rails
        [HttpGet]
        public StatusCodeResult Get()
        {
            return StatusCode(404);
        }
        [HttpGet("{id}")]
        public IEnumerable<Rail> Get(int id)
        {
            if (id > 0)
            {
                try
                {
                    return _railsManager.GetRailsByStationId(id);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                throw new ArgumentNullException("id is not valid");
            }
        }

        // PUT: api/Rails/5
        [HttpPut("{id}")]
        public StatusCodeResult Put(int id, [FromBody] List<Rail> rails)
        {
            try
            {
                foreach (Rail rail in rails)
                {
                    _railsManager.CreateRail(id, rail);                    
                }
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                throw ex;
            }          
        }
    }
}
