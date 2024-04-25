using Heartify.Core.Contracts;
using Heartify.Infrastructure.Data.Common;
using HeartifyDating.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Heartify.Core.Services
{
    public class SharedService : ISharedService
    {
        private readonly IRepository repository;

        public SharedService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task DeletePersonProfileAsync(int personProfileId)
        {
            var profile = await repository.GetByIdAsync<PersonProfile>(personProfileId);

            if (profile != null)
            {
                await repository.DeletePersonProfileAsync<PersonProfile>(personProfileId);
                await repository.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsByIdApprovedAsync(string userId)
        {
            return await repository.AllReadOnly<PersonProfile>()
                .Where(pp => pp.IsApproved)
                .AnyAsync(pp => pp.DaterId == userId);
        }

        public async Task<bool> ExistsByIdAllAsync(string userId)
        {
            return await repository.AllReadOnly<PersonProfile>()
                .AnyAsync(pp => pp.DaterId == userId);
        }
    }
}
