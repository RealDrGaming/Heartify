using Microsoft.AspNetCore.Mvc;

namespace Heartify.Areas.Admin.Controllers
{
    public class UserController : AdminBaseController
    {
        public IActionResult All()
        {
            return View();
        }
    }
}
