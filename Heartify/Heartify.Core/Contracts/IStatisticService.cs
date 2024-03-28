using Heartify.Core.Models.Statistics;

namespace Heartify.Core.Contracts
{
    public interface IStatisticService
    {
        Task<StatisticServiceModel> TotalAsync();
    }
}
