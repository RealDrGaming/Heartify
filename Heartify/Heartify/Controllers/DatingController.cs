using Heartify.Data;
using HeartifyDating.Core.Models;
using HeartifyDating.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;

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
		public IActionResult FindYourself()
		{
			var model = new PersonProfileFormModel();

			return View(model);
		}

        [HttpPost]
		public async Task<IActionResult> FindYourself(PersonProfileFormModel model)
		{
			var entity = new PersonProfile()
			{
				FirstName = model.FirstName,
				LastName = model.LastName,
				Age = model.Age,
				Gender = model.Gender,
				WantedGender = model.WantedGender,
				RelationshipType = model.RelationshipType,
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
    }
}
