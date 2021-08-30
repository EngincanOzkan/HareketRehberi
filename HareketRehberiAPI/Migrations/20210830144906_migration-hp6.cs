using Microsoft.EntityFrameworkCore.Migrations;

namespace HareketRehberiAPI.Migrations
{
    public partial class migrationhp6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isAdmin",
                table: "SystemUsers",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isAdmin",
                table: "SystemUsers");
        }
    }
}
