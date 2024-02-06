using Microsoft.AspNetCore.Mvc;

namespace HeartifyDating.Controllers
{
    public class RegisterController : BaseController
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
