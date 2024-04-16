using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Heartify.Infrastructure.Migrations
{
    public partial class Likes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_AspNetUsers_LikerId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_PersonProfiles_LikedProfileId",
                table: "Likes");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "621feec7-9420-4ba0-8362-1f8b2505b88c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f58c604a-7d20-474f-b0a2-9bd1d91b4a7d", "AQAAAAEAACcQAAAAEDSymTM+EU2ESP5OvU9wA5iK/MSoRWg2+sLGuelwRItrw6Q+1N16MZO+e6e8pI3L5Q==", "bf2f8b5d-bc80-4fcd-ab7e-baf0072001bd" });

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_AspNetUsers_LikerId",
                table: "Likes",
                column: "LikerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_PersonProfiles_LikedProfileId",
                table: "Likes",
                column: "LikedProfileId",
                principalTable: "PersonProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_AspNetUsers_LikerId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_PersonProfiles_LikedProfileId",
                table: "Likes");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "621feec7-9420-4ba0-8362-1f8b2505b88c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f75e98e3-c0cc-4c23-af97-74087996905d", "AQAAAAEAACcQAAAAEAZ2cHiPqt6NBAKgzZLRscV75TU5S17uteBL+KHHNINNmsClNGl+cURJ1Aom9wNDcA==", "ace8181c-ecb5-410d-ae7c-3a8f73ee93d0" });

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_AspNetUsers_LikerId",
                table: "Likes",
                column: "LikerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_PersonProfiles_LikedProfileId",
                table: "Likes",
                column: "LikedProfileId",
                principalTable: "PersonProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
