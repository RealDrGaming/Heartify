using Heartify.Constants;
using Heartify.Data;
using Heartify.Models;
using HeartifyDating.Core.Models;
using HeartifyDating.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Globalization;
using System.Security.Claims;

namespace Heartify.Controllers
{
    public class FindYourselfController : BaseController
    {
		private readonly HeartifyDbContext data;

        public FindYourselfController(HeartifyDbContext context)
        {
			data = context;
        }

		[HttpGet]
		public async Task<IActionResult> FindYourself()
		{
			var model = new PersonProfileFormModel();
			model.Genders = await GetGenders();
			model.Relationships = await GetRelatioships();

			return View(model);
		}

        [HttpPost]
		public async Task<IActionResult> FindYourself(PersonProfileFormModel model)
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
                model.Relationships = await GetRelatioships();

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

			return RedirectToAction("FindSomebodyElse", "FindSomebodyElse");
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

		private async Task<IEnumerable<RelationshipViewModel>> GetRelatioships()
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
