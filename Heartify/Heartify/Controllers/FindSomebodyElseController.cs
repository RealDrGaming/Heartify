using Microsoft.AspNetCore.Mvc;

namespace HeartifyDating.Controllers
{
    public class FindSomebodyElseController : BaseController
    {
        private readonly ILogger<HomeController> logger;

        public FindSomebodyElseController(ILogger<HomeController> _logger)
        {
            logger = _logger;
        }

        public IActionResult FindSomebodyElse()
        {
            return View();
        }
    }
}
