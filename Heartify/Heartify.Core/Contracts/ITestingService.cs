using HeartifyDating.Infrastructure.Data.Models;

namespace Heartify.Core.Contracts
{
    public interface ITestingService
    {
        Task<PersonProfile> GetProfileByIdAsync(int personProfileId);

        Task<PersonProfile> GetProfileByUserIdAsync(string userId);
    }
}
