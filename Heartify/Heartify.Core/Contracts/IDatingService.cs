using Heartify.Core.Models.PersonProfile;

namespace Heartify.Core.Contracts
{
    public interface IDatingService
    {
        Task<IEnumerable<PersonProfileInfoViewModel>> GetNeededProfilesForInspectionAsync(string userId);

        Task LikeProfileAsync(string userId, int personProfileId);

        Task DeclineProfileAsync(string userId, int personProfileId);

        Task<IEnumerable<PersonProfileInfoViewModel>> GetPendingRequests(string userId);
    }
}
