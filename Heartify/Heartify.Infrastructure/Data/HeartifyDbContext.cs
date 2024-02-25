using Heartify.Data.Models;
using Heartify.Infrastructure.Data.Configuration;
using HeartifyDating.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Heartify.Infrastructure.Data
{
    public class HeartifyDbContext : IdentityDbContext
    {
        public HeartifyDbContext(DbContextOptions<HeartifyDbContext> options)
            : base(options)
        {
        }

		public DbSet<PersonProfile> PersonProfiles { get; set; }
		public DbSet<Gender> Genders { get; set; }
		public DbSet<Relationship> Relationships { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gender>()
                .HasMany(g => g.PersonProfiles);

            modelBuilder.Entity<Relationship>()
                .HasMany(r => r.PersonProfiles);

            modelBuilder.Entity<PersonProfile>().HasOne(pp => pp.Gender);
            modelBuilder.Entity<PersonProfile>().HasOne(pp => pp.Relationship);

            modelBuilder.ApplyConfiguration(new GenderConfiguration());
            modelBuilder.ApplyConfiguration(new RelationshipConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}