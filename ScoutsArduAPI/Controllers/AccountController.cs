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

        [HttpPost("logout")]
        public async Task<ActionResult<string>> LogUit()
        {
            Gebruiker user = _gebruikerRepository.GetBy(User.Identity.Name);
            if (user != null)
            {
                await _signInManager.SignOutAsync();
                return Ok("uitgelogd");
            }
            return BadRequest();
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> CreateToken(LoginDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

                if (result.Succeeded)
                {
                    string token = GetToken(user);
                    return Created("", token); //returns only the token                   
                }
            } 
            return BadRequest();
        }

        [HttpPost("facebooklogin")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> loginFacebookUser(FacebookLoginDTO model)
        {
            try
            {


                Gebruiker user = _gebruikerRepository.GetBy(model.Email);

                if (user != null)
                {
                    try
                    {
                        Debug.WriteLine(user);
                        //await _signInManager.SignInAsync(user, true);
                        string token = GetToken(user);
                        return Created("", token); //returns only the token  
                    }

                    catch (Exception e)
                    {
                        return BadRequest(e.Message);
                    }
                }
                else
                {
                    Gebruiker g = new Gebruiker
                    {
                        Email = model.Email,
                        Voornaam = model.Voornaam,
                        Achternaam = model.Achternaam,
                        //Foto = model.Foto,
                        Type = Enum.GebruikerType.Leiding,
                        UserName = model.Email,
                        //TelNr = model.TelNr
                        IsFacebookUser = true
                    };

                    var result = await _userManager.CreateAsync(g);

                    if (result.Succeeded)
                    {
                        _gebruikerRepository.SaveChanges();
                        string token = GetToken(g);
                        return Created("", token);
                    }
                    return BadRequest();

                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
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
                UserName = model.Email,
                TelNr = model.TelNr
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

        [HttpGet]
        public ActionResult<GebruikerExportDTO> GetGebruiker()
        {
            Gebruiker g = _gebruikerRepository.GetBy(User.Identity.Name);
            if (g == null) return NotFound();
            return new GebruikerExportDTO(g);
        }

        [HttpDelete("{id}")]
        public ActionResult<GebruikerExportDTO> VerwijderGebruiker(string id)
        {
            Gebruiker g = _gebruikerRepository.GetBy(id);
            if (g == null)
            {
                return NotFound();
            }
            _gebruikerRepository.Delete(g);
            _gebruikerRepository.SaveChanges();
            return new GebruikerExportDTO(g);
        }

        [HttpGet("allUsers")]
        [AllowAnonymous]
        public IEnumerable<GebruikerExportDTO> GetGebruikers()
        {
            return _gebruikerRepository.GetAll().Select(g => new GebruikerExportDTO(g)).ToList();
        }

        [HttpPut]
        public ActionResult<GebruikerExportDTO> PutGebruiker(GebruikerDTO dto)
        {
            Gebruiker g = _gebruikerRepository.GetBy(User.Identity.Name);
            g.Achternaam = dto.achternaam;
            g.Voornaam = dto.voornaam;
            g.TelNr = dto.telnr;
            _gebruikerRepository.Update(g);
            _gebruikerRepository.SaveChanges();
            return new GebruikerExportDTO(g);
        }
    
    }
}