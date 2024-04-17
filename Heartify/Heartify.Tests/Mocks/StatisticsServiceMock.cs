using Heartify.Core.Contracts;
using Heartify.Core.Models.Statistics;
using Moq;

namespace Heartify.Tests.Mocks
{
    public class StatisticsServiceMock
    {
        public static IStatisticService Instance
        {
            get
            {
                var statisticsServiceMock = new Mock<IStatisticService>();

                statisticsServiceMock
                    .Setup(s => s.TotalAsync())
                    .ReturnsAsync(new StatisticServiceModel()
                {
                    TotalUsers = 3,
                });

                return statisticsServiceMock.Object;
            }
        }
    }
}
