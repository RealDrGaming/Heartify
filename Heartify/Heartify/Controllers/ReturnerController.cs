using Heartify.Core.Models.PersonProfile;
using Heartify.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Heartify.Controllers
{
    public class ReturnerController : BaseController
    {
		private readonly HeartifyDbContext data;

		public ReturnerController(HeartifyDbContext context)
		{
			data = context;
		}

		public async Task<IActionResult> PersonProfileInfo()
		{
			var model = await data.PersonProfiles
				.AsNoTracking()
				.Where(pp => pp.DaterId == GetUserId())
				.Select(pp => new PersonProfileInfoViewModel(
					pp.Id,
					pp.FirstName,
					pp.LastName,
					pp.DateOfBirth,
					pp.Gender.GenderName,
					pp.WantedGender.GenderName,
					pp.Relationship.RelationshipType,
					pp.Description
					))
				.FirstOrDefaultAsync();

			return View(model);
		}

		private string GetUserId()
		{
			return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
		}
	}
}
