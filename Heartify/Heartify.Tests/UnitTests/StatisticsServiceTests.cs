using Heartify.Core.Contracts;
using Heartify.Core.Services;
using HeartifyDating.Infrastructure.Data.Models;

namespace Heartify.Tests.UnitTests
{
    [TestFixture]
    public class StatisticsServiceTests : UnitTestsBase
    {
        private IStatisticService statisticService;

        [OneTimeSetUp]
        public void SetUp()
        {
            statisticService = new StatisticService(repository);
        }

        [Test]
        public async Task Total_ShouldReturnCorrectCounts()
        {
            var result = await statisticService.TotalAsync();

            Assert.IsNotNull(result);

            var profilesCount = repository.AllReadOnly<PersonProfile>()
                .Where(pp => pp.IsApproved)
                .Count();
            Assert.That(result.TotalUsers, Is.EqualTo(profilesCount));
        }
    }
}
