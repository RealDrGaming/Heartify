using Heartify.Data.Configuration;
using Heartify.Data.Models;
using HeartifyDating.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Heartify.Data
{
    public class HeartifyDbContext : IdentityDbContext
    {
        public HeartifyDbContext(DbContextOptions<HeartifyDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GenderConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<PersonProfile> PersonProfiles { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Relationship> Relationships { get; set; }
    }
}