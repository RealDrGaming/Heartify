using Heartify.Data;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Heartify.Controllers
{
    public class FindSomebodyElseController : Controller
    {
        private readonly HeartifyDbContext data;

        public FindSomebodyElseController(HeartifyDbContext context)
        {
            data = context;
        }

        public IActionResult FindSomebodyElse()
        {
            /*
            if (!data.PersonProfiles.Any(pp => pp.DaterId == GetUserId()))
            {
                return RedirectToAction("FindSomebodyElse", "FindSomebodyElse");
            }

            return View();
            */
        }

        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }
    }
}
