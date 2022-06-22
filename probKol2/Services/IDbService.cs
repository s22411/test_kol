using System.Collections.Generic;
using System.Threading.Tasks;
using probKol2.Models.DTOs;

namespace probKol2.Services
{
    public interface IDbService
    {
        public Task<List<ZamowienieDTO>> GetZamowienia(string nazwisko);
        public Task<List<ZamowienieDTO>> AddNewOrder(NoweZamowienieDTO noweZamowienie, int idKlienta);
    }
}