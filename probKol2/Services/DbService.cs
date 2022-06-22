using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using probKol.Models;
using probKol2.Models.DTOs;

namespace probKol2.Services
{
    public class DbService : IDbService
    {
        private readonly MainDbContext _context;

        public DbService(MainDbContext context)
        {
            _context = context;
        }

        public async Task<List<ZamowienieDTO>> AddNewOrder(NoweZamowienieDTO noweZamowienie, int idKlienta)
        {
            using var transaction = _context.Database.BeginTransaction();

            foreach (var wyrob in noweZamowienie.Wyroby)
            {
                if (!await _context.WyrobyCukiernicze.AnyAsync(w => w.Nazwa == wyrob.Wyrob))
                {
                    throw new Exception($"Nie ma w bazie wyrobu: {wyrob.Wyrob}");
                }
            }

            await _context.Zamowienia.AddAsync(new Zamowienie
            {
                DataPrzyjecia = DateTime.Parse(noweZamowienie.DataPrzyjecia),
                Uwagi = noweZamowienie.Uwagi,
                IdKlient = idKlienta,
                
            });

            throw new NotImplementedException();
        }

        public async Task<List<ZamowienieDTO>> GetZamowienia(string nazwisko)
        {
            if (!await _context.Klienci.AnyAsync(k => k.Nazwisko == nazwisko))
            {
                throw new Exception("No such client");
            }

            return await _context.Zamowienia
                    .Where(z => string.IsNullOrWhiteSpace(nazwisko) || string.IsNullOrEmpty(nazwisko) || z.Klient.Nazwisko == nazwisko)
                    .Select(z => new ZamowienieDTO
                    {
                        IdZamowienia = z.IdZamowienia,
                        DataPrzyjecia = z.DataPrzyjecia,
                        DataRealizacji = z.DataRealizacji,
                        Uwagi = z.Uwagi,
                        IdKlient = z.IdKlient,
                        IdPracownik = z.IdPracownik,
                        WyrobyCukiernicze = z.Zamowienie_WyrobCukierniczy
                            .Select(zwc => new WyrobCukierniczyDTO
                            {
                                Nazwa = zwc.WyrobCukierniczy.Nazwa,
                                CenaZaSzt = zwc.WyrobCukierniczy.CenaZaSzt,
                                Typ = zwc.WyrobCukierniczy.Typ,
                                Ilosc = zwc.Ilosc
                            }).ToList()
                    }).ToListAsync();
        }
    }
}