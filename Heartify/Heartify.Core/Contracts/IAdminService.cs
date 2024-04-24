using Heartify.Core.Models.PersonProfile;

namespace Heartify.Core.Contracts
{
    public interface IAdminService
    {
        Task<IEnumerable<PersonProfileInfoViewModel>> GetUserForReviewAsync();

        Task<IEnumerable<PersonProfileInfoViewModel>> GetReviewedUsersAsync();

        Task ApprovePersonProfileAsync(int personProfileId);
    }
}
