using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace probKol.Models.DTOs
{
    public class WyrobCukierniczy
    {
        public int IdWyorbuCukierniczego { get; set; }
        public string Nazwa { get; set; }
        public float CenaZaSzt { get; set; }
        public string Typ { get; set; }
        public virtual ICollection<Zamowienie_WyrobCukierniczy> Zamowienie_WyrobCukierniczy { get; set; }
    }
}