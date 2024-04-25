using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Heartify.Infrastructure.Data.Constants.AdministratorConstants;

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
                UserName = AdminEmail,
                NormalizedUserName = AdminEmail.ToUpper(),
                Email = AdminEmail,
                NormalizedEmail = AdminEmail.ToUpper(),
            };

            AdminUser.PasswordHash = hasher.HashPassword(AdminUser, AdminPassword);
        }

        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            var data = new AdminConfiguration();

            builder.HasData(data.AdminUser);
        }
    }
}
