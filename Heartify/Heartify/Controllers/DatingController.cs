using Heartify.Data;
using Heartify.Models;
using HeartifyDating.Core.Models;
using HeartifyDating.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Heartify.Controllers
{
    public class DatingController : BaseController
    {
		private readonly HeartifyDbContext data;

        public DatingController(HeartifyDbContext context)
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
				Age = model.Age,
				GenderId = model.GenderId,
				WantedGenderId = model.WantedGenderId,
				RelationshipId = model.RelationshipId,
				Description = model.Description,
				ProfileImage = model.ProfileImage,
				UsernamePicture = model.UsernamePicture,
				RandomPicture = model.RandomPicture,
			};

			await data.PersonProfiles.AddAsync(entity);
			await data.SaveChangesAsync();

			return RedirectToAction(nameof(FindSomebodyElse));
		}

		public IActionResult FindSomebodyElse()
        {
            return View();
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
				.Select(g => new RelationshipViewModel
				{
					Id = g.Id,
					RelationshipType = g.RelationshipType
				})
				.ToListAsync();
		}
	}
}
