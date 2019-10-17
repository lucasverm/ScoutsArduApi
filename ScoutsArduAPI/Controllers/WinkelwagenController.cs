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
    public class WinkelwagenController : ControllerBase
    {
        private readonly IWinkelwagenRepository _winkelwagenRepository;
        private readonly IGebruikerRepository _gebruikerRepository;

        public WinkelwagenController(IWinkelwagenRepository winkelwagenRepository, IGebruikerRepository gebruikerRepository)
        {
            _winkelwagenRepository = winkelwagenRepository;
            _gebruikerRepository = gebruikerRepository;
        } 

        [HttpGet("{id}")]
        public ActionResult<Winkelwagen> GetWinkelwagen(int id)
        {
            Winkelwagen w = _winkelwagenRepository.GetBy(id);
            if (w == null) return NotFound();
            return w;
        }

        [HttpDelete("{id}")]
        public ActionResult<Winkelwagen> VerwijderWinkelwagen(int id)
        {
            Winkelwagen w = _winkelwagenRepository.GetBy(id);
            if (w == null) return NotFound();
            _winkelwagenRepository.Delete(w);
            _winkelwagenRepository.SaveChanges();
            return w;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Winkelwagen>> stamHistoriek()
        {
            return _winkelwagenRepository.GetAll().OrderBy(t => t.Datum).ToList();
        }

        [HttpPost]
        public ActionResult<WinkelwagenExportDTO> PostWinkelwagen(WinkelwagenDTO winkelwagenDTO)
        {
            Winkelwagen winkelwagen = new Winkelwagen
            {
                Items = winkelwagenDTO.Items.Select(t => t.getWinkelwagenItem()).ToList(),
                Datum = DateTime.Today,
                Betaald = winkelwagenDTO.Betaald,
                Gebruiker = _gebruikerRepository.GetBy(User.Identity.Name)
            };
            _winkelwagenRepository.Add(winkelwagen);
            _winkelwagenRepository.SaveChanges();
            return new WinkelwagenExportDTO(winkelwagen);
        }


    }
}