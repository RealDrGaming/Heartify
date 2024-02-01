using Microsoft.AspNetCore.Mvc;

namespace HeartifyDating.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
