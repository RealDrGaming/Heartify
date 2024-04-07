using Heartify.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
