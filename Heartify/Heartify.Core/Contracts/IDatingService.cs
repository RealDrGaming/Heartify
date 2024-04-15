using Heartify.Core.Models.PersonProfile;

namespace Heartify.Core.Contracts
{
    public interface IDatingService
    {
        Task<IEnumerable<PersonProfileInfoViewModel>> GetNeededProfilesForInspectionAsync(string userId);
    }
}
