using Heartify.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Heartify.Infrastructure.Data.Configuration
{
    public class AdminConfiguration : IEntityTypeConfiguration<IdentityUser>
    {
        public IdentityUser AdminUser { get; set; }

        public AdminConfiguration() 
        {
            SeedAdmin();
        }

        private void SeedAdmin()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            AdminUser = new IdentityUser
            {
                Id = "621feec7-9420-4ba0-8362-1f8b2505b88c",
                UserName = "admin@mail.com",
                NormalizedUserName = "ADMIN@MAIL.COM",
                Email = "admin@mail.com",
                NormalizedEmail = "ADMIN@MAIL.COM"
            };

            AdminUser.PasswordHash = hasher.HashPassword(AdminUser, "admin123");
        }

        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            var data = new AdminConfiguration();

            builder.HasData(data.AdminUser);
        }
    }
}
