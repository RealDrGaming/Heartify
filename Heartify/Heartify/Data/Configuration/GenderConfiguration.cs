using Heartify.Data.Models;
using HeartifyDating.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Heartify.Data.Configuration
{
    public class GenderConfiguration
    {
        private Gender[] initialGenders = new Gender[]
        {
            new Gender()
            {
                Id = 1,
                GenderName = "Male"
            },
            new Gender()
            {
                Id = 2,
                GenderName = "Female"
            },
            new Gender()
            {
                Id = 3,
                GenderName = "Non-binary"
            },
        };

        public void Configure(EntityTypeBuilder<PersonProfile> builder)
        {
            builder.HasData(initialGenders);
        }
    }
}
