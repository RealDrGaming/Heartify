using Heartify.Core.Contracts;
using Heartify.Core.Services;
using Heartify.Infrastructure.Data.Models;
using HeartifyDating.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

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
        public async Task LikeProfile_WorksCorrectly()
        {
            var personProfile1 = await repository.GetByIdAsync<PersonProfile>(1);
            var personProfile2 = await repository.GetByIdAsync<PersonProfile>(2);

            await datingService.LikeProfileAsync(personProfile1.DaterId, personProfile2.Id);

            var like = await repository.AllReadOnly<Like>().FirstOrDefaultAsync(l => l.LikedProfileId == personProfile2.Id && l.LikerId == personProfile1.DaterId);

            Assert.NotNull(like);
        }

        [Test]
        public async Task DeclineProfile_WorksCorrectly()
        {
            var personProfile1 = await repository.GetByIdAsync<PersonProfile>(1);
            var personProfile2 = await repository.GetByIdAsync<PersonProfile>(2);

            await datingService.DeclineProfileAsync(personProfile1.DaterId, personProfile2.Id);

            var like = await repository.AllReadOnly<Like>().FirstOrDefaultAsync(l => l.LikedProfileId == personProfile2.Id && l.LikerId == personProfile1.DaterId);

            Assert.Null(like);
        }

        [Test]
        public async Task RemoveMatch_WorksCorrectly()
        {
            var likePerson1 = await repository.GetByIdAsync<PersonProfile>(1);
            var likePerson2 = await repository.GetByIdAsync<PersonProfile>(4);

            await datingService.LikeProfileAsync(likePerson1.DaterId, likePerson2.Id);
            await datingService.LikeProfileAsync(likePerson2.DaterId, likePerson1.Id);

            var personProfile1 = await repository.GetByIdAsync<PersonProfile>(1);
            var personProfile2 = await repository.GetByIdAsync<PersonProfile>(4);

            await datingService.RemoveMatchAsync(personProfile1.DaterId, personProfile2.Id);

            var like1 = await repository.AllReadOnly<Like>().FirstOrDefaultAsync(l => l.LikedProfileId == likePerson1.Id && l.LikerId == likePerson2.DaterId);
            var like2 = await repository.AllReadOnly<Like>().FirstOrDefaultAsync(l => l.LikedProfileId == likePerson2.Id && l.LikerId == likePerson1.DaterId);

            Assert.Null(like1);
            Assert.Null(like2);
        }
    }
}
