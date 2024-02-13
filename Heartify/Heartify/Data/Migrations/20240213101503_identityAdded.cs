using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Heartify.Data.Migrations
{
    public partial class identityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Person Unique Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Person First Name"),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Person Last Name"),
                    Age = table.Column<int>(type: "int", nullable: false, comment: "Person Age"),
                    Gender = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "Person Sexual Orientation"),
                    WantedGender = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "Seuxal Orientation of Wanted Person"),
                    RelationshipType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Wanted Relationship Type"),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "Person Description"),
                    ProfileImage = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Person Profile Picture"),
                    UsernamePicture = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Person Username Picture"),
                    RandomPicture = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Person Random Picture")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonProfiles", x => x.Id);
                },
                comment: "Person Profiles Table");

            migrationBuilder.InsertData(
                table: "PersonProfiles",
                columns: new[] { "Id", "Age", "Description", "FirstName", "Gender", "LastName", "ProfileImage", "RandomPicture", "RelationshipType", "UsernamePicture", "WantedGender" },
                values: new object[] { 1, 22, "Fit, strong, tall, rich, looking for ma queen.", "Alejandro", "Male", "Himenez", "", "", "Love", "", "Female" });

            migrationBuilder.InsertData(
                table: "PersonProfiles",
                columns: new[] { "Id", "Age", "Description", "FirstName", "Gender", "LastName", "ProfileImage", "RandomPicture", "RelationshipType", "UsernamePicture", "WantedGender" },
                values: new object[] { 2, 18, "Biggest ass in town, looking for multiple partners that don't have a problem to be in open relationships.", "Hristina", "Female", "Petkova", "", "", "Open", "", "Male" });

            migrationBuilder.InsertData(
                table: "PersonProfiles",
                columns: new[] { "Id", "Age", "Description", "FirstName", "Gender", "LastName", "ProfileImage", "RandomPicture", "RelationshipType", "UsernamePicture", "WantedGender" },
                values: new object[] { 3, 27, "Im just a gay dude looking for hook-ups and sex.", "Alek", "Male", "Ritaro", "", "", "Aromantical", "", "Male" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonProfiles");
        }
    }
}
