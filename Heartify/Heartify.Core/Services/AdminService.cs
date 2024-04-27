using Heartify.Core.Contracts;
using Heartify.Core.Models.PersonProfile;
using Heartify.Infrastructure.Data.Common;
using HeartifyDating.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Heartify.Core.Services
{
    public class AdminService : IAdminService
    {
        private readonly IRepository repository;

        public AdminService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<PersonProfileInfoViewModel>> GetUserForReviewAsync()
        {
            return await repository.AllReadOnly<PersonProfile>()
                .Where(pp => !pp.IsApproved)
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
                .ToListAsync();
        }

        public async Task<IEnumerable<PersonProfileInfoViewMatchModel>> GetReviewedUsersAsync()
        {
            return await repository.AllReadOnly<PersonProfile>()
                .Where(pp => pp.IsApproved)
                .Select(pp => new PersonProfileInfoViewMatchModel(
                    pp.Id,
                    pp.FirstName,
                    pp.LastName,
                    pp.DateOfBirth,
                    pp.Gender.GenderName,
                    pp.WantedGender.GenderName,
                    pp.Relationship.RelationshipType,
                    pp.Description,
                    pp.Dater.Email
                    ))
                .ToListAsync();
        }

        public async Task ApprovePersonProfileAsync(int personProfileId)
        {
            var profile = await repository.GetByIdAsync<PersonProfile>(personProfileId);

            if (profile != null && !profile.IsApproved)
            {
                profile.IsApproved = true;

                await repository.SaveChangesAsync();
            }
        }
    }
}
