using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Heartify.Data.Migrations
{
    public partial class working : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DaterId",
                table: "PersonProfiles",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_PersonProfiles_DaterId",
                table: "PersonProfiles",
                column: "DaterId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonProfiles_AspNetUsers_DaterId",
                table: "PersonProfiles",
                column: "DaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonProfiles_AspNetUsers_DaterId",
                table: "PersonProfiles");

            migrationBuilder.DropIndex(
                name: "IX_PersonProfiles_DaterId",
                table: "PersonProfiles");

            migrationBuilder.DropColumn(
                name: "DaterId",
                table: "PersonProfiles");
        }
    }
}
