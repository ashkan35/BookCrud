using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class mig_book_user_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Books_UserCreatedId",
                table: "Books",
                column: "UserCreatedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Users_UserCreatedId",
                table: "Books",
                column: "UserCreatedId",
                principalSchema: "usr",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Users_UserCreatedId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_UserCreatedId",
                table: "Books");
        }
    }
}
