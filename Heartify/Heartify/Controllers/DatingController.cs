using Heartify.Core.Contracts;
using Heartify.Core.Models.PersonProfile;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static Heartify.Core.Constants.MessageConstants;

namespace Heartify.Controllers
{
    public class DatingController : BaseController
    {
        private readonly IDatingService datingService;
        private readonly ISharedService sharedService;

        public DatingController(IDatingService _datingService, ISharedService _sharedService)
        {
            datingService = _datingService;
            sharedService = _sharedService;
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

            var model = new ProfileMatchesModel()
            {
                ProfilesArray = await datingService.GetMatches(User.Id()),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Like(int personProfileId)
        {
            await datingService.LikeProfileAsync(User.Id(), personProfileId);

            return RedirectToAction(nameof(People));
        }

        [HttpPost]
        public async Task<IActionResult> LikeBack(int personProfileId)
        {
            await datingService.LikeProfileAsync(User.Id(), personProfileId);

            return RedirectToAction(nameof(PendingRequests));
        }

        [HttpPost]
        public async Task<IActionResult> Decline(int personProfileId)
        {
            await datingService.DeclineProfileAsync(User.Id(), personProfileId);

            return RedirectToAction(nameof(PendingRequests));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveMatch(int personProfileId)
        {
            await datingService.RemoveMatchAsync(User.Id(), personProfileId);

            return RedirectToAction(nameof(Matches));
        }

        private async Task<bool> IsProfileReviewedAsync()
        {
            return await sharedService.ExistsByIdApprovedAsync(User.Id());
        }

        private IActionResult RedirectToCreateProfile()
        {
            TempData[UserMessageWarning] = "You cannot see other profiles until yours is reviewed!";

            return RedirectToAction("CreatePersonProfile", "PersonProfile");
        }
    }
}