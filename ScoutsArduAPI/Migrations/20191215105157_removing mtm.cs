using Microsoft.EntityFrameworkCore.Migrations;

namespace ScoutsArduAPI.Migrations
{
    public partial class removingmtm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LesLid_Winkelwagens_WinkelwagenId",
                table: "LesLid");

            migrationBuilder.DropForeignKey(
                name: "FK_LesLid_Items_WinkelwagenItemId",
                table: "LesLid");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LesLid",
                table: "LesLid");

            migrationBuilder.DropIndex(
                name: "IX_LesLid_WinkelwagenId",
                table: "LesLid");

            migrationBuilder.DropColumn(
                name: "Aantal",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "WinkelwagenId",
                table: "LesLid");

            migrationBuilder.RenameTable(
                name: "LesLid",
                newName: "MTMWinkelwagensWinkelwagenITems");

            migrationBuilder.RenameIndex(
                name: "IX_LesLid_WinkelwagenItemId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MTMWinkelwagensWinkelwagenITems_Items_WinkelwagenItemId",
                table: "MTMWinkelwagensWinkelwagenITems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MTMWinkelwagensWinkelwagenITems",
                table: "MTMWinkelwagensWinkelwagenITems");

            migrationBuilder.RenameTable(
                name: "MTMWinkelwagensWinkelwagenITems",
                newName: "LesLid");

            migrationBuilder.RenameIndex(
                name: "IX_MTMWinkelwagensWinkelwagenITems_WinkelwagenItemId",
                table: "LesLid",
                newName: "IX_LesLid_WinkelwagenItemId");

            migrationBuilder.AddColumn<int>(
                name: "Aantal",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WinkelwagenId",
                table: "LesLid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LesLid",
                table: "LesLid",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_LesLid_WinkelwagenId",
                table: "LesLid",
                column: "WinkelwagenId");

            migrationBuilder.AddForeignKey(
                name: "FK_LesLid_Winkelwagens_WinkelwagenId",
                table: "LesLid",
                column: "WinkelwagenId",
                principalTable: "Winkelwagens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LesLid_Items_WinkelwagenItemId",
                table: "LesLid",
                column: "WinkelwagenItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
