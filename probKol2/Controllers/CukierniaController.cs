using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using probKol.Models;
using probKol2.Models.DTOs;

namespace probKol2.Controllers
{
    [Route("api")]
    public class CukierniaController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly MainDbContext _context;

        public CukierniaController(IConfiguration config, MainDbContext context)
        {
            _config = config;
            _context = context;
        }

        [HttpGet]
        [Route("orders")]
        public async Task<IActionResult> GetZamowienia()
        {
            var zamowienia = await _context.Zamowienia.Select(z => new GetZamowienieDTO
            {
                IdZamowienia = z.IdZamowienia,
                DataPrzyjecia = z.DataPrzyjecia,
                DataRealizacji = z.DataRealizacji,
                Uwagi = z.Uwagi,
                Wyroby = z.Zamowienie_WyrobCukierniczy.Join(_context.WyrobyCukiernicze, zw => zw.IdWyrobuCukierniczego, wc => wc.IdWyrobuCukierniczego, (zw, wc) => new GetWyrobDTO { Nazwa = wc.Nazwa, CenaZaSzt = wc.CenaZaSzt, Typ = wc.Typ })
            }).ToListAsync();
            
            return Ok(zamowienia);
        }


    }
}