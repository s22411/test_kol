using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace probKol.Models.DTOs
{
    public class Zamowienie_WyrobCukierniczy
    {
        public int IdWyorbuCukierniczego { get; set; }
        public int IdZamownienia { get; set; }
        public int Ilosc { get; set; }
        public string? Uwagi { get; set; }
        public virtual WyrobCukierniczy WyrobCukierniczy { get; set; }
        public virtual Zamowienie Zamowienie { get; set; }
    }
}