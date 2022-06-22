namespace probKol.Models
{
    public class Zamowienie_WyrobCukierniczy
    {
        public int IdWyorbuCukierniczego { get; set; }
        public int IdZamowienia { get; set; }
        public int Ilosc { get; set; }
        public string? Uwagi { get; set; }
        public virtual WyrobCukierniczy WyrobCukierniczy { get; set; }
        public virtual Zamowienie Zamowienie { get; set; }
    }
}