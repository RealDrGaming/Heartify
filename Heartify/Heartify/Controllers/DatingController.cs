using Heartify.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static Heartify.Core.Constants.MessageConstants;

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
                TempData[UserMessageWarning] = "You cannot see profiles until yours is reviewed!";

                return RedirectToAction("CreatePersonProfile", "PersonProfile");
            }



            return View();   
        }
    }
}
