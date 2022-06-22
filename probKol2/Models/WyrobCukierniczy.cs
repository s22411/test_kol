using System.Collections.Generic;

namespace probKol.Models
{
    public class WyrobCukierniczy
    {
        public WyrobCukierniczy()
        {
            Zamowienie_WyrobCukierniczy = new HashSet<Zamowienie_WyrobCukierniczy>();
        }

        public int IdWyrobuCukierniczego { get; set; }
        public string Nazwa { get; set; }
        public float CenaZaSzt { get; set; }
        public string Typ { get; set; }
        public virtual IEnumerable<Zamowienie_WyrobCukierniczy> Zamowienie_WyrobCukierniczy { get; set; }
        // public virtual IEnumerable<Zamowienie> Zamowienia { get; set; }
    }
}