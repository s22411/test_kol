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


// namespace PowtKol2.Services
// {
//     public class DbService : IDbService
//     {
//         private readonly MainDbContext _dbContext;
//         public DbService(MainDbContext dbContext)
//         {
//             _dbContext = dbContext;
//         }

//         public async Task AddZamowienie(int IdKlient, AddZamowienieDTO zamowienie)
//         {
//             using var transaction = _dbContext.Database.BeginTransaction();

//             ICollection<Zamowienie_WyrobCukierniczy> zamowienia_wyroby = new List<Zamowienie_WyrobCukierniczy>();

//             foreach (var wyrob in zamowienie.wyroby)
//             {
//                 if (await _dbContext.WyrobCukiernicze.Where(w => w.IdWyrobuCukierniczego == wyrob.IdWyrobuCukierniczego).FirstOrDefaultAsync() == null)
//                     throw new System.Exception($"No such wyrob cukierniczy ID = {wyrob.IdWyrobuCukierniczego} exists in the database.");
//             }

//             if (await _dbContext.Klienci.Where(k => k.IdKlient == IdKlient).FirstOrDefaultAsync() == null)
//                 throw new System.Exception("No such klient exists in the database.");

//             var newZamowienie = new Zamowienie
//             {
//                 //IdZamowienia = zamowienie.IdZamowienia,
//                 DataPrzyjecia = zamowienie.DataPrzyjecia,
//                 DataRealizacji = zamowienie.DataRealizacji,
//                 Uwagi = zamowienie.Uwagi,
//                 IdKlient = IdKlient,
//                 IdPracownik = zamowienie.IdPracownik,
//                 Klient = _dbContext.Klienci.Where(k => k.IdKlient == IdKlient).FirstOrDefault(),
//                 Pracownik = _dbContext.Pracownicy.Where(p => p.IdPracownika == zamowienie.IdPracownik).FirstOrDefault(),
//                 Zamowienia_WyrobyCukiernicze = new List<Zamowienie_WyrobCukierniczy>()
//             };

//             _dbContext.Zamowienia.Add(newZamowienie);

//             await _dbContext.SaveChangesAsync();

//             foreach (var wyrob in zamowienie.wyroby)
//             {
//                 zamowienia_wyroby.Add(new Zamowienie_WyrobCukierniczy
//                 {
//                     IdWyrobuCukierniczego = wyrob.IdWyrobuCukierniczego,
//                     IdZamowienia = newZamowienie.IdZamowienia,
//                     Ilosc = wyrob.Ilosc,
//                     Uwagi = wyrob.Uwagi,
//                     WyrobCukierniczy = _dbContext.WyrobCukiernicze.Where(wc => wc.IdWyrobuCukierniczego == wyrob.IdWyrobuCukierniczego).FirstOrDefault(),
//                     Zamowienie = _dbContext.Zamowienia.Where(z => z.IdZamowienia == newZamowienie.IdZamowienia).FirstOrDefault()
//                 });
//             }

//             newZamowienie.Zamowienia_WyrobyCukiernicze = zamowienia_wyroby;

//             await _dbContext.SaveChangesAsync();

//             transaction.Commit();
//         }

//         public async Task<IEnumerable<ZamowienieDTO>> GetZamowienia(string nazwisko)
//         {
//             if (string.IsNullOrWhiteSpace(nazwisko))
//             {
//                 return await _dbContext.Zamowienia
//                     .Select(z => new ZamowienieDTO
//                     {
//                         IdZamowienia = z.IdZamowienia,
//                         DataPrzyjecia = z.DataPrzyjecia,
//                         DataRealizacji = z.DataRealizacji,
//                         Uwagi = z.Uwagi,
//                         IdKlient = z.IdKlient,
//                         IdPracownik = z.IdPracownik,
//                         WyrobyCukiernicze = z.Zamowienia_WyrobyCukiernicze
//                             .Select(zwc => new WyrobCukierniczyDTO
//                             {
//                                 Nazwa = zwc.WyrobCukierniczy.Nazwa,
//                                 CenaZaSzt = zwc.WyrobCukierniczy.CenaZaSzt,
//                                 Typ = zwc.WyrobCukierniczy.Typ,
//                                 Ilosc = zwc.Ilosc
//                             }).ToList()
//                     }).ToListAsync();
//             }
//             else
//             {
//                 if (await _dbContext.Klienci.Where(k => k.Nazwisko == nazwisko).FirstOrDefaultAsync() == null)
//                     throw new System.Exception("No such client exists in the database.");

//                 return await _dbContext.Zamowienia
//                     .Where(z => z.Klient.Nazwisko == nazwisko)
//                     .Select(z => new ZamowienieDTO
//                     {
//                         IdZamowienia = z.IdZamowienia,
//                         DataPrzyjecia = z.DataPrzyjecia,
//                         DataRealizacji = z.DataRealizacji,
//                         Uwagi = z.Uwagi,
//                         IdKlient = z.IdKlient,
//                         IdPracownik = z.IdPracownik,
//                         WyrobyCukiernicze = z.Zamowienia_WyrobyCukiernicze
//                             .Select(zwc => new WyrobCukierniczyDTO
//                             {
//                                 Nazwa = zwc.WyrobCukierniczy.Nazwa,
//                                 CenaZaSzt = zwc.WyrobCukierniczy.CenaZaSzt,
//                                 Typ = zwc.WyrobCukierniczy.Typ,
//                                 Ilosc = zwc.Ilosc
//                             }).ToList()
//                     }).ToListAsync();
//             }
//         }
//     }
// }
