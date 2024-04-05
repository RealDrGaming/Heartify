using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Heartify.Infrastructure.Migrations
{
    public partial class AdminSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "621feec7-9420-4ba0-8362-1f8b2505b88c", 0, "eec90065-26d8-40eb-ad53-da8d6a66821c", "admin@mail.com", false, false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAEAACcQAAAAEJrOVCXMBemvA25/+DwAQLrGDKLSnuSKNDU9xZ1b1yHqCYlSgpRp5aMnKgvKKaT0jQ==", null, false, "4d024c61-f916-4a4d-bfb5-f7b29cba0a09", false, "admin@mail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "621feec7-9420-4ba0-8362-1f8b2505b88c");
        }
    }
}
