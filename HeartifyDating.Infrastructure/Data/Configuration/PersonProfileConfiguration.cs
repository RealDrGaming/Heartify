using HeartifyDating.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HeartifyDating.Infrastructure.Data.Configuration
{
    public class PersonProfileConfiguration : IEntityTypeConfiguration<PersonProfile>
    {
        private PersonProfile[] initialProfiles = new PersonProfile[] 
        {
            new PersonProfile()
            { 
                Id = 1,
                FirstName = "Alejandro",
                LastName = "Himenez",
                Age = 22,
                Gender = "Male",
                WantedGender = "Female",
                RelationshipType = "Love",
                Description = "Fit, strong, tall, rich, looking for ma queen.",
                ProfileImage = "",
                UsernamePicture = "",
                RandomPicture = ""
            },
            new PersonProfile()
            {
                Id = 2,
                FirstName = "Hristina",
                LastName = "Petkova",
                Age = 18,
                Gender = "Female",
                WantedGender = "Male",
                RelationshipType = "Open",
                Description = "Biggest ass in town, looking for multiple partners that don't have a problem to be in open relationships.",
                ProfileImage = "",
                UsernamePicture = "",
                RandomPicture = ""
            },
            new PersonProfile()
            {
                Id = 3,
                FirstName = "Alek",
                LastName = "Ritaro",
                Age = 27,
                Gender = "Male",
                WantedGender = "Male",
                RelationshipType = "Aromantical",
                Description = "Im just a gay dude looking for hook-ups and sex.",
                ProfileImage = "",
                UsernamePicture = "",
                RandomPicture = ""
            }
        };

        public void Configure(EntityTypeBuilder<PersonProfile> builder)
        {
            builder.HasData(initialProfiles);
        }
    }
}