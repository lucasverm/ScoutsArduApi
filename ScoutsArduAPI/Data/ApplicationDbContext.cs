using Microsoft.EntityFrameworkCore;
using ScoutsArduAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutsArduAPI.Data
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Gebruiker> Gebruikers { get; set; }
        public DbSet<Winkelwagen> Winkelwagens { get; set; }
        public DbSet<WinkelwagenItem> WinkelwagenItems { get; set; }
        public DbSet<MTMWinkelwagenWinkelwagenItem> MTMWinkelwagenWinkelwagenItems { get; set; }
        

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<MTMWinkelwagenWinkelwagenItem>().ToTable("mtm").HasKey(t => t.Id);
            builder.Entity<MTMWinkelwagenWinkelwagenItem>().Property(r => r.Id).ValueGeneratedOnAdd();
            builder.Entity<MTMWinkelwagenWinkelwagenItem>().HasOne(t => t.WinkelwagenItem);

           // builder.Entity<Winkelwagen>().Ignore(t => t.Id);
            builder.Entity<Winkelwagen>().ToTable("Winkelwagens");
            builder.Entity<Winkelwagen>().HasKey(t => t.Id);
            builder.Entity<Winkelwagen>().Property(t => t.Id).ValueGeneratedOnAdd();
            builder.Entity<Winkelwagen>().HasMany(t => t.Items).WithOne();

            builder.Entity<WinkelwagenItem>().ToTable("Items");
            builder.Entity<WinkelwagenItem>().HasKey(t => t.Id);
            builder.Entity<WinkelwagenItem>().Property(t => t.Id).ValueGeneratedOnAdd();

        }
    }
}
