using Heartify.Core.Contracts;
using Heartify.Extensions;
using Microsoft.AspNetCore.Mvc;

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
            if (await personProfile.ExistsByIdReviewedAsync(User.Id()) == false)
            {
                return RedirectToAction("CreatePersonProfile", "PersonProfile");
            }

            return View();   
        }
    }
}
