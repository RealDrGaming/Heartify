using HeartifyDating.Infrastructure.Data.Configuration;
using HeartifyDating.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HeartifyDating.Infrastructure.Data
{
    public class HeartifyDatingDbContext : DbContext
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
