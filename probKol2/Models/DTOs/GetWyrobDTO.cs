using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace probKol2.Models.DTOs
{
    public class GetWyrobDTO
    {
        public string Nazwa { get; set; }
        public float CenaZaSzt { get; set; }
        public string Typ { get; set; }
    }
}