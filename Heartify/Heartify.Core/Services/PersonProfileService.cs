using Heartify.Core.Contracts;
using Heartify.Core.Models.Gender;
using Heartify.Core.Models.PersonProfile;
using Heartify.Core.Models.Relationship;
using Heartify.Data.Models;
using Heartify.Infrastructure.Data.Common;
using HeartifyDating.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Heartify.Core.Services
{
    public class PersonProfileService : IPersonProfileService
    {
        private readonly IRepository repository;

        public PersonProfileService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<bool> ExistsByIdReviewedAsync(string userId)
        {
            return await repository.AllReadOnly<PersonProfile>()
                .Where(pp => pp.IsApproved)
                .AnyAsync(pp => pp.DaterId == userId);
        }

		public async Task<bool> ExistsByIdAllAsync(string userId)
		{
			return await repository.AllReadOnly<PersonProfile>()
				.AnyAsync(pp => pp.DaterId == userId);
		}

		public async Task<IEnumerable<GenderViewModel>> AllGenders()
        {
            return await repository.AllReadOnly<Gender>()
                .Select(g => new GenderViewModel
                {
                    Id = g.Id,
                    GenderName = g.GenderName
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<RelationshipViewModel>> AllRelationships()
        {
            return await repository.AllReadOnly<Relationship>()
                .Select(r => new RelationshipViewModel
                {
                    Id = r.Id,
                    RelationshipType = r.RelationshipType
                })
                .ToListAsync();
        }

        public async Task<PersonProfile> GetApprovedProfileByIdAsync(int personProfileId)
        {
                var profile = await repository.All<PersonProfile>()
				    .Where(pp => pp.IsApproved)
					.FirstOrDefaultAsync(pp => pp.Id == personProfileId);

            return profile ?? null;
        }

        public async Task<PersonProfile> GetProfileByUserIdAsync(string userId)
        {
            var profile = await repository.All<PersonProfile>()
                .FirstOrDefaultAsync(pp => pp.DaterId == userId);

            return profile ?? null;
        }

        public async Task<PersonProfile> GetProfileByIdAsync(int personProfileId)
        {
            var profile = await repository.All<PersonProfile>()
                .FirstOrDefaultAsync(pp => pp.Id == personProfileId);

            return profile ?? null;
        }

        public async Task CreateAsync(string firstName,
            string lastName,
            DateTime dateOfBirth,
            int genderId,
            int wantedGenderId,
            int relationshipId,
            string description,
            /*byte[] profilePicture,
            byte[] usernamePicture,
            byte[] randomPicture,*/
            string daterId)
        {
            await repository.AddAsync(new PersonProfile()
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth,
                GenderId = genderId,
                WantedGenderId = wantedGenderId,
                RelationshipId = relationshipId,
                Description = description,
                DaterId = daterId,
                /*ProfilePicture = profilePicture,
				UsernamePicture = usernamePicture,
				RandomPicture = randomPicture*/ 

            });

            await repository.SaveChangesAsync();
        }

        public async Task EditAsync(int personProfileId, PersonProfileFormModel model, DateTime dateOfBirth)
        {
            var personProfile = await repository.GetByIdAsync<PersonProfile>(personProfileId);

            if (personProfile != null)
            {
                personProfile.FirstName = model.FirstName;
                personProfile.LastName = model.LastName;
                personProfile.DateOfBirth = dateOfBirth;
                personProfile.GenderId = model.GenderId;
                personProfile.WantedGenderId = model.WantedGenderId;
                personProfile.RelationshipId = model.RelationshipId;
                personProfile.Description = model.Description;
            }

            await repository.SaveChangesAsync();
        }

        public async Task<PersonProfileInfoViewModel> GetPersonProfileInfoAsync(string userId)
        {
            var profile = await repository.AllReadOnly<PersonProfile>()
				.Where(pp => pp.IsApproved)
				.Where(pp => pp.DaterId == userId)
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
                .FirstOrDefaultAsync();

            return profile ?? null;
        }

        public async Task<DeleteShowInfoPersonProfileModel> GetDeleteInfoAsync(int id)
        {
            var profile =  await repository.AllReadOnly<PersonProfile>()
                .Where(dpp => dpp.Id == id)
				.Where(pp => pp.IsApproved)
				.Select(dpp => new DeleteShowInfoPersonProfileModel()
                {
                    Id = dpp.Id,
                    FirstName = dpp.FirstName,
                })
                .FirstOrDefaultAsync();

            return profile ?? null;
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
                    /*pp.ProfilePicture,
                    pp.UsernamePicture,
                    pp.RandomPicture,*/
                    pp.Description
                    ))
                .ToListAsync();
		}

		public async Task<IEnumerable<PersonProfileInfoViewModel>> GetReviewedUsersAsync()
		{
			return await repository.AllReadOnly<PersonProfile>()
                .Where(pp => pp.IsApproved)
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
		}

        public async Task ApprovePersonProfileAsync(int personProfileId)
        {
            var profile = await GetProfileByIdAsync(personProfileId);

            if (profile != null) 
            {
                profile.IsApproved = true;

                await repository.SaveChangesAsync();
            }
        }

        public async Task DeletePersonProfileAsync(int personProfileId)
        {
            var profile = await GetProfileByIdAsync(personProfileId);

            if (profile != null)
            {
                await repository.DeletePersonProfileAsync<PersonProfile>(personProfileId);

                await repository.SaveChangesAsync();
            }
        }
    }
}