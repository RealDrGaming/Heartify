using Microsoft.AspNetCore.Mvc;

namespace HeartifyDating.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
