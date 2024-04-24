using Heartify.Core.Contracts;
using Heartify.Infrastructure.Data.Common;
using HeartifyDating.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Heartify.Core.Services
{
    public class TestingService : ITestingService
    {
        private readonly IRepository repository;

        public TestingService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<PersonProfile> GetProfileByIdAsync(int personProfileId)
        {
            var profile = await repository.GetByIdAsync<PersonProfile>(personProfileId);

            return profile ?? null;
        }

        public async Task<PersonProfile> GetProfileByUserIdAsync(string userId)
        {
            var profile = await repository.All<PersonProfile>()
                .FirstOrDefaultAsync(pp => pp.DaterId == userId);

            return profile ?? null;
        }
    }
}
