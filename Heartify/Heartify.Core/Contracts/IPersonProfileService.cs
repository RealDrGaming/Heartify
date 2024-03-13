using Heartify.Core.Models.Gender;
using Heartify.Core.Models.PersonProfile;
using Heartify.Core.Models.Relationship;
using HeartifyDating.Infrastructure.Data.Models;

namespace Heartify.Core.Contracts
{
    public interface IPersonProfileService
    {
        Task<bool> ExistsByIdAsync(string userId);

        Task<PersonProfile> GetPersonProfileByIdAsync(int personProfileId);

        Task<IEnumerable<GenderViewModel>> AllGenders();

        Task<IEnumerable<RelationshipViewModel>> AllRelationships();

        Task CreateAsync(string firstName,
            string lastName,
            DateTime dateOfBirth,
            int genderId,
            int wantedGenderId,
            int relationshipId,
            /*byte[] profilePicture,
            byte[] usernamePicture,
            byte[] randomPicture,*/
            string description,
            string daterId);

        Task EditAsync(PersonProfile personProfileToEdit, PersonProfileFormModel model, DateTime dateOfBirth);

        Task<PersonProfileInfoViewModel> GetPersonProfileInfoAsync(string userId);

        Task<DeleteShowInfoPersonProfileModel> GetDeleteInfoAsync(int id);

        void DeleteAsync(PersonProfile personProfileToDelete);
    }
}