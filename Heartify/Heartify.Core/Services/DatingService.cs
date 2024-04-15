using Heartify.Core.Contracts;
using Heartify.Core.Models.PersonProfile;
using Heartify.Infrastructure.Data.Common;
using HeartifyDating.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Heartify.Core.Services
{
    public class DatingService : IDatingService
    {
        private readonly IRepository repository;

        public DatingService(IRepository _repository)
        {
            repository = _repository;
        }


        public async Task<IEnumerable<PersonProfileInfoViewModel>> GetNeededProfilesAsync(int personProfileId)
        {
            var wantedGenderProfile = await repository.AllReadOnly<PersonProfile>()
                    .Where(pp => pp.IsApproved)
                    .FirstOrDefaultAsync(pp => pp.Id == personProfileId);

            var model = await repository.AllReadOnly<PersonProfile>()
                .Where(pp => pp.IsApproved)
                .Where(pp => pp.Gender.GenderName == wantedGenderProfile.WantedGender.GenderName)
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

            return model;
        }
    }
}
