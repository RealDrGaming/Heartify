using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeartifyDating.Infrastructure.Migrations
{
    public partial class PersonProfileSeedAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WantedSexuality",
                table: "PersonProfiles",
                newName: "WantedGender");

            migrationBuilder.RenameColumn(
                name: "Sexuality",
                table: "PersonProfiles",
                newName: "Gender");

            migrationBuilder.InsertData(
                table: "PersonProfiles",
                columns: new[] { "Id", "Age", "Description", "FirstName", "Gender", "LastName", "ProfileImage", "RandomPicture", "RelationshipType", "UsernamePicture", "WantedGender" },
                values: new object[] { 1, 22, "Fit, strong, tall, rich, looking for ma queen.", "Alejandro", "Male", "Himenez", "", "", "Love", "", "Female" });

            migrationBuilder.InsertData(
                table: "PersonProfiles",
                columns: new[] { "Id", "Age", "Description", "FirstName", "Gender", "LastName", "ProfileImage", "RandomPicture", "RelationshipType", "UsernamePicture", "WantedGender" },
                values: new object[] { 2, 24, "Biggest ass in town, looking for multiple partners that don't have a problem to be in open relationships.", "Hristina", "Female", "Radeva", "", "", "Open", "", "Male" });

            migrationBuilder.InsertData(
                table: "PersonProfiles",
                columns: new[] { "Id", "Age", "Description", "FirstName", "Gender", "LastName", "ProfileImage", "RandomPicture", "RelationshipType", "UsernamePicture", "WantedGender" },
                values: new object[] { 3, 27, "Im just a gay dude looking for hook-ups and sex.", "Alek", "Male", "Ritaro", "", "", "Aromantical", "", "Male" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PersonProfiles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PersonProfiles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PersonProfiles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "WantedGender",
                table: "PersonProfiles",
                newName: "WantedSexuality");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "PersonProfiles",
                newName: "Sexuality");
        }
    }
}
