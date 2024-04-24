using Heartify.Core.Contracts;
using Heartify.Core.Models.Gender;
using Heartify.Core.Models.PersonProfile;
using Heartify.Core.Models.Relationship;
using Heartify.Infrastructure.Data.Constants;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Security.Claims;
using static Heartify.Core.Constants.MessageConstants;
using static Heartify.Infrastructure.Data.Constants.ValidationConstants;

namespace Heartify.Controllers
{
    public class PersonProfileController : BaseController
    {
        private readonly IPersonProfileService personProfile;
        private readonly ISharedService sharedService;

        public PersonProfileController(IPersonProfileService _personProfile, ISharedService _sharedService)
        {
            personProfile = _personProfile;
            sharedService = _sharedService;
        }

        [HttpGet]
		public async Task<IActionResult> CreatePersonProfile()
		{
            if (await sharedService.ExistsByIdAllAsync(User.Id()))
            {
				return RedirectToAction("PersonProfileInfo", "Returner");
            }

			var model = new PersonProfileFormModel();
			model.Genders = await GetGenders();
			model.Relationships = await GetRelationships();

			return View(model);
		}

        [HttpPost]
		public async Task<IActionResult> CreatePersonProfile(PersonProfileFormModel model)
		{
            DateTime dateOfBirth = DateTime.Now;

            if (!DateTime.TryParseExact(
                model.DateOfBirth,
                ValidationConstants.DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dateOfBirth))
            {
                ModelState.AddModelError(nameof(model.DateOfBirth), $"Invalid date! Format must be: {ValidationConstants.DateFormat}");
            }

            if (!ModelState.IsValid)
			{
				model.Genders = await GetGenders();
                model.Relationships = await GetRelationships();

				return View(model);
			}

            await personProfile.CreateAsync(
                model.FirstName,
                model.LastName,
                dateOfBirth,
                model.GenderId,
                model.WantedGenderId,
                model.RelationshipId,
                model.Description,
                User.Id());

            return RedirectToAction("PersonProfileInfo", "Returner");
        }

        [HttpGet]
        public async Task<IActionResult> EditPersonProfile(int personProfileId)
        {
            var pp = await personProfile.GetProfileByIdApprovedAsync(personProfileId);

            if (pp == null)
            {
                return BadRequest();
            }

            if (pp.DaterId != User.Id())
            {
                return BadRequest();
            }

            var model = new PersonProfileFormModel()
            {
                FirstName = pp.FirstName,
                LastName = pp.LastName,
                DateOfBirth = pp.DateOfBirth.ToString(DateFormat),
                GenderId = pp.GenderId,
                WantedGenderId = pp.WantedGenderId,
                RelationshipId = pp.RelationshipId,
                Description = pp.Description,
                
            };

            model.Genders = await GetGenders();
            model.Relationships = await GetRelationships();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditPersonProfile(PersonProfileFormModel model, int personProfileId)
        {
            var pp = await personProfile.GetProfileByIdApprovedAsync(personProfileId);

            if (pp == null)
            {
                return BadRequest();
            }

            if (pp.DaterId != User.Id())
            {
                return BadRequest();
            }

            DateTime dateOfBirth = DateTime.Now;

            if (!DateTime.TryParseExact(
                model.DateOfBirth,
                ValidationConstants.DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dateOfBirth))
            {
                ModelState.AddModelError(nameof(model.DateOfBirth), $"Invalid date! Format must be: {ValidationConstants.DateFormat}");
            }

            if (!ModelState.IsValid)
            {
                model.Genders = await GetGenders();
                model.Relationships = await GetRelationships();

                return View(model);
            }

            await personProfile.EditAsync(personProfileId, model, dateOfBirth);

            return RedirectToAction(nameof(CreatePersonProfile));
        }

        [HttpGet]
        public async Task<IActionResult> DeletePersonProfile(int personProfileId)
        {
            var pp = await personProfile.GetProfileByIdApprovedAsync(personProfileId);

            if (pp == null)
            {
                return BadRequest();
            }

            if (pp.DaterId != User.Id())
            {
                return BadRequest();
            }

            var model = await personProfile.GetDeleteInfoAsync(personProfileId);

            if (model == null)
            {
                return BadRequest();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePersonProfileConfirmed(int personProfileId)
        {
            var pp = await personProfile.GetProfileByIdApprovedAsync(personProfileId);

            if (pp == null)
            {
                return BadRequest();
            }

            if (pp.DaterId != User.Id())
            {
                return BadRequest();
            }

            await sharedService.DeletePersonProfileAsync(personProfileId);

            TempData[UserMessageError] = "Dating profile deleted!";

            return RedirectToAction(nameof(CreatePersonProfile));
        }

		private async Task<IEnumerable<GenderViewModel>> GetGenders()
		{
            return await personProfile.AllGenders();
		}

		private async Task<IEnumerable<RelationshipViewModel>> GetRelationships()
		{
            return await personProfile.AllRelationships();
		}
    }
}
