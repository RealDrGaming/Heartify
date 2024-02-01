using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeartifyDating.Infrastructure.Migrations
{
    public partial class PersonProfileDone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "PersonProfiles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Person Age");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PersonProfiles",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                comment: "Person Description");

            migrationBuilder.AddColumn<string>(
                name: "ProfileImage",
                table: "PersonProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Person Profile Picture");

            migrationBuilder.AddColumn<string>(
                name: "RandomPicture",
                table: "PersonProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Person Random Picture");

            migrationBuilder.AddColumn<string>(
                name: "RelationshipType",
                table: "PersonProfiles",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                comment: "Wanted Relationship Type");

            migrationBuilder.AddColumn<string>(
                name: "Sexuality",
                table: "PersonProfiles",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "",
                comment: "Person Sexual Orientation");

            migrationBuilder.AddColumn<string>(
                name: "UsernamePicture",
                table: "PersonProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Person Username Picture");

            migrationBuilder.AddColumn<string>(
                name: "WantedSexuality",
                table: "PersonProfiles",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "",
                comment: "Seuxal Orientation of Wanted Person");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "PersonProfiles");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "PersonProfiles");

            migrationBuilder.DropColumn(
                name: "ProfileImage",
                table: "PersonProfiles");

            migrationBuilder.DropColumn(
                name: "RandomPicture",
                table: "PersonProfiles");

            migrationBuilder.DropColumn(
                name: "RelationshipType",
                table: "PersonProfiles");

            migrationBuilder.DropColumn(
                name: "Sexuality",
                table: "PersonProfiles");

            migrationBuilder.DropColumn(
                name: "UsernamePicture",
                table: "PersonProfiles");

            migrationBuilder.DropColumn(
                name: "WantedSexuality",
                table: "PersonProfiles");
        }
    }
}
