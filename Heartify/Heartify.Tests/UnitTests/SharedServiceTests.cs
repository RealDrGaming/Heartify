using Heartify.Core.Contracts;
using Heartify.Core.Services;
using System.Globalization;
using static Heartify.Infrastructure.Data.Constants.ValidationConstants;

namespace Heartify.Tests.UnitTests
{
    [TestFixture]
    public class SharedServiceTests : UnitTestsBase
    {
        private IPersonProfileService personProfileService;
        private ISharedService sharedService;
        private ITestingService testingService;

        [OneTimeSetUp]
        public void SetUp()
        {
            personProfileService = new PersonProfileService(repository);
            sharedService = new SharedService(repository);
            testingService = new TestingService(repository);
        }

        [Test]
        public async Task Delete_WorksCorrectly()
        {
            string deletedProfileId = "200d3874-0ef0-455d-aad8-7989f7b0ebeb";

            string date = "12-07-2004";
            DateTime dateOfBirth = DateTime.Now;

            DateTime.TryParseExact(
                date,
                DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dateOfBirth);

            await personProfileService.CreateAsync(
                "Monio",
                "Qvorov",
                dateOfBirth,
                2,
                2,
                2,
            "finna get deleted anyway",
            deletedProfileId
            );

            var dbProfile = await testingService.GetProfileByUserIdAsync(deletedProfileId);
            await sharedService.DeletePersonProfileAsync(dbProfile.Id);

            var dbProfileInfo = await sharedService.ExistsByIdAllAsync(deletedProfileId);

            Assert.That(dbProfileInfo, Is.EqualTo(false));
        }
    }
}
