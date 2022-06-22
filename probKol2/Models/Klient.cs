using System.Collections.Generic;

namespace probKol.Models
{
    public class Klient
    {
        public Klient()
        {
            Zamowienia = new HashSet<Zamowienie>();
        }

        public int IdKlient { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public virtual IEnumerable<Zamowienie> Zamowienia { get; set; }
    }
}