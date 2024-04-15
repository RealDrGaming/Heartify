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
        private readonly IDatingService datingService;

        public DatingController(
            IPersonProfileService _personProfile,
            IDatingService _datingService)
        {
            personProfile = _personProfile;
            datingService = _datingService;
        }

        public async Task<IActionResult> FindPerson(int personProfileId)
        {
            if (await personProfile.ExistsByIdReviewedAsync(User.Id()) == false)
            {
                TempData[UserMessageWarning] = "You cannot see other profiles until yours is reviewed!";

                return RedirectToAction("CreatePersonProfile", "PersonProfile");
            }

            var model = new PersonProfilesModel()
            {
                ProfilesArray = await personProfile.GetReviewedUsersAsync().Result.Where(pp => pp.Gender == datingService.GetWantedGender()),
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

        public async Task<IActionResult> Matches()
        {
            return View();
        }

        public async Task<IActionResult> PendingRequests()
        {
            return View();
        }
    }
}