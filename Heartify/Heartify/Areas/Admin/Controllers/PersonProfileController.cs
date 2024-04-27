using Heartify.Core.Contracts;
using Heartify.Core.Models.PersonProfile;
using Microsoft.AspNetCore.Mvc;

namespace Heartify.Areas.Admin.Controllers
{
    public class PersonProfileController : AdminBaseController
    {
        private readonly IAdminService adminService;
        private readonly ISharedService sharedService;

        public PersonProfileController(IAdminService _adminService, ISharedService sharedService)
        {
            adminService = _adminService;
            this.sharedService = sharedService;
        }

        public async Task<IActionResult> AllReviewedUsers()
        {
            var model = new ProfileMatchesModel()
            {
                ProfilesArray = await adminService.GetReviewedUsersAsync(),
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ApproveProfile()
        {
            var model = new PersonProfilesModel()
            {
                ProfilesArray = await adminService.GetUserForReviewAsync(),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ApproveProfile(int personProfileId)
        {
            await adminService.ApprovePersonProfileAsync(personProfileId);

            return RedirectToAction(nameof(ApproveProfile));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int personProfileId)
        {
            await sharedService.DeletePersonProfileAsync(personProfileId);

            return RedirectToAction(nameof(ApproveProfile));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveApprovedProfile(int personProfileId)
        {
            await sharedService.DeletePersonProfileAsync(personProfileId);

            return RedirectToAction(nameof(AllReviewedUsers));
        }
    }
}
