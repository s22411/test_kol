using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace probKol2.Models.DTOs
{
    public class NoweZamowienieDTO
    {
        public string DataPrzyjecia { get; set; }
        public string Uwagi { get; set; }
        public IEnumerable<WyrobDTO> Wyroby { get; set; }
    }
}