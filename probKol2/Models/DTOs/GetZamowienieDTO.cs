using System;
using System.Collections.Generic;

namespace probKol2.Models.DTOs
{
    public class GetZamowienieDTO
    {
        public int IdZamowienia { get; set; }
        public DateTime DataPrzyjecia { get; set; }
        public DateTime DataRealizacji { get; set; }
        public string Uwagi { get; set; }
        public IEnumerable<GetWyrobDTO> Wyroby { get; set; }
    }
}