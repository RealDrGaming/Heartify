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

        public async Task<PersonProfile> GetProfileByIdApprovedAsync(int personProfileId)
        {
            var profile = await repository.GetByIdAsync<PersonProfile>(personProfileId);

            if (profile != null && profile.IsApproved)
            {
                return profile;
            }

            return null;
        }

        public async Task CreateAsync(string firstName,
            string lastName,
            DateTime dateOfBirth,
            int genderId,
            int wantedGenderId,
            int relationshipId,
            string description,
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

            });

            await repository.SaveChangesAsync();
        }

        public async Task EditAsync(int personProfileId, PersonProfileFormModel model, DateTime dateOfBirth)
        {
            var personProfile = await repository.GetByIdAsync<PersonProfile>(personProfileId);

            if (personProfile != null && personProfile.IsApproved)
            {
                if (personProfile.FirstName != model.FirstName ||
                    personProfile.LastName != model.LastName ||
                    personProfile.DateOfBirth != dateOfBirth ||
                    personProfile.GenderId != model.GenderId ||
                    personProfile.WantedGenderId != model.WantedGenderId ||
                    personProfile.RelationshipId != model.RelationshipId ||
                    personProfile.Description != model.Description)
                {
                    personProfile.FirstName = model.FirstName;
                    personProfile.LastName = model.LastName;
                    personProfile.DateOfBirth = dateOfBirth;
                    personProfile.GenderId = model.GenderId;
                    personProfile.WantedGenderId = model.WantedGenderId;
                    personProfile.RelationshipId = model.RelationshipId;
                    personProfile.Description = model.Description;
                    personProfile.IsApproved = false;

                    await repository.SaveChangesAsync();
                }
            }
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
                    pp.Description
                    ))
                .FirstOrDefaultAsync();

            return profile ?? null;
        }

        public async Task<DeleteShowInfoPersonProfileModel> GetDeleteInfoAsync(int personProfileId)
        {
            var profile = await repository.GetByIdAsync<PersonProfile>(personProfileId);

            if (profile.IsApproved && profile != null)
            {
                var profileDeletionModel = new DeleteShowInfoPersonProfileModel()
                {
                    Id = profile.Id,
                    FirstName = profile.FirstName,
                };

                return profileDeletionModel;
            }

            return null;
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
    }
}