using Microsoft.AspNetCore.Mvc;

namespace AGAT.LocoDispatcher.Web.AuthServer.Controllers.Account
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
