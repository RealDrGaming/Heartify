using Heartify.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Heartify.Controllers
{
    public class DatingController : BaseController
    {
        private readonly HeartifyDbContext data;

        public DatingController(HeartifyDbContext context)
        {
            data = context;
        }

        public IActionResult FindPerson()
        {
            if (!data.PersonProfiles.Any(pp => pp.DaterId == GetUserId()))
            {
                return RedirectToAction("CreatePersonProfile", "PersonProfile");
            }

            return View();   
        }

        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }
    }
}
