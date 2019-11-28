using Microsoft.EntityFrameworkCore.Migrations;

namespace ScoutsArduAPI.Migrations
{
    public partial class addtelgebr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TelNr",
                table: "Gebruikers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TelNr",
                table: "Gebruikers");
        }
    }
}
