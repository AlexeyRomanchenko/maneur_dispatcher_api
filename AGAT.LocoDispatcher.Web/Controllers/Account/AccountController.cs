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
            UserViewModel viewModel = new UserViewModel 
            {
            Username = "Alex",
            Password = "0404"
            };
            this.Login(viewModel);
            return Ok(viewModel);
        }
        [HttpPost]
        public IActionResult Login(UserViewModel user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpPost]
        public bool Logout()
        {
            return true;
        }
    }
}