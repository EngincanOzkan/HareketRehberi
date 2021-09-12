using Microsoft.EntityFrameworkCore.Migrations;

namespace HareketRehberiAPI.Migrations
{
    public partial class ProgressiveRelaxationExercise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ProgressiveRelaxationExercise",
                table: "Lessons",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProgressiveRelaxationExercise",
                table: "Lessons");
        }
    }
}
