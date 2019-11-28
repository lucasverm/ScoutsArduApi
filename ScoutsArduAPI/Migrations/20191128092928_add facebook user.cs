using Microsoft.EntityFrameworkCore.Migrations;

namespace ScoutsArduAPI.Migrations
{
    public partial class addfacebookuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFacebookUser",
                table: "Gebruikers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFacebookUser",
                table: "Gebruikers");
        }
    }
}
