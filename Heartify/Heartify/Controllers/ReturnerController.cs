using Heartify.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Heartify.Controllers
{
    public class ReturnerController : BaseController
    {
        private readonly IPersonProfileService personProfile;
        private readonly ISharedService sharedService;

        public ReturnerController(IPersonProfileService _personProfile, ISharedService _sharedService)
        {
            personProfile = _personProfile;
            sharedService = _sharedService;
        }

        public async Task<IActionResult> PersonProfileInfo()
        {
            if (await sharedService.ExistsByIdApprovedAsync(User.Id()))
            {
                var model = await personProfile.GetPersonProfileInfoAsync(User.Id());

                return View(model);
            }

            return RedirectToAction(nameof(WaitingForReview));
        }

        public IActionResult WaitingForReview()
        {
            return View();
        }
    }
}
