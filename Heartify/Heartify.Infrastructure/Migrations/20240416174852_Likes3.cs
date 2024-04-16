using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Heartify.Infrastructure.Migrations
{
    public partial class Likes3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Likes",
                table: "Likes");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Likes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Likes",
                table: "Likes",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "621feec7-9420-4ba0-8362-1f8b2505b88c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "059c617c-371b-4028-9390-5b54236a9ea9", "AQAAAAEAACcQAAAAEAkkzGSuSVrOsEG/m6HAEinNcltJ44NUvuclHGdybYc1iuVnW5/Jc8TSdtNJqKReLQ==", "6afb4817-d7b8-4bda-ac9b-ead1180d4678" });

            migrationBuilder.CreateIndex(
                name: "IX_Likes_LikerId",
                table: "Likes",
                column: "LikerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Likes",
                table: "Likes");

            migrationBuilder.DropIndex(
                name: "IX_Likes_LikerId",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Likes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Likes",
                table: "Likes",
                columns: new[] { "LikerId", "LikedProfileId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "621feec7-9420-4ba0-8362-1f8b2505b88c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f58c604a-7d20-474f-b0a2-9bd1d91b4a7d", "AQAAAAEAACcQAAAAEDSymTM+EU2ESP5OvU9wA5iK/MSoRWg2+sLGuelwRItrw6Q+1N16MZO+e6e8pI3L5Q==", "bf2f8b5d-bc80-4fcd-ab7e-baf0072001bd" });
        }
    }
}
