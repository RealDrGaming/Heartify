using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Heartify.Infrastructure.Migrations
{
    public partial class Likes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    LikerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LikedProfileId = table.Column<int>(type: "int", nullable: false),
                    PersonProfileId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => new { x.LikerId, x.LikedProfileId });
                    table.ForeignKey(
                        name: "FK_Likes_AspNetUsers_LikerId",
                        column: x => x.LikerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_PersonProfiles_LikedProfileId",
                        column: x => x.LikedProfileId,
                        principalTable: "PersonProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Likes_PersonProfiles_PersonProfileId",
                        column: x => x.PersonProfileId,
                        principalTable: "PersonProfiles",
                        principalColumn: "Id");
                },
                comment: "Likes of a Person Profile");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "621feec7-9420-4ba0-8362-1f8b2505b88c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f75e98e3-c0cc-4c23-af97-74087996905d", "AQAAAAEAACcQAAAAEAZ2cHiPqt6NBAKgzZLRscV75TU5S17uteBL+KHHNINNmsClNGl+cURJ1Aom9wNDcA==", "ace8181c-ecb5-410d-ae7c-3a8f73ee93d0" });

            migrationBuilder.CreateIndex(
                name: "IX_Likes_LikedProfileId",
                table: "Likes",
                column: "LikedProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_PersonProfileId",
                table: "Likes",
                column: "PersonProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "621feec7-9420-4ba0-8362-1f8b2505b88c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a5657890-0263-4675-adf2-0a11cdfe729d", "AQAAAAEAACcQAAAAEBRxe4myR/KBo+fS5jyXfWsTdPSS9bo7a+x535bEE32NnVHBsT8xyi2ByMC0Nc1SaQ==", "fded13e4-4f93-4637-9d70-04d81fac541c" });
        }
    }
}
