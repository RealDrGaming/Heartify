using HeartifyDating.Infrastructure.Data.Configuration;
using HeartifyDating.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Heartify.Data
{
    public class HeartifyDatingDbContext : IdentityDbContext
    {
        public HeartifyDatingDbContext(DbContextOptions<HeartifyDatingDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonProfileConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<PersonProfile> PersonProfiles { get; set; }
    }
}