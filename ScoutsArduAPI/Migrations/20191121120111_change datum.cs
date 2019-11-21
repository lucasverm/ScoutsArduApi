using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ScoutsArduAPI.Migrations
{
    public partial class changedatum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Datum",
                table: "Winkelwagens",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Datum",
                table: "Winkelwagens",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
