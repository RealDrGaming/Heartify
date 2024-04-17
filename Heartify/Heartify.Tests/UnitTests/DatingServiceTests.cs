using Heartify.Core.Contracts;
using Heartify.Core.Services;
using Heartify.Infrastructure.Data.Common;
using HeartifyDating.Infrastructure.Data.Models;

namespace Heartify.Tests.UnitTests
{
    [TestFixture]
    public class DatingServiceTests : UnitTestsBase
    {
        private IDatingService datingService;

        [OneTimeSetUp]
        public void SetUp()
        {
            datingService = new DatingService(repository);
        }

        [Test]
        public async Task GetNeededProfilesForInspection_WorksCorrectly()
        {
            
        }
    }
}
