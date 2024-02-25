using Heartify.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Heartify.Infrastructure.Data.Configuration
{
    public class RelationshipConfiguration : IEntityTypeConfiguration<Relationship>
    {
        private Relationship[] initialRelationships = new Relationship[]
        {
            new Relationship()
            {
                Id = 1,
                RelationshipType = "Open Relationship"
            },
            new Relationship()
            {
                Id = 2,
                RelationshipType = "Love Relationship"
            },
            new Relationship()
            {
                Id = 3,
                RelationshipType = "Asexual Relationship"
            },
			new Relationship()
			{
				Id = 4,
                RelationshipType = "Aromantical Relationship"
            },
		};

        public void Configure(EntityTypeBuilder<Relationship> builder)
        {
            builder.HasData(initialRelationships);
        }
    }
}