using Microsoft.AspNetCore.Identity;
using ScoutsArduAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutsArduAPI.Data
{
    public class ApplicationDataInitialiser
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<Gebruiker> _userManager;

        public ApplicationDataInitialiser(ApplicationDbContext dbContext, UserManager<Gebruiker> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task InitializeData()
        {
            // _dbContext.Database.EnsureDeleted();
            //if (_dbContext.Database.EnsureCreated())
            //{
            if (!_dbContext.Winkelwagens.Any()) { 
                WinkelwagenItem item1 = new WinkelwagenItem
                {
                    Naam = "Cola",
                    Prijs = 1
                };
                _dbContext.WinkelwagenItems.Add(item1);
                WinkelwagenItem item2 = new WinkelwagenItem
                {
                    Naam = "Bier",
                    Prijs = 2
                };
                _dbContext.WinkelwagenItems.Add(item2);
                Gebruiker g = new Gebruiker();
                g.Voornaam = "VoornaamLucas";
                g.Achternaam = "AchternaamLucas";
                g.Email = "user@example.com";
                g.Type = Enum.GebruikerType.Admin;
                await _userManager.CreateAsync(g, "Test123!123!");
                _dbContext.SaveChanges();

            }

        }
    }
}
