using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Heartify.Infrastructure.Migrations
{
    public partial class addmgrationapprovingAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "PersonProfiles",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Is profile approved by admin");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "621feec7-9420-4ba0-8362-1f8b2505b88c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "adfb45dc-c806-4ce0-8135-aadb8ce83e60", "AQAAAAEAACcQAAAAEN9skB0nYWMx2Y00iJhqQW9XU4Do5CWmDmYralOyz5T/2v6KhNnuEMdprfv/z1bzbQ==", "2cd2fb76-800e-4b33-8803-a1ad941b7c18" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "PersonProfiles");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "621feec7-9420-4ba0-8362-1f8b2505b88c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eec90065-26d8-40eb-ad53-da8d6a66821c", "AQAAAAEAACcQAAAAEJrOVCXMBemvA25/+DwAQLrGDKLSnuSKNDU9xZ1b1yHqCYlSgpRp5aMnKgvKKaT0jQ==", "4d024c61-f916-4a4d-bfb5-f7b29cba0a09" });
        }
    }
}
