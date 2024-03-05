using Heartify.Core.Contracts;
using Heartify.Extensions;
using Heartify.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Heartify.Controllers
{
    public class DatingController : BaseController
    {
        private readonly IPersonProfileService personProfile;

        public DatingController(IPersonProfileService _personProfile)
        {
            personProfile = _personProfile;
        }

        public async Task<IActionResult> FindPerson()
        {
            if (await personProfile.ExistsByIdAsync(User.Id()) == false)
            {
                return RedirectToAction("CreatePersonProfile", "PersonProfile");
            }

            return View();   
        }
    }
}
