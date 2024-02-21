using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Heartify.Data.Migrations
{
    public partial class datesFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "PersonProfiles");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "PersonProfiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Person Date of Birth");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "PersonProfiles");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "PersonProfiles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Person Age");
        }
    }
}
