using Heartify.Core.Contracts;
using Heartify.Core.Models.PersonProfile;
using Heartify.Infrastructure.Data.Common;
using HeartifyDating.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Heartify.Core.Services
{
    public class DatingService : IDatingService
    {
        private readonly IRepository repository;

        public DatingService(IRepository _repository)
        {
            repository = _repository;
        }


        public async Task<IEnumerable<PersonProfileInfoViewModel>> GetNeededProfilesForInspectionAsync(string userId)
        {
            var currentUserProfile = await repository.AllReadOnly<PersonProfile>()
                    .Where(pp => pp.IsApproved)
                    .FirstOrDefaultAsync(pp => pp.DaterId == userId);

            var model = await repository.AllReadOnly<PersonProfile>()
                .Where(pp => pp.IsApproved)
                .Where(pp => pp.GenderId == currentUserProfile.WantedGenderId)
                .Where(pp => pp.DaterId != userId)
                .Select(pp => new PersonProfileInfoViewModel(
                    pp.Id,
                    pp.FirstName,
                    pp.LastName,
                    pp.DateOfBirth,
                    pp.Gender.GenderName,
                    pp.WantedGender.GenderName,
                    pp.Relationship.RelationshipType,
                    /*pp.ProfilePicture,
                    pp.UsernamePicture,
                    pp.RandomPicture,*/
                    pp.Description
                    ))
                .ToListAsync();

            return model ?? null;
        }
    }
}
