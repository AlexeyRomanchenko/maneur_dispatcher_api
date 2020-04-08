using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AGAT.LocoDispatcher.Web.Controllers.Main
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutesController : ControllerBase
    {
        [HttpGet("code")]
        public void Get(string code)
        {
            if (String.IsNullOrWhiteSpace(code.Trim()))
            {

            }
            else
            {
                throw new ArgumentNullException("Sorry, code is undefined");
            }
        }
    }
}