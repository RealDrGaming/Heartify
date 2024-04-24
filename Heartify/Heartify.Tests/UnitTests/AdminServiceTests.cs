using Heartify.Core.Contracts;
using Heartify.Core.Services;
using System.Globalization;
using static Heartify.Infrastructure.Data.Constants.ValidationConstants;

namespace Heartify.Tests.UnitTests
{
    [TestFixture]
    public class AdminServiceTests : UnitTestsBase
    {
        private IPersonProfileService personProfileService;
        private IAdminService adminService;
        private ITestingService testingService;

        [OneTimeSetUp]
        public void SetUp()
        {
            personProfileService = new PersonProfileService(repository);
            adminService = new AdminService(repository);
            testingService = new TestingService(repository);
        }

        [Test]
        public async Task GetReviewedUsers_WorksCorrectly()
        {
            var dbProfileInfoArray = await adminService.GetReviewedUsersAsync();

            var firstProfileInfo = dbProfileInfoArray.FirstOrDefault();

            Assert.IsNotNull(dbProfileInfoArray);
            Assert.IsNotNull(firstProfileInfo);

            Assert.That(dbProfileInfoArray.Count(), Is.EqualTo(2));

            Assert.That(firstProfileInfo.Id, Is.EqualTo(1));
            Assert.That(firstProfileInfo.FirstName, Is.EqualTo("Yordan"));
            Assert.That(firstProfileInfo.LastName, Is.EqualTo("Neshev"));
            Assert.That(firstProfileInfo.DateOfBirth, Is.EqualTo("12-07-2004"));
            Assert.That(firstProfileInfo.Gender, Is.EqualTo("Male"));
            Assert.That(firstProfileInfo.WantedGender, Is.EqualTo("Female"));
            Assert.That(firstProfileInfo.Relationship, Is.EqualTo("Open"));
            Assert.That(firstProfileInfo.Description, Is.EqualTo("Some discription here"));
        }

        [Test]
        public async Task GetUserForReview_WorksCorrectly()
        {
            var dbProfileInfoArray = await adminService.GetUserForReviewAsync();

            var firstProfileInfo = dbProfileInfoArray.FirstOrDefault();

            Assert.IsNotNull(dbProfileInfoArray);
            Assert.IsNotNull(firstProfileInfo);

            Assert.That(dbProfileInfoArray.Count(), Is.EqualTo(1));

            Assert.That(firstProfileInfo.Id, Is.EqualTo(2));
            Assert.That(firstProfileInfo.FirstName, Is.EqualTo("Ivanka"));
            Assert.That(firstProfileInfo.LastName, Is.EqualTo("Sotirova"));
            Assert.That(firstProfileInfo.DateOfBirth, Is.EqualTo("12-07-2004"));
            Assert.That(firstProfileInfo.Gender, Is.EqualTo("Female"));
            Assert.That(firstProfileInfo.WantedGender, Is.EqualTo("Male"));
            Assert.That(firstProfileInfo.Relationship, Is.EqualTo("Love"));
            Assert.That(firstProfileInfo.Description, Is.EqualTo("some ivanka stuff"));
        }

        [Test]
        public async Task ApprovePersonProfile_WorksCorrectly()
        {
            string deletedProfileId = "fc2b4a2e-0a42-4067-bd8b-1c20b4fb4ba1";

            string date = "12-07-2004";
            DateTime dateOfBirth = DateTime.Now;

            DateTime.TryParseExact(
                date,
                DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dateOfBirth);

            await personProfileService.CreateAsync(
                "Kondio",
                "Curentov",
                dateOfBirth,
                1,
                2,
                3,
                "waiting for approval",
                deletedProfileId
            );

            var dbProfile = await testingService.GetProfileByUserIdAsync(deletedProfileId);

            await adminService.ApprovePersonProfileAsync(dbProfile.Id);

            Assert.That(dbProfile.IsApproved, Is.EqualTo(true));
        }
    }
}
