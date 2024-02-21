using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Heartify.Data.Migrations
{
    public partial class workingQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "PersonProfiles");

            migrationBuilder.DropColumn(
                name: "RelationshipType",
                table: "PersonProfiles");

            migrationBuilder.DropColumn(
                name: "WantedGender",
                table: "PersonProfiles");

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "PersonProfiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RelationshipId",
                table: "PersonProfiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WantedGenderId",
                table: "PersonProfiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Gender Unique Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "Gender Name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                },
                comment: "Gender");

            migrationBuilder.CreateTable(
                name: "Relationships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Relationship Unique Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RelationshipType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Relationship Type")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relationships", x => x.Id);
                },
                comment: "Relationships users want");

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "GenderName" },
                values: new object[] { 1, "Male" });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "GenderName" },
                values: new object[] { 2, "Female" });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "GenderName" },
                values: new object[] { 3, "Non-binary" });

            migrationBuilder.CreateIndex(
                name: "IX_PersonProfiles_GenderId",
                table: "PersonProfiles",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonProfiles_RelationshipId",
                table: "PersonProfiles",
                column: "RelationshipId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonProfiles_WantedGenderId",
                table: "PersonProfiles",
                column: "WantedGenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonProfiles_Genders_GenderId",
                table: "PersonProfiles",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonProfiles_Genders_WantedGenderId",
                table: "PersonProfiles",
                column: "WantedGenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonProfiles_Relationships_RelationshipId",
                table: "PersonProfiles",
                column: "RelationshipId",
                principalTable: "Relationships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonProfiles_Genders_GenderId",
                table: "PersonProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonProfiles_Genders_WantedGenderId",
                table: "PersonProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonProfiles_Relationships_RelationshipId",
                table: "PersonProfiles");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "Relationships");

            migrationBuilder.DropIndex(
                name: "IX_PersonProfiles_GenderId",
                table: "PersonProfiles");

            migrationBuilder.DropIndex(
                name: "IX_PersonProfiles_RelationshipId",
                table: "PersonProfiles");

            migrationBuilder.DropIndex(
                name: "IX_PersonProfiles_WantedGenderId",
                table: "PersonProfiles");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "PersonProfiles");

            migrationBuilder.DropColumn(
                name: "RelationshipId",
                table: "PersonProfiles");

            migrationBuilder.DropColumn(
                name: "WantedGenderId",
                table: "PersonProfiles");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "PersonProfiles",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "",
                comment: "Person Sexual Orientation");

            migrationBuilder.AddColumn<string>(
                name: "RelationshipType",
                table: "PersonProfiles",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                comment: "Wanted Relationship Type");

            migrationBuilder.AddColumn<string>(
                name: "WantedGender",
                table: "PersonProfiles",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "",
                comment: "Seuxal Orientation of Wanted Person");

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
    }
}
