using Heartify.Core.Models.Gender;
using Heartify.Core.Models.PersonProfile;
using Heartify.Core.Models.Relationship;
using HeartifyDating.Infrastructure.Data.Models;

namespace Heartify.Core.Contracts
{
    public interface IPersonProfileService
    {
        Task<PersonProfile> GetProfileByIdApprovedAsync(int personProfileId);

        Task<IEnumerable<GenderViewModel>> AllGenders();

        Task<IEnumerable<RelationshipViewModel>> AllRelationships();

        Task CreateAsync(string firstName,
            string lastName,
            DateTime dateOfBirth,
            int genderId,
            int wantedGenderId,
            int relationshipId,
            string description,
            string daterId);

        Task EditAsync(int personProfileToEdit, PersonProfileFormModel model, DateTime dateOfBirth);

        Task<PersonProfileInfoViewModel> GetPersonProfileInfoAsync(string userId);

        Task<DeleteShowInfoPersonProfileModel> GetDeleteInfoAsync(int personProfileId);
    }
}