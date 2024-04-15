using Heartify.Core.Models.PersonProfile;
using HeartifyDating.Infrastructure.Data.Models;

namespace Heartify.Core.Contracts
{
    public interface IDatingService
    {
        Task<IEnumerable<PersonProfileInfoViewModel>> GetNeededProfilesAsync(int personProfileId);
    }
}
