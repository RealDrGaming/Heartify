using Heartify.Data.Models;
using Heartify.Infrastructure.Data.Configuration;
using Heartify.Infrastructure.Data.Models;
using HeartifyDating.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Heartify.Infrastructure.Data
{
    public class HeartifyDbContext : IdentityDbContext
    {
        private bool _seedDb;

        public HeartifyDbContext(DbContextOptions<HeartifyDbContext> options, bool seedDb = true)
            : base(options)
        {
            if (Database.IsRelational())
            {
                Database.Migrate();
            }
            else
            {
                Database.EnsureCreated();
            }

            _seedDb = seedDb;
        }

        public DbSet<PersonProfile> PersonProfiles { get; set; }
        public DbSet<Like> Likes { get; set; }
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

            modelBuilder.Entity<Like>().HasKey(p => p.Id);

            modelBuilder.Entity<Like>()
                .HasOne(l => l.Liker)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Like>()
                .HasOne(l => l.LikedProfile)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);

            if (_seedDb)
            {
                modelBuilder.ApplyConfiguration(new GenderConfiguration());
                modelBuilder.ApplyConfiguration(new RelationshipConfiguration());
                modelBuilder.ApplyConfiguration(new AdminConfiguration());
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}