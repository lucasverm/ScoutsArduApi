using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ScoutsArduAPI.Migrations
{
    public partial class azure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gebruikers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Voornaam = table.Column<string>(nullable: true),
                    Achternaam = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Foto = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gebruikers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naam = table.Column<string>(nullable: true),
                    Prijs = table.Column<float>(nullable: false),
                    Aantal = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Winkelwagens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Betaald = table.Column<bool>(nullable: false),
                    Datum = table.Column<DateTime>(nullable: false),
                    GebruikerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Winkelwagens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Winkelwagens_Gebruikers_GebruikerId",
                        column: x => x.GebruikerId,
                        principalTable: "Gebruikers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LesLid",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WinkelwagenId = table.Column<int>(nullable: true),
                    WinkelwagenItemId = table.Column<int>(nullable: true),
                    aantal = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LesLid", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LesLid_Winkelwagens_WinkelwagenId",
                        column: x => x.WinkelwagenId,
                        principalTable: "Winkelwagens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LesLid_Items_WinkelwagenItemId",
                        column: x => x.WinkelwagenItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LesLid_WinkelwagenId",
                table: "LesLid",
                column: "WinkelwagenId");

            migrationBuilder.CreateIndex(
                name: "IX_LesLid_WinkelwagenItemId",
                table: "LesLid",
                column: "WinkelwagenItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Winkelwagens_GebruikerId",
                table: "Winkelwagens",
                column: "GebruikerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LesLid");

            migrationBuilder.DropTable(
                name: "Winkelwagens");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Gebruikers");
        }
    }
}
