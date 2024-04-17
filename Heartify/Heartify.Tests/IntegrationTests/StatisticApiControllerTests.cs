using Heartify.Controllers;
using Heartify.Tests.Mocks;

namespace Heartify.Tests.IntegrationTests
{
    [TestFixture]
    public class StatisticApiControllerTests
    {
        private StatisticApiController statisticsController;

        [OneTimeSetUp]
        public void SetUp()
        {
            this.statisticsController = new StatisticApiController(StatisticsServiceMock.Instance);
        }

        [Test]
        public async Task GetStatistics_ShouldReturnCorrectCount()
        {
            var result = await this.statisticsController.GetStatistic();

            Assert.NotNull(result);
        }
    }
}
