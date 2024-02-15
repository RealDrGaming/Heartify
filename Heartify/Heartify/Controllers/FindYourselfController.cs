using Microsoft.AspNetCore.Mvc;

namespace HeartifyDating.Controllers
{
    public class FindYourselfController : BaseController
    {
        private readonly ILogger<HomeController> logger;

        public FindYourselfController(ILogger<HomeController> _logger)
        {
            logger = _logger;
        }

        public IActionResult FindYourself()
        {
            return View();
        }
    }
}
