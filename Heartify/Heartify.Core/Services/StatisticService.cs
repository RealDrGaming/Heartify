using Heartify.Core.Contracts;
using Heartify.Core.Models.Statistics;
using Heartify.Infrastructure.Data.Common;
using HeartifyDating.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Heartify.Core.Services
{
    public class StatisticService : IStatisticService
    {
        private readonly IRepository repository;

        public StatisticService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<StatisticServiceModel> TotalAsync()
        {
            int totalUsers = await repository.AllReadOnly<PersonProfile>()
                .Where(pp => pp.IsApproved)
                .CountAsync();

            return new StatisticServiceModel()
            {
                TotalUsers = totalUsers,
            };
        }
    }
}
