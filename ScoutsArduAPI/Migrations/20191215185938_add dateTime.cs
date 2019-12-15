using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ScoutsArduAPI.Migrations
{
    public partial class adddateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Datum",
                table: "Winkelwagens",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Datum",
                table: "Winkelwagens",
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
