using Heartify.Core.Contracts;
using Heartify.Core.Models.Admin;
using Microsoft.AspNetCore.Mvc;

namespace Heartify.Areas.Admin.Controllers
{
    public class PersonProfileController : AdminBaseController
    {
        private readonly IPersonProfileService personProfileService;


        public PersonProfileController(IPersonProfileService _personProfileService)
        {
            personProfileService = _personProfileService;
        }

        public async Task<IActionResult> AllReviewedUsers()
        {
            var model = new PersonProfilesModel()
            {
                ProfilesArray = await personProfileService.GetReviewedUsersAsync(),
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ApproveProfile()
        {
            var model = new PersonProfilesModel()
            {
                ProfilesArray = await personProfileService.GetUserForReviewAsync(),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ApproveProfile(int personProfileId)
        {
            await personProfileService.ApprovePersonProfileAsync(personProfileId);

            return RedirectToAction(nameof(ApproveProfile));
        }
    }
}
