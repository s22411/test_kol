using System;
using System.Collections.Generic;

namespace probKol.Models
{
    public class Zamowienie
    {
        public Zamowienie()
        {
            Zamowienie_WyrobCukierniczy = new HashSet<Zamowienie_WyrobCukierniczy>();
        }
        public int IdZamowienia { get; set; }
        public DateTime DataPrzyjecia { get; set; }
        public DateTime DataRealizacji { get; set; }
        public string Uwagi { get; set; }
        public int IdKlient { get; set; }
        public int IdPracownik { get; set; }
        public virtual Klient Klient { get; set; }
        public virtual Pracownik Pracownik { get; set; }
        public virtual IEnumerable<Zamowienie_WyrobCukierniczy> Zamowienie_WyrobCukierniczy { get; set; }
        // public virtual IEnumerable<WyrobCukierniczy> Wyroby { get; set; }
    }
}