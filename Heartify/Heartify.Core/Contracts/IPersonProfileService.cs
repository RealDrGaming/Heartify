using Heartify.Core.Models.Gender;
using Heartify.Core.Models.PersonProfile;
using Heartify.Core.Models.Relationship;
using HeartifyDating.Infrastructure.Data.Models;

namespace Heartify.Core.Contracts
{
    public interface IPersonProfileService
    {
        Task<bool> ExistsByIdReviewedAsync(string userId);
		Task<bool> ExistsByIdAllAsync(string userId);

		Task<PersonProfile> GetApprovedProfileByIdAsync(int personProfileId);

        Task<PersonProfile> GetProfileApproveProfileByIdAsync(int personProfileId);

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

        Task<IEnumerable<PersonProfileInfoViewModel>> GetUserForReviewAsync();

		Task<IEnumerable<PersonProfileInfoViewModel>> GetReviewedUsersAsync();

        Task ApprovePersonProfileAsync(int personProfileId);
	}
}