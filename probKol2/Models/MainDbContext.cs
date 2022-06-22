using System;
using Microsoft.EntityFrameworkCore;

namespace probKol.Models
{
    public class MainDbContext : DbContext
    {
        public MainDbContext()
        {
        }

        public MainDbContext(DbContextOptions<MainDbContext> options)
            : base(options)
        {
        }

        public DbSet<Klient> Klienci { get; set; }
        public DbSet<Pracownik> Pracownicy { get; set; }
        public DbSet<WyrobCukierniczy> WyrobyCukiernicze { get; set; }
        public DbSet<Zamowienie_WyrobCukierniczy> Zamowienia_WyrobyCukiernicze { get; set; }
        public DbSet<Zamowienie> Zamowienia { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Klient>(entity => 
            {
                entity.HasKey(e => e.IdKlient);
                entity.Property(e => e.Imie).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Nazwisko).HasMaxLength(60).IsRequired();

                entity.HasData(
                    new Klient { IdKlient = 1, Imie = "Jan", Nazwisko = "Kowalski" },
                    new Klient { IdKlient = 2, Imie = "Anna", Nazwisko = "Nowak" },
                    new Klient { IdKlient = 3, Imie = "Andrzej", Nazwisko = "Kowalski" }
                );
            });

            builder.Entity<Pracownik>(entity =>
            {
                entity.HasKey(e => e.IdPracownik);
                entity.Property(e => e.Imie).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Nazwisko).HasMaxLength(60).IsRequired();

                entity.HasData(
                    new Pracownik { IdPracownik = 1, Imie = "Jan", Nazwisko = "Kowalski" },
                    new Pracownik { IdPracownik = 2, Imie = "Anna", Nazwisko = "Nowak" },
                    new Pracownik { IdPracownik = 3, Imie = "Andrzej", Nazwisko = "Kowalski" }
                );
            });

            builder.Entity<WyrobCukierniczy>(entity =>
            {
                entity.HasKey(e => e.IdWyorbuCukierniczego);
                entity.Property(e => e.Nazwa).HasMaxLength(200).IsRequired();
                entity.Property(e => e.CenaZaSzt).IsRequired();
                entity.Property(e => e.Typ).HasMaxLength(40).IsRequired();

                entity.HasData(
                    new WyrobCukierniczy { IdWyorbuCukierniczego = 1, Nazwa = "Ciastko", CenaZaSzt = 5.99f, Typ = "Ciasto" },
                    new WyrobCukierniczy { IdWyorbuCukierniczego = 2, Nazwa = "Tort", CenaZaSzt = 7.99f, Typ = "Tort" },
                    new WyrobCukierniczy { IdWyorbuCukierniczego = 3, Nazwa = "Kremowka", CenaZaSzt = 5.99f, Typ = "Kremowka" }
                );
            });

            builder.Entity<Zamowienie_WyrobCukierniczy>(entity =>
            {
                entity.HasKey(e => new { e.IdZamowienia, e.IdWyorbuCukierniczego });
                entity.Property(e => e.Ilosc).IsRequired();
                entity.Property(e => e.Uwagi).HasMaxLength(300);

                entity.HasOne(e => e.Zamowienie)
                    .WithMany(e => e.Zamowienie_WyrobCukierniczy)
                    .HasForeignKey(e => e.IdZamowienia);
                entity.HasOne(e => e.WyrobCukierniczy)
                    .WithMany(e => e.Zamowienie_WyrobCukierniczy)
                    .HasForeignKey(e => e.IdWyorbuCukierniczego);


                entity.HasData(
                    new Zamowienie_WyrobCukierniczy { IdZamowienia = 1, IdWyorbuCukierniczego = 1, Ilosc = 1, Uwagi = "Ciastko na zimno" },
                    new Zamowienie_WyrobCukierniczy { IdZamowienia = 1, IdWyorbuCukierniczego = 2, Ilosc = 2 },
                    new Zamowienie_WyrobCukierniczy { IdZamowienia = 1, IdWyorbuCukierniczego = 3, Ilosc = 1, Uwagi = "Kremowka na zimno" },
                    new Zamowienie_WyrobCukierniczy { IdZamowienia = 2, IdWyorbuCukierniczego = 1, Ilosc = 1, Uwagi = "Ciastko na ciepło" }
                );
            });

            builder.Entity<Zamowienie>(entity =>
            {
                entity.HasKey(e => e.IdZamowienia);
                entity.Property(e => e.DataPrzyjecia).IsRequired();
                entity.Property(e => e.Uwagi).HasMaxLength(300);

                entity.HasMany(e => e.Zamowienie_WyrobCukierniczy)
                    .WithOne(e => e.Zamowienie)
                    .HasForeignKey(e => e.IdZamowienia);
                entity.HasOne(e => e.Klient)
                    .WithMany(e => e.Zamowienia)
                    .HasForeignKey(e => e.IdKlient);
                entity.HasOne(e => e.Pracownik)
                    .WithMany(e => e.Zamowienia)
                    .HasForeignKey(e => e.IdPracownik);

                entity.HasData(
                    new Zamowienie { IdZamowienia = 1, IdKlient = 1, IdPracownik = 1, DataPrzyjecia = DateTime.Now },
                    new Zamowienie { IdZamowienia = 2, IdKlient = 2, IdPracownik = 2, DataPrzyjecia = DateTime.Now.AddHours(3).AddMinutes(3) }
                );
            });
        }
    }
}