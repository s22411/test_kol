using System.Collections.Generic;

namespace probKol.Models
{
    public class Zamowienie_WyrobCukierniczy
    {
        // public Zamowienie_WyrobCukierniczy()
        // {
        //     Zamowienie = new HashSet<Zamowienie>();
        // }
        public int IdWyrobuCukierniczego { get; set; }
        public int IdZamowienia { get; set; }
        public int Ilosc { get; set; }
        public string Uwagi { get; set; }
        public virtual WyrobCukierniczy WyrobCukierniczy { get; set; }
        public virtual Zamowienie Zamowienie { get; set; }
    }
}