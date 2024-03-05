using Heartify.Core.Contracts;
using Heartify.Core.Models.PersonProfile;
using Heartify.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
			var model = await personProfile.GetPersonProfileInfoAsync(User.Id());

			return View(model);
		}
	}
}
