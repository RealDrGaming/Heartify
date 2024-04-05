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

		public async Task<IActionResult> ForReview()
		{
			var model = new PersonProfilesModel()
			{
				ProfilesArray = await personProfileService.AllUsersForReview(),
			};

			return View(model);
		}

		public async Task<IActionResult> AllReviewedUsers()
		{
			var model = new PersonProfilesModel()
			{
				ProfilesArray = await personProfileService.AllReviewedUsers(),
			};

			return View(model);
		}
	}
}
