using System;
using System.Collections.Generic;

namespace probKol2.Models.DTOs
{
    public class ZamowienieDTO
    {
        public int IdZamowienia { get; set; }
        public DateTime DataPrzyjecia { get; set; }
        public DateTime? DataRealizacji { get; set; }
        public string? Uwagi { get; set; }
        public int IdKlient { get; set; }
        public int IdPracownik { get; set; }
        public ICollection<WyrobCukierniczyDTO> WyrobyCukiernicze { get; set; }
    }
}
