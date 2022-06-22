using System.Collections.Generic;

namespace probKol.Models
{
    public class Pracownik
    {
        public int IdPracownik { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public virtual IEnumerable<Zamowienie> Zamowienia { get; set; }
    }
}