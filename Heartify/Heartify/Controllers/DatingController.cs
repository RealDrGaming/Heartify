using Heartify.Core.Contracts;
using Heartify.Core.Models.PersonProfile;
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
                TempData[UserMessageWarning] = "You cannot see other profiles until yours is reviewed!";

                return RedirectToAction("CreatePersonProfile", "PersonProfile");
            }

            var model = new PersonProfilesModel()
            {
                ProfilesArray = await personProfile.GetReviewedUsersAsync(),
            };

            return View(model);
        }

        public async Task<IActionResult> Like(int personProfileId) 
        {
            return View();
        }

        public async Task<IActionResult> Decline(int personProfileId)
        {
            return View();
        }
    }
}