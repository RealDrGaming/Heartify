using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Heartify.Data.Migrations
{
    public partial class workingRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Relationships",
                columns: new[] { "Id", "RelationshipType" },
                values: new object[,]
                {
                    { 1, "Open Relationship" },
                    { 2, "Love Relationship" },
                    { 3, "Asexual Relationship" },
                    { 4, "Aromantical Relationship" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Relationships",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Relationships",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Relationships",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Relationships",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
