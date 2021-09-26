using Microsoft.EntityFrameworkCore.Migrations;

namespace HareketRehberiAPI.Migrations
{
    public partial class LessonUserFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LessonUserMatches_Evaluations_UserId",
                table: "LessonUserMatches");

            migrationBuilder.AddForeignKey(
                name: "FK_LessonUserMatches_SystemUsers_UserId",
                table: "LessonUserMatches",
                column: "UserId",
                principalTable: "SystemUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LessonUserMatches_SystemUsers_UserId",
                table: "LessonUserMatches");

            migrationBuilder.AddForeignKey(
                name: "FK_LessonUserMatches_Evaluations_UserId",
                table: "LessonUserMatches",
                column: "UserId",
                principalTable: "Evaluations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
