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

        public async Task<IActionResult> FindPerson()
        {
            if (!await IsProfileReviewedAsync())
            {
                return RedirectToCreateProfile();
            }

            return View();
        }

        public async Task<IActionResult> People()
        {
            if (!await IsProfileReviewedAsync())
            {
                return RedirectToCreateProfile();
            }

            var model = new PersonProfilesModel()
            {
                ProfilesArray = await datingService.GetNeededProfilesForInspectionAsync(User.Id()),
            };

            return View(model);
        }

        public async Task<IActionResult> PendingRequests()
        {
            if (!await IsProfileReviewedAsync())
            {
                return RedirectToCreateProfile();
            }

            var model = new PersonProfilesModel()
            {
                ProfilesArray = await datingService.GetPendingRequests(User.Id()),
            };

            return View(model);
        }

        public async Task<IActionResult> Matches()
        {
            if (!await IsProfileReviewedAsync())
            {
                return RedirectToCreateProfile();
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Like(int personProfileId)
        {
            await datingService.LikeProfileAsync(User.Id(), personProfileId);

            return RedirectToAction(nameof(People));
        }

        [HttpPost]
        public async Task<IActionResult> Decline(int personProfileId)
        {
            await datingService.DeclineProfileAsync(User.Id(), personProfileId);

            return RedirectToAction(nameof(PendingRequests));
        }

        private async Task<bool> IsProfileReviewedAsync()
        {
            return await personProfile.ExistsByIdReviewedAsync(User.Id());
        }

        private IActionResult RedirectToCreateProfile()
        {
            TempData[UserMessageWarning] = "You cannot see other profiles until yours is reviewed!";
            return RedirectToAction("CreatePersonProfile", "PersonProfile");
        }
    }
}