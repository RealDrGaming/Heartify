using Heartify.Core.Models;
using Heartify.Infrastructure.Constants;
using Heartify.Infrastructure.Data;
using HeartifyDating.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Security.Claims;

namespace Heartify.Controllers
{
	public class PersonProfileController : BaseController
    {
		private readonly HeartifyDbContext data;

        public PersonProfileController(HeartifyDbContext context)
        {
			data = context;
        }

		[HttpGet]
		public async Task<IActionResult> CreatePersonProfile()
		{
            if (data.PersonProfiles.Any(pp => pp.DaterId == GetUserId()))
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

			var entity = new PersonProfile()
			{
				FirstName = model.FirstName,
				LastName = model.LastName,
				DateOfBirth = dateOfBirth,
				GenderId = model.GenderId,
				WantedGenderId = model.WantedGenderId,
				RelationshipId = model.RelationshipId,
				Description = model.Description,
                DaterId = GetUserId(),
                /*ProfileImage = model.ProfileImage,
				UsernamePicture = model.UsernamePicture,
				RandomPicture = model.RandomPicture */
				
			};

			await data.PersonProfiles.AddAsync(entity);
			await data.SaveChangesAsync();

			return RedirectToAction(nameof(CreatePersonProfile));
		}

        [HttpGet]
        public async Task<IActionResult> EditPersonProfile(int id)
        {
            var pp = await data.PersonProfiles.FindAsync(id);

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
            var pp = await data.PersonProfiles.FindAsync(id);

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

            pp.FirstName = model.FirstName;
            pp.LastName = model.LastName;
            pp.DateOfBirth = dateOfBirth;
            pp.GenderId = model.GenderId;
            pp.WantedGenderId = model.WantedGenderId;
            pp.RelationshipId = model.RelationshipId;
            pp.Description = model.Description;

            await data.SaveChangesAsync();

            return RedirectToAction(nameof(CreatePersonProfile));
        }

        public async Task<IActionResult> DeletePersonProfile(int id)
        {
            var pp = await data.PersonProfiles.FindAsync(id);

            if (pp == null)
            {
                return BadRequest();
            }

            var model = await data.PersonProfiles
                .Where(dpp => dpp.Id == id)
                .AsNoTracking()
                .Select(dpp => new DeleteShowInfoPersonProfileModel()
                {
                    Id = dpp.Id,
                    FirstName = dpp.FirstName,
                })
                .FirstOrDefaultAsync();

            if (model == null)
            {
                return BadRequest();
            }

            return View(model);
        }

        public async Task<IActionResult> DeletePersonProfileConfirmed(int id)
        {
            var pp = await data.PersonProfiles.FindAsync(id);

            if (pp == null)
            {
                return BadRequest();
            }

            data.PersonProfiles.Remove(pp);
            await data.SaveChangesAsync();

            return RedirectToAction(nameof(CreatePersonProfile));
        }

        private string GetUserId()
		{
			return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
		}

		private async Task<IEnumerable<GenderViewModel>> GetGenders()
		{
			return await data.Genders
				.AsNoTracking()
				.Select(g => new GenderViewModel
				{
					Id = g.Id,
					GenderName = g.GenderName
				})
				.ToListAsync();
		}

		private async Task<IEnumerable<RelationshipViewModel>> GetRelationships()
		{
			return await data.Relationships
				.AsNoTracking()
				.Select(r => new RelationshipViewModel
				{
					Id = r.Id,
					RelationshipType = r.RelationshipType
				})
				.ToListAsync();
		}
	}
}
