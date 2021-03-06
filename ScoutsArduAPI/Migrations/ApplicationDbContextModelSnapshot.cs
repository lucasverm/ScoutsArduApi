﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ScoutsArduAPI.Data;

namespace ScoutsArduAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ScoutsArduAPI.Models.Gebruiker", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Achternaam");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("Foto");

                    b.Property<bool>("IsFacebookUser");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("TelNr");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<int>("Type");

                    b.Property<string>("UserName");

                    b.Property<string>("Voornaam");

                    b.HasKey("Id");

                    b.ToTable("Gebruikers");
                });

            modelBuilder.Entity("ScoutsArduAPI.Models.MTMWinkelwagenWinkelwagenItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("WinkelwagenId");

                    b.Property<int?>("WinkelwagenItemId");

                    b.Property<int>("aantal");

                    b.HasKey("Id");

                    b.HasIndex("WinkelwagenId");

                    b.HasIndex("WinkelwagenItemId");

                    b.ToTable("mtm");
                });

            modelBuilder.Entity("ScoutsArduAPI.Models.Winkelwagen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Betaald");

                    b.Property<DateTime>("Datum");

                    b.Property<string>("GebruikerId");

                    b.HasKey("Id");

                    b.HasIndex("GebruikerId");

                    b.ToTable("Winkelwagens");
                });

            modelBuilder.Entity("ScoutsArduAPI.Models.WinkelwagenItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naam");

                    b.Property<float>("Prijs");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("ScoutsArduAPI.Models.MTMWinkelwagenWinkelwagenItem", b =>
                {
                    b.HasOne("ScoutsArduAPI.Models.Winkelwagen")
                        .WithMany("Items")
                        .HasForeignKey("WinkelwagenId");

                    b.HasOne("ScoutsArduAPI.Models.WinkelwagenItem", "WinkelwagenItem")
                        .WithMany()
                        .HasForeignKey("WinkelwagenItemId");
                });

            modelBuilder.Entity("ScoutsArduAPI.Models.Winkelwagen", b =>
                {
                    b.HasOne("ScoutsArduAPI.Models.Gebruiker", "Gebruiker")
                        .WithMany("Winkelwagens")
                        .HasForeignKey("GebruikerId");
                });
#pragma warning restore 612, 618
        }
    }
}
