using Heartify.Core.Contracts;
using Heartify.Core.Models.Admin;
using Heartify.Core.Models.PersonProfile;
using Heartify.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using static Heartify.Core.Constants.UserConstants;

namespace Heartify.Controllers
{
    public class ReturnerController : BaseController
    {
        private readonly IPersonProfileService personProfile;

        public ReturnerController(IPersonProfileService _personProfile)
        {
            personProfile = _personProfile;
        }

        public async Task<IActionResult> PersonProfileInfo()
		{
            if (await personProfile.ExistsByIdReviewedAsync(User.Id()))
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
