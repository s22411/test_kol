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
            IEnumerable<GetZamowienieDTO> result = new List<GetZamowienieDTO>();

            foreach (var zamowienie in await _context.Zamowienia.ToListAsync())
            {
                // System.Console.WriteLine("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
                // System.Console.WriteLine(zamowienie.IdZamowienia);

                var zamowienieDTO = new GetZamowienieDTO 
                {
                    IdZamowienia = zamowienie.IdZamowienia,
                    DataPrzyjecia = zamowienie.DataPrzyjecia,
                    DataRealizacji = zamowienie.DataRealizacji,
                    Uwagi = zamowienie.Uwagi,
                    Wyroby = zamowienie.Zamowienie_WyrobCukierniczy.Join(_context.WyrobyCukiernicze, zwc => zwc.IdWyrobuCukierniczego, wc => wc.IdWyrobuCukierniczego, (zwc, wc) => wc).ToList()
                };

                result.Append(zamowienieDTO);
            }

            return Ok(result);

            // throw new NotImplementedException();
            // var zamowienia = await _context.Zamowienia.Where(z => z.IdKlienta == idKlienta).ToListAsync();
            // return Ok(zamowienia);
        }


    }
}