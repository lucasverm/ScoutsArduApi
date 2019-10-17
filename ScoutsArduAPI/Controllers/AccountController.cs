using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ScoutsArduAPI.DTO;
using ScoutsArduAPI.Models;

namespace ScoutsArduAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<Gebruiker> _signInManager;
        private readonly UserManager<Gebruiker> _userManager;
        private readonly IGebruikerRepository _gebruikerRepository;
        private readonly IConfiguration _config;
        public AccountController(SignInManager<Gebruiker> signInManager, UserManager<Gebruiker> userManager,
            IGebruikerRepository gebruikerRepository, IConfiguration config)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _gebruikerRepository = gebruikerRepository;
            _config = config;
        }
        /// <summary>
        /// Geeft winkelwagens van een specifieke gebruiker
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Winkelwagens</returns>
        
        [HttpGet("winkelwagens")]
        public ActionResult<IEnumerable<Winkelwagen>> GetWinkelwagensOfGebruiker()
        {
            Gebruiker g = _gebruikerRepository.GetBy(User.Identity.Name);
            if (g == null) return NotFound();
            return g.Winkelwagens;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> CreateToken(LoginDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            Debug.WriteLine("-------------- in login------");
            if (user != null)
            {
                Debug.WriteLine("--------------user juist------");

                var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

                if (result.Succeeded)
                {
                    string token = GetToken(user);
                    return Created("", token); //returns only the token                   
                }
            } else
            {
                Debug.WriteLine("--------------user fout------");
            }
            return BadRequest();
        }

        private string GetToken(Gebruiker g)
        {      // Createthetoken
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, g.Email),
                new Claim(JwtRegisteredClaimNames.UniqueName, g.UserName) };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(null, null,
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> Register(RegisterDTO model)
        {
            Gebruiker g = new Gebruiker
            {
                Email = model.Email,
                Voornaam = model.Voornaam,
                Achternaam = model.Achternaam,
                Foto = model.Foto,
                Type = model.Type,
                UserName = model.Email
            };

            var result = await _userManager.CreateAsync(g, model.Password);

            if (result.Succeeded)
            {
                _gebruikerRepository.SaveChanges();
                string token = GetToken(g);
                return Created("", token);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Winkelwagen>> GetGebruiker(string id)
        {
            Gebruiker g = _gebruikerRepository.GetBy(id);
            if (g == null) return NotFound();
            return g.Winkelwagens;
        }

        [HttpDelete("{id}")]
        public ActionResult<Gebruiker> VerwijderGebruiker(string id)
        {
            Gebruiker g = _gebruikerRepository.GetBy(id);
            if (g == null)
            {
                return NotFound();
            }
            _gebruikerRepository.Delete(g);
            _gebruikerRepository.SaveChanges();
            return g;
        }

        [HttpGet("allUsers")]
        [AllowAnonymous]
        public IEnumerable<Gebruiker> GetGebruikers()
        {
            return _gebruikerRepository.GetAll().ToList();
        }

        [HttpPut("{id}")]
        public ActionResult<Gebruiker> PutGebruiker(string id, Gebruiker gebruiker)
        {
            Gebruiker g = _gebruikerRepository.GetBy(id);
            if (!g.Id.Equals(id))
                return BadRequest();
            _gebruikerRepository.Update(gebruiker);
            _gebruikerRepository.SaveChanges();
            return g;
        }
    
    }
}