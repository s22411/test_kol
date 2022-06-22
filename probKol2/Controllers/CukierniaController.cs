using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using probKol.Models;
using probKol2.Models.DTOs;
using probKol2.Services;

namespace probKol2.Controllers
{
    [Route("api")]
    public class CukierniaController : ControllerBase
    {
        private readonly IDbService _dbService;

        public CukierniaController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        [Route("orders")]
        public async Task<IActionResult> GetZamowienia(string nazwisko)
        {
            try
            {
                return Ok(await _dbService.GetZamowienia(nazwisko));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet]
        [Route("clients/{idKlienta}/orders")]
        public async Task<IActionResult> AddNewOrder([FromBody] NoweZamowienieDTO noweZamowienie, int idKlienta)
        {
            throw new NotImplementedException();
        }

    }
}