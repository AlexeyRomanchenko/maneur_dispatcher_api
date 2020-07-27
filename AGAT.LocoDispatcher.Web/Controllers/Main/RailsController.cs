using System;
using System.Collections.Generic;
using AGAT.LocoDispatcher.Business.Classes;
using AGAT.LocoDispatcher.Business.Models.RailsModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AGAT.LocoDispatcher.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RailsController : ControllerBase
    {
        RailsManager _railsManager;
        public RailsController(RailsManager railsManager)
        {
            _railsManager =railsManager;
        }

        [HttpGet("{id}")]
        [Authorize]
        public IEnumerable<Rail> Get(int id)
        {
            if (id > 0)
            {
                try
                {
                    var rails = _railsManager.GetRailsByParkId(id);
                    return rails;
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
