using Heartify.Data.Models;
using Heartify.Infrastructure.Constants;
using Heartify.Infrastructure.Data;
using Heartify.Infrastructure.Data.Common;
using Heartify.Tests.Mocks;
using HeartifyDating.Infrastructure.Data.Models;
using System.Globalization;
using Heartify.Infrastructure.Data.Models;
using static Heartify.Infrastructure.Constants.ValidationConstants;

namespace Heartify.Tests.UnitTests
{
    public class UnitTestsBase
    {
        protected HeartifyDbContext data;
        protected IRepository repository;

        [OneTimeSetUp]
        public async Task SetUpBase() 
        {
            data = DatabaseMock.Instance;

            repository = new Repository(data);

            await SeedDatabase(repository);
        }

        [OneTimeTearDown]
        public void TearDownBase() 
        {
            data.Dispose();
        }

        private async Task SeedDatabase(IRepository repo) 
        {
            string date = "12-07-2004";
            DateTime dateOfBirth = DateTime.Now;

            DateTime.TryParseExact(
                date,
                DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dateOfBirth);

            await repo.AddAsync(new PersonProfile()
            {
                Id = 1,
                FirstName = "Yordan",
                LastName = "Neshev",
                DateOfBirth = dateOfBirth,
                GenderId = 1,
                WantedGenderId = 2,
                RelationshipId = 2,
                Description = "Some discription here",
                IsApproved = true,
                DaterId = "ace41288-92e4-4b16-8880-808450fe5388"
            });

            await repo.AddAsync(new PersonProfile()
            {
                Id = 2,
                FirstName = "Ivanka",
                LastName = "Sotirova",
                DateOfBirth = dateOfBirth,
                GenderId = 2,
                WantedGenderId = 1,
                RelationshipId = 1,
                Description = "some ivanka stuff",
                IsApproved = false,
                DaterId = "c78567dd-3be3-41be-ba30-eee36aa7c9db"
            });

            await repo.AddAsync(new PersonProfile()
            {
                Id = 3,
                FirstName = "Petko",
                LastName = "Savov",
                DateOfBirth = dateOfBirth,
                GenderId = 1,
                WantedGenderId = 3,
                RelationshipId = 3,
                Description = "omg checheneca",
                IsApproved = true,
                DaterId = "e0576a86-f7d1-419c-b074-b2c077e44ce9"
            });

            await repo.AddAsync(new PersonProfile()
            {
                Id = 4,
                FirstName = "Iztrit",
                LastName = "Iztritov",
                DateOfBirth = dateOfBirth,
                GenderId = 2,
                WantedGenderId = 2,
                RelationshipId = 2,
                Description = "aide iztriha me",
                IsApproved = true,
                DaterId = "ca69b026-ad63-44b0-8264-612c9de7dd02"
            });

            await repo.AddAsync(new Gender()
            {
                Id = 1,
                GenderName = "Male",
            });

            await repo.AddAsync(new Gender()
            {
                Id = 2,
                GenderName = "Female",
            });

            await repo.AddAsync(new Relationship()
            {
                Id = 1,
                RelationshipType = "Love",
            });

            await repo.AddAsync(new Relationship()
            {
                Id = 2,
                RelationshipType = "Open",
            });

            await repo.AddAsync(new Like()
            {
                LikerId = "e0576a86-f7d1-419c-b074-b2c077e44ce9",
                LikedProfileId = 4
            });

            await repo.AddAsync(new Like()
            {
                LikerId = "ca69b026-ad63-44b0-8264-612c9de7dd02",
                LikedProfileId = 3
            });

            await repo.SaveChangesAsync();
        }
    }
}