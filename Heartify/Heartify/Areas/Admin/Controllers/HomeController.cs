using Microsoft.AspNetCore.Mvc;

namespace Heartify.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult Dashboard() 
        {
            return View();
        }
    }
}
