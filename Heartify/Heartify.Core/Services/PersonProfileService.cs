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

        public async Task<bool> ExistsByIdAsync(string userId)
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

        public async Task<PersonProfile> GetPersonProfileByIdAsync(int personProfileId)
        {
            return await repository.All<PersonProfile>()
                .FirstOrDefaultAsync(pp => pp.Id == personProfileId);
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
                /*ProfileImage = model.ProfileImage,
				UsernamePicture = model.UsernamePicture,
				RandomPicture = model.RandomPicture */

            });

            await repository.SaveChangesAsync();
        }

        public async Task EditAsync(PersonProfile personProfileToEdit, PersonProfileFormModel model, DateTime dateOfBirth)
        {
            personProfileToEdit.FirstName = model.FirstName;
            personProfileToEdit.LastName = model.LastName;
            personProfileToEdit.DateOfBirth = dateOfBirth;
            personProfileToEdit.GenderId = model.GenderId;
            personProfileToEdit.WantedGenderId = model.WantedGenderId;
            personProfileToEdit.RelationshipId = model.RelationshipId;
            personProfileToEdit.Description = model.Description;

            repository.Edit(personProfileToEdit);
            await repository.SaveChangesAsync();
        }

        public async Task<PersonProfileInfoViewModel> GetPersonProfileInfoAsync(string userId)
        {
            return await repository.AllReadOnly<PersonProfile>()
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
        }

        public async Task<DeleteShowInfoPersonProfileModel> GetDeleteInfoAsync(int id)
        {
            return await repository.AllReadOnly<PersonProfile>()
                .Where(dpp => dpp.Id == id)
                .Select(dpp => new DeleteShowInfoPersonProfileModel()
                {
                    Id = dpp.Id,
                    FirstName = dpp.FirstName,
                })
                .FirstOrDefaultAsync();
        }

        public void DeleteAsync(PersonProfile personProfileToDelete)
        {
            repository.Delete(personProfileToDelete);
            repository.SaveChangesAsync();
        }
    }
}