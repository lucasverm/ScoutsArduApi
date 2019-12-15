using Microsoft.EntityFrameworkCore.Migrations;

namespace ScoutsArduAPI.Migrations
{
    public partial class removeignore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WinkelwagenId",
                table: "mtm",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_mtm_WinkelwagenId",
                table: "mtm",
                column: "WinkelwagenId");

            migrationBuilder.AddForeignKey(
                name: "FK_mtm_Winkelwagens_WinkelwagenId",
                table: "mtm",
                column: "WinkelwagenId",
                principalTable: "Winkelwagens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mtm_Winkelwagens_WinkelwagenId",
                table: "mtm");

            migrationBuilder.DropIndex(
                name: "IX_mtm_WinkelwagenId",
                table: "mtm");

            migrationBuilder.DropColumn(
                name: "WinkelwagenId",
                table: "mtm");
        }
    }
}
