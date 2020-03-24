using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AGAT.LocoDispatcher.Business.Classes;
using AGAT.LocoDispatcher.Business.Models.RailsModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AGAT.LocoDispatcher.Web.Controllers.Rails
{
    [Route("api/[controller]")]
    [ApiController]
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
            return new string[] { "value1", "value2" };
        }

        // GET: api/Rails/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Rails
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Rails/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Rail rail)
        {
            
            _railsManager.CreateRail(id,rail);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
