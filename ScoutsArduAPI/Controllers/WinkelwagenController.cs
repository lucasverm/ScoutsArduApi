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
        public ActionResult<WinkelwagenExportDTO> GetWinkelwagen(int id)
        {
            Winkelwagen w = _winkelwagenRepository.GetBy(id);
            if (w == null) return NotFound();
            return new WinkelwagenExportDTO(w);
        }


        [HttpPut("{id}/changeBetaald")]
        public ActionResult<WinkelwagenExportDTO> ChangeBetaaldWinkelwagen(int id)
        {
            Winkelwagen w = _winkelwagenRepository.GetBy(id);
            if (w == null) return NotFound();
            if (w.Betaald == false)
            {
                w.Betaald = true;
            } else
            {
                w.Betaald = false;
            }
            _winkelwagenRepository.Update(w);
            _winkelwagenRepository.SaveChanges();
            return new WinkelwagenExportDTO(w);
        }

        [HttpDelete("{id}")]
        public ActionResult<WinkelwagenExportDTO> VerwijderWinkelwagen(int id)
        {
            Winkelwagen w = _winkelwagenRepository.GetBy(id);
            if (w == null) return NotFound();
            _winkelwagenRepository.Delete(w);
            _winkelwagenRepository.SaveChanges();
            return new WinkelwagenExportDTO(w);
        }

        [AllowAnonymous]
        [HttpDelete("DeleteAlleWinkelwagens")]
        public ActionResult VerwijderAlleWinkelwagen()
        {
            foreach (Winkelwagen winkelwagen in _winkelwagenRepository.GetAll())
            {
                _winkelwagenRepository.Delete(winkelwagen);
            }
            _winkelwagenRepository.SaveChanges();
            return Ok();
        }

        [HttpGet("winkelwagens")]
        public ActionResult<IEnumerable<WinkelwagenExportDTO>> GetWinkelwagensOfGebruiker()
        {
            Gebruiker g = _gebruikerRepository.GetBy(User.Identity.Name);
            if (g == null) return NotFound();

            return g.Winkelwagens.OrderByDescending(t => t.Datum).Select(t => new WinkelwagenExportDTO(_winkelwagenRepository.GetBy(t.Id))).ToList();
        
        }

        [HttpGet("stamhistoriek")]
        public ActionResult<IEnumerable<WinkelwagenExportDTO>> stamHistoriek()
        {
            var winkelwagens = _winkelwagenRepository.GetAll().OrderByDescending(t => t.Datum).ToList();
            return winkelwagens.Select(t => new WinkelwagenExportDTO(_winkelwagenRepository.GetBy(t.Id))).ToList();
        }

        [AllowAnonymous]
        [HttpGet("WinkelwagenItems")]
        public ActionResult<IEnumerable<WinkelwagenItem>> GetWinkelwagenItems()
        {
            return _winkelwagenItemRepository.GetAll().ToList();
        }

        [HttpPost]
        public ActionResult<WinkelwagenExportDTO> PostWinkelwagen(WinkelwagenDTO winkelwagenDTO)
        {      
            List<MTMWinkelwagenWinkelwagenItem> items = new List<MTMWinkelwagenWinkelwagenItem>();
            foreach( var item in winkelwagenDTO.Items)
            {
                WinkelwagenItem wi = _winkelwagenItemRepository.GetBy(item.item.Id);
                if (wi == null)
                    return NotFound("het winkelwagenItem met id = " + item.item.Id.ToString() + " kon niet worden gevonden");
                MTMWinkelwagenWinkelwagenItem m = new MTMWinkelwagenWinkelwagenItem();
                m.aantal = item.Aantal;
                m.WinkelwagenItem = wi;
                items.Add(m);
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