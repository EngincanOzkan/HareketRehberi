using Microsoft.EntityFrameworkCore.Migrations;

namespace HareketRehberiAPI.Migrations
{
    public partial class migrationhp62 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "SystemUsers",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "SystemUsers");
        }
    }
}
