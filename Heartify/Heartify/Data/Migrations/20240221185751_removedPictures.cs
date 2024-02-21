using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Heartify.Data.Migrations
{
    public partial class removedPictures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileImage",
                table: "PersonProfiles");

            migrationBuilder.DropColumn(
                name: "RandomPicture",
                table: "PersonProfiles");

            migrationBuilder.DropColumn(
                name: "UsernamePicture",
                table: "PersonProfiles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "UsernamePicture",
                table: "PersonProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Person Username Picture");
        }
    }
}
