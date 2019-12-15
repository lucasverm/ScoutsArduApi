using Microsoft.EntityFrameworkCore.Migrations;

namespace ScoutsArduAPI.Migrations
{
    public partial class removingmtm2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MTMWinkelwagensWinkelwagenITems_Items_WinkelwagenItemId",
                table: "MTMWinkelwagensWinkelwagenITems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MTMWinkelwagensWinkelwagenITems",
                table: "MTMWinkelwagensWinkelwagenITems");

            migrationBuilder.RenameTable(
                name: "MTMWinkelwagensWinkelwagenITems",
                newName: "mtm");

            migrationBuilder.RenameIndex(
                name: "IX_MTMWinkelwagensWinkelwagenITems_WinkelwagenItemId",
                table: "mtm",
                newName: "IX_mtm_WinkelwagenItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_mtm",
                table: "mtm",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_mtm_Items_WinkelwagenItemId",
                table: "mtm",
                column: "WinkelwagenItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mtm_Items_WinkelwagenItemId",
                table: "mtm");

            migrationBuilder.DropPrimaryKey(
                name: "PK_mtm",
                table: "mtm");

            migrationBuilder.RenameTable(
                name: "mtm",
                newName: "MTMWinkelwagensWinkelwagenITems");

            migrationBuilder.RenameIndex(
                name: "IX_mtm_WinkelwagenItemId",
                table: "MTMWinkelwagensWinkelwagenITems",
                newName: "IX_MTMWinkelwagensWinkelwagenITems_WinkelwagenItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MTMWinkelwagensWinkelwagenITems",
                table: "MTMWinkelwagensWinkelwagenITems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MTMWinkelwagensWinkelwagenITems_Items_WinkelwagenItemId",
                table: "MTMWinkelwagensWinkelwagenITems",
                column: "WinkelwagenItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
