using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Heartify.Infrastructure.Migrations
{
    public partial class SchoolMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "621feec7-9420-4ba0-8362-1f8b2505b88c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a5657890-0263-4675-adf2-0a11cdfe729d", "AQAAAAEAACcQAAAAEBRxe4myR/KBo+fS5jyXfWsTdPSS9bo7a+x535bEE32NnVHBsT8xyi2ByMC0Nc1SaQ==", "fded13e4-4f93-4637-9d70-04d81fac541c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "621feec7-9420-4ba0-8362-1f8b2505b88c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "adfb45dc-c806-4ce0-8135-aadb8ce83e60", "AQAAAAEAACcQAAAAEN9skB0nYWMx2Y00iJhqQW9XU4Do5CWmDmYralOyz5T/2v6KhNnuEMdprfv/z1bzbQ==", "2cd2fb76-800e-4b33-8803-a1ad941b7c18" });
        }
    }
}
