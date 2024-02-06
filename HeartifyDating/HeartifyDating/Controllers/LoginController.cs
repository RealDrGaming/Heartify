using Microsoft.AspNetCore.Mvc;

namespace HeartifyDating.Controllers
{
    public class LoginController : BaseController
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
