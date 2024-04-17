using Heartify.Core.Contracts;
using Heartify.Core.Models.PersonProfile;
using Heartify.Core.Services;
using Heartify.Infrastructure.Constants;
using Heartify.Tests.UnitTests;
using HeartifyDating.Infrastructure.Data.Models;
using System.Globalization;
using static Heartify.Infrastructure.Constants.ValidationConstants;

namespace Heartify.Tests
{
    [TestFixture]
    public class PersonProfileServiceTests : UnitTestsBase
    {
        private IPersonProfileService personProfileService;

        [OneTimeSetUp]
        public void SetUp()
        {
            personProfileService = new PersonProfileService(repository);
        }

        /*[Test]
        public async Task ExistsByIdReviewed_WorksCorrectly() 
        {
            var doesExist = await personProfileService.ExistsByIdReviewedAsync();
        }

        [Test]
        public async Task ExistsByIdAll_WorksCorrectly()
        {

        }*/

        [Test]
        public async Task AllGenders_WorksCorrectly()
        {
            var genders = await personProfileService.AllGenders();

            Assert.That(genders.Count(), Is.EqualTo(2));
        }

        [Test]
        public async Task AllRelationships_WorksCorrectly()
        {
            var relationships = await personProfileService.AllRelationships();

            Assert.That(relationships.Count(), Is.EqualTo(2));
        }

        [Test]
        public async Task GetProfileIdReviewed_WorksCorrectly()
        {
            var dbProfile1 = await personProfileService.GetApprovedProfileByIdAsync(1);
            var dbProfile2 = await personProfileService.GetApprovedProfileByIdAsync(2);

            Assert.IsNotNull(dbProfile1);
            Assert.That(dbProfile1.Id, Is.EqualTo(1));

            Assert.IsNull(dbProfile2);
        }

        [Test]
        public async Task GetProfileByUserId_WorksCorrectly()
        {
            string someUserId = "ace41288-92e4-4b16-8880-808450fe5388";
            string someNotApprovedUserId = "c78567dd-3be3-41be-ba30-eee36aa7c9db";

            var dbProfile1 = await personProfileService.GetProfileByUserIdAsync(someUserId);
            var dbProfile2 = await personProfileService.GetProfileByUserIdAsync(someNotApprovedUserId);

            Assert.IsNotNull(dbProfile1);
            Assert.That(dbProfile1.Id, Is.EqualTo(1));

            Assert.IsNotNull(dbProfile2);
            Assert.That(dbProfile2.Id, Is.EqualTo(2));
        }

        [Test]
        public async Task GetProfileByIdAll_WorksCorrectly()
        {
            var dbProfile1 = await personProfileService.GetProfileByIdAsync(1);
            var dbProfile2 = await personProfileService.GetProfileByIdAsync(2);

            Assert.IsNotNull(dbProfile1);
            Assert.That(dbProfile1.Id, Is.EqualTo(1));

            Assert.IsNotNull(dbProfile2);
            Assert.That(dbProfile2.Id, Is.EqualTo(2));
        }

        [Test]
        public async Task TestPersonProfileCreated_WorksCorrectly()
        {
            string date = "12-07-2004";
            DateTime dateOfBirth = DateTime.Now;

            DateTime.TryParseExact(
                date,
                DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dateOfBirth);

            await personProfileService.CreateAsync(
                "Yordan",
                "Neshev",
                dateOfBirth,
                1,
                2,
                2,
                "Some discription here",
                "d66a46bb-6a2b-47ed-8c20-06a538f2a250"
            );

            var dbProfile = await personProfileService.GetProfileByUserIdAsync("d66a46bb-6a2b-47ed-8c20-06a538f2a250");

            Assert.IsNotNull(dbProfile);

            Assert.That(dbProfile.FirstName, Is.EqualTo("Yordan"));
            Assert.That(dbProfile.LastName, Is.EqualTo("Neshev"));
            Assert.That(dbProfile.DateOfBirth.ToString(DateFormat), Is.EqualTo("12-07-2004"));
            Assert.That(dbProfile.GenderId, Is.EqualTo(1));
            Assert.That(dbProfile.WantedGenderId, Is.EqualTo(2));
            Assert.That(dbProfile.RelationshipId, Is.EqualTo(2));
            Assert.That(dbProfile.Description, Is.EqualTo("Some discription here"));
        }

        [Test]
        public async Task EditPersonProfile_WorksCorrectly()
        {
            string date = "12-07-2004";
            DateTime dateOfBirth = DateTime.Now;

            DateTime.TryParseExact(
                date,
                DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dateOfBirth);

            var model = new PersonProfileFormModel()
            {
                FirstName = "Petkan",
                LastName = "Georgiev",
                DateOfBirth = date,
                GenderId = 2,
                WantedGenderId = 2,
                RelationshipId = 1,
                Description = "some other discription now"
            };

            await personProfileService.EditAsync(3, model, dateOfBirth);

            var dbProfile = await personProfileService.GetProfileByIdAsync(3);

            Assert.IsNotNull(dbProfile);

            Assert.That(dbProfile.FirstName, Is.EqualTo("Petkan"));
            Assert.That(dbProfile.LastName, Is.EqualTo("Georgiev"));
            Assert.That(dbProfile.DateOfBirth.ToString(DateFormat), Is.EqualTo("12-07-2004"));
            Assert.That(dbProfile.GenderId, Is.EqualTo(2));
            Assert.That(dbProfile.WantedGenderId, Is.EqualTo(2));
            Assert.That(dbProfile.RelationshipId, Is.EqualTo(1));
            Assert.That(dbProfile.Description, Is.EqualTo("some other discription now"));
        }

        [Test]
        public async Task GetPersonProfileInfoAsync_WorksCorrectly() 
        {
            string firstProfileId = "ace41288-92e4-4b16-8880-808450fe5388";

            var dbProfileInfo = await personProfileService.GetPersonProfileInfoAsync(firstProfileId);

            Assert.IsNotNull(dbProfileInfo);

            Assert.That(dbProfileInfo.Id, Is.EqualTo(1));
            Assert.That(dbProfileInfo.FirstName, Is.EqualTo("Yordan"));
            Assert.That(dbProfileInfo.LastName, Is.EqualTo("Neshev"));
            Assert.That(dbProfileInfo.DateOfBirth, Is.EqualTo("12-07-2004"));
            Assert.That(dbProfileInfo.Gender, Is.EqualTo("Male"));
            Assert.That(dbProfileInfo.WantedGender, Is.EqualTo("Female"));
            Assert.That(dbProfileInfo.Relationship, Is.EqualTo("Open"));
            Assert.That(dbProfileInfo.Description, Is.EqualTo("Some discription here"));
        }

        [Test]
        public async Task GetDeleteInfo_WorksCorrectly() 
        {
            var dbProfileInfo = await personProfileService.GetDeleteInfoAsync(4);

            Assert.IsNotNull(dbProfileInfo);

            Assert.That(dbProfileInfo.Id, Is.EqualTo(4));
            Assert.That(dbProfileInfo.FirstName, Is.EqualTo("Iztrit"));
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

            var dbProfile = await personProfileService.GetProfileByUserIdAsync(deletedProfileId);

            await personProfileService.DeleteAsync(dbProfile.Id);

            var dbProfileInfo = await personProfileService.ExistsByIdAllAsync(deletedProfileId);

            Assert.That(dbProfileInfo, Is.EqualTo(false));
        }

        [Test]
        public async Task GetUserForReview_WorksCorrectly()
        {
            var dbProfileInfoArray = await personProfileService.GetUserForReviewAsync();

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


    }
}
