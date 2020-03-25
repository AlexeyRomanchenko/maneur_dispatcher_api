using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using AGAT.LocoDispatcher.Business.Classes;
using AGAT.LocoDispatcher.Business.Models.RailsModels;
using Microsoft.AspNetCore.Http;
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
        public IEnumerable<string> Get()
        {
            return new string[] { "rails", "value2" };
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
