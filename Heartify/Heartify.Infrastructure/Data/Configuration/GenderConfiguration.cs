﻿using Heartify.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Heartify.Infrastructure.Data.Configuration
{
    public class GenderConfiguration : IEntityTypeConfiguration<Gender>
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

        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.HasData(initialGenders);
        }
    }
}