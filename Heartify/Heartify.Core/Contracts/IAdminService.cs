using Heartify.Core.Models.PersonProfile;

namespace Heartify.Core.Contracts
{
    public interface IAdminService
    {
        Task<IEnumerable<PersonProfileInfoViewModel>> GetUserForReviewAsync();

        Task<IEnumerable<PersonProfileInfoViewMatchModel>> GetReviewedUsersAsync();

        Task ApprovePersonProfileAsync(int personProfileId);
    }
}
