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
        private readonly IWinkelwagenItemRepository _winkelwagenItemRepository;
        private readonly IGebruikerRepository _gebruikerRepository;

        public WinkelwagenController(IWinkelwagenItemRepository winkelwagenItemRepository, IWinkelwagenRepository winkelwagenRepository, IGebruikerRepository gebruikerRepository)
        {
            _winkelwagenRepository = winkelwagenRepository;
            _winkelwagenItemRepository = winkelwagenItemRepository;
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

        [HttpGet("winkelwagens")]
        public ActionResult<IEnumerable<WinkelwagenExportDTO>> GetWinkelwagensOfGebruiker()
        {
            Gebruiker g = _gebruikerRepository.GetBy(User.Identity.Name);
            if (g == null) return NotFound();
            return g.Winkelwagens.Select(t => new WinkelwagenExportDTO(_winkelwagenRepository.GetBy(t.Id))).ToList();
        }


        [HttpGet("stamhistoriek")]
        public ActionResult<IEnumerable<Winkelwagen>> stamHistoriek()
        {
            return _winkelwagenRepository.GetAll().OrderBy(t => t.Datum).ToList();
        }

        [HttpPost]
        public ActionResult<WinkelwagenExportDTO> PostWinkelwagen(WinkelwagenDTO winkelwagenDTO)
        {
            List<WinkelwagenItem> items = new List<WinkelwagenItem>();
            foreach( var item in winkelwagenDTO.Items)
            {
                WinkelwagenItem wi = _winkelwagenItemRepository.GetBy(item.Id);
                if (wi == null)
                    return NotFound("het winkelwagenItem met id = " + item.Id.ToString() + " kon niet worden gevonden");
                wi.Aantal = item.Aantal;
                items.Add(wi);
            }

            Winkelwagen winkelwagen = new Winkelwagen
            {
                Items = items,
                Datum = DateTime.Now,
                Betaald = winkelwagenDTO.Betaald,
                Gebruiker = _gebruikerRepository.GetBy(User.Identity.Name)
            };
    
            _winkelwagenRepository.Add(winkelwagen);
            _winkelwagenRepository.SaveChanges();
            return new WinkelwagenExportDTO(winkelwagen);
        }


    }
}