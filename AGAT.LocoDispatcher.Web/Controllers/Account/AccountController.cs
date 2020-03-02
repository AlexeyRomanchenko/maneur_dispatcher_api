using AGAT.LocoDispatcher.Web.Filters;
using AGAT.LocoDispatcher.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace AGAT.LocoDispatcher.Web.Controllers.Account
{
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        [HttpGet]
        [SimpleActionFilter(38)]
        public IActionResult Index()
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult Login([FromBody]UserViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(user);
        }
      
        [HttpPost]
        public bool Logout()
        {
            return true;
        }
    }
}