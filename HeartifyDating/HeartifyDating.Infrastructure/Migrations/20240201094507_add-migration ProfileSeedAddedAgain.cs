using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeartifyDating.Infrastructure.Migrations
{
    public partial class addmigrationProfileSeedAddedAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PersonProfiles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Age", "LastName" },
                values: new object[] { 18, "Petkova" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PersonProfiles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Age", "LastName" },
                values: new object[] { 24, "Radeva" });
        }
    }
}
