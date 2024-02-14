using Microsoft.AspNetCore.Mvc;

namespace HeartifyDating.Controllers
{
    public class FindYourselfController : BaseController
    {
        public IActionResult FindYourself()
        {
            return View();
        }
    }
}
