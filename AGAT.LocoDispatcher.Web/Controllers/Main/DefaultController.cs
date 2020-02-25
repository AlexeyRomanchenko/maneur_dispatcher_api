using System;
using System.Collections.Generic;
using AGAT.LocoDispatcher.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace AGAT.LocoDispatcher.Web.Controllers.Main
{
    [Route("api/[controller]")]
    public class DefaultController : ControllerBase
    {
        // GET: api/Default
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Default/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Default
        [HttpPost]
        public IActionResult Post([FromBody]int value)
        {
            if (ModelState.IsValid)
            {
                return Ok(value);
            }
            else 
            {
                return BadRequest();
            }
        }

        // PUT: api/Default/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
