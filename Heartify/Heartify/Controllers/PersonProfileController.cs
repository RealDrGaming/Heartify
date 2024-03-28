using Heartify.Core.Contracts;
using Heartify.Core.Models.Gender;
using Heartify.Core.Models.PersonProfile;
using Heartify.Core.Models.Relationship;
using Heartify.Extensions;
using Heartify.Infrastructure.Constants;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace Heartify.Controllers
{
    public class PersonProfileController : BaseController
    {
        private readonly IPersonProfileService personProfile;

        public PersonProfileController(IPersonProfileService _personProfile)
        {
            personProfile = _personProfile;
        }

        [HttpGet]
		public async Task<IActionResult> CreatePersonProfile()
		{
            if (await personProfile.ExistsByIdAsync(User.Id()))
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

			return RedirectToAction(nameof(CreatePersonProfile));
		}

        [HttpGet]
        public async Task<IActionResult> EditPersonProfile(int id)
        {
            var pp = await personProfile.GetPersonProfileByIdAsync(id);

            if (pp == null)
            {
                return BadRequest();
            }

            var model = new PersonProfileFormModel()
            {
                FirstName = pp.FirstName,
                LastName = pp.LastName,
                DateOfBirth = pp.DateOfBirth.ToString(ValidationConstants.DateFormat),
                GenderId = pp.GenderId,
                WantedGenderId = pp.WantedGenderId,
                RelationshipId = pp.RelationshipId,
                Description = pp.Description
            };

            model.Genders = await GetGenders();
            model.Relationships = await GetRelationships();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditPersonProfile(PersonProfileFormModel model, int id)
        {
            var pp = await personProfile.GetPersonProfileByIdAsync(id);

            if (pp == null)
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

            await personProfile.EditAsync(pp, model, dateOfBirth);

            return RedirectToAction(nameof(CreatePersonProfile));
        }

        public async Task<IActionResult> DeletePersonProfile(int id)
        {
            var pp = await personProfile.GetPersonProfileByIdAsync(id);

            if (pp == null)
            {
                return BadRequest();
            }

            var model = await personProfile.GetDeleteInfoAsync(id);

            if (model == null)
            {
                return BadRequest();
            }

            return View(model);
        }

        public async Task<IActionResult> DeletePersonProfileConfirmed(int id)
        {
            var pp = await personProfile.GetPersonProfileByIdAsync(id);

            if (pp == null)
            {
                return BadRequest();
            }

            personProfile.DeleteAsync(pp);

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
