// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using probKol.Models;

namespace probKol2.Migrations
{
    [DbContext(typeof(MainDbContext))]
    [Migration("20220622202337_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("probKol.Models.Klient", b =>
                {
                    b.Property<int>("IdKlient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("IdKlient");

                    b.ToTable("Klienci");

                    b.HasData(
                        new
                        {
                            IdKlient = 1,
                            Imie = "Jan",
                            Nazwisko = "Kowalski"
                        },
                        new
                        {
                            IdKlient = 2,
                            Imie = "Anna",
                            Nazwisko = "Nowak"
                        },
                        new
                        {
                            IdKlient = 3,
                            Imie = "Andrzej",
                            Nazwisko = "Kowalski"
                        });
                });

            modelBuilder.Entity("probKol.Models.Pracownik", b =>
                {
                    b.Property<int>("IdPracownik")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("IdPracownik");

                    b.ToTable("Pracownicy");

                    b.HasData(
                        new
                        {
                            IdPracownik = 1,
                            Imie = "Jan",
                            Nazwisko = "Kowalski"
                        },
                        new
                        {
                            IdPracownik = 2,
                            Imie = "Anna",
                            Nazwisko = "Nowak"
                        },
                        new
                        {
                            IdPracownik = 3,
                            Imie = "Andrzej",
                            Nazwisko = "Kowalski"
                        });
                });

            modelBuilder.Entity("probKol.Models.WyrobCukierniczy", b =>
                {
                    b.Property<int>("IdWyorbuCukierniczego")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("CenaZaSzt")
                        .HasColumnType("real");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Typ")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("IdWyorbuCukierniczego");

                    b.ToTable("WyrobyCukiernicze");

                    b.HasData(
                        new
                        {
                            IdWyorbuCukierniczego = 1,
                            CenaZaSzt = 5.99f,
                            Nazwa = "Ciastko",
                            Typ = "Ciasto"
                        },
                        new
                        {
                            IdWyorbuCukierniczego = 2,
                            CenaZaSzt = 7.99f,
                            Nazwa = "Tort",
                            Typ = "Tort"
                        },
                        new
                        {
                            IdWyorbuCukierniczego = 3,
                            CenaZaSzt = 5.99f,
                            Nazwa = "Kremowka",
                            Typ = "Kremowka"
                        });
                });

            modelBuilder.Entity("probKol.Models.Zamowienie", b =>
                {
                    b.Property<int>("IdZamowienia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataPrzyjecia")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataRealizacji")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdKlient")
                        .HasColumnType("int");

                    b.Property<int>("IdPracownik")
                        .HasColumnType("int");

                    b.Property<string>("Uwagi")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("IdZamowienia");

                    b.HasIndex("IdKlient");

                    b.HasIndex("IdPracownik");

                    b.ToTable("Zamowienia");

                    b.HasData(
                        new
                        {
                            IdZamowienia = 1,
                            DataPrzyjecia = new DateTime(2022, 6, 22, 22, 23, 36, 671, DateTimeKind.Local).AddTicks(2750),
                            DataRealizacji = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdKlient = 1,
                            IdPracownik = 1
                        },
                        new
                        {
                            IdZamowienia = 2,
                            DataPrzyjecia = new DateTime(2022, 6, 23, 1, 26, 36, 673, DateTimeKind.Local).AddTicks(1207),
                            DataRealizacji = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdKlient = 2,
                            IdPracownik = 2
                        });
                });

            modelBuilder.Entity("probKol.Models.Zamowienie_WyrobCukierniczy", b =>
                {
                    b.Property<int>("IdZamowienia")
                        .HasColumnType("int");

                    b.Property<int>("IdWyorbuCukierniczego")
                        .HasColumnType("int");

                    b.Property<int>("Ilosc")
                        .HasColumnType("int");

                    b.Property<string>("Uwagi")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("IdZamowienia", "IdWyorbuCukierniczego");

                    b.HasIndex("IdWyorbuCukierniczego");

                    b.ToTable("Zamowienia_WyrobyCukiernicze");

                    b.HasData(
                        new
                        {
                            IdZamowienia = 1,
                            IdWyorbuCukierniczego = 1,
                            Ilosc = 1,
                            Uwagi = "Ciastko na zimno"
                        },
                        new
                        {
                            IdZamowienia = 1,
                            IdWyorbuCukierniczego = 2,
                            Ilosc = 2
                        },
                        new
                        {
                            IdZamowienia = 1,
                            IdWyorbuCukierniczego = 3,
                            Ilosc = 1,
                            Uwagi = "Kremowka na zimno"
                        },
                        new
                        {
                            IdZamowienia = 2,
                            IdWyorbuCukierniczego = 1,
                            Ilosc = 1,
                            Uwagi = "Ciastko na ciepło"
                        });
                });

            modelBuilder.Entity("probKol.Models.Zamowienie", b =>
                {
                    b.HasOne("probKol.Models.Klient", "Klient")
                        .WithMany("Zamowienia")
                        .HasForeignKey("IdKlient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("probKol.Models.Pracownik", "Pracownik")
                        .WithMany("Zamowienia")
                        .HasForeignKey("IdPracownik")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Klient");

                    b.Navigation("Pracownik");
                });

            modelBuilder.Entity("probKol.Models.Zamowienie_WyrobCukierniczy", b =>
                {
                    b.HasOne("probKol.Models.WyrobCukierniczy", "WyrobCukierniczy")
                        .WithMany("Zamowienie_WyrobCukierniczy")
                        .HasForeignKey("IdWyorbuCukierniczego")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("probKol.Models.Zamowienie", "Zamowienie")
                        .WithMany("Zamowienie_WyrobCukierniczy")
                        .HasForeignKey("IdZamowienia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WyrobCukierniczy");

                    b.Navigation("Zamowienie");
                });

            modelBuilder.Entity("probKol.Models.Klient", b =>
                {
                    b.Navigation("Zamowienia");
                });

            modelBuilder.Entity("probKol.Models.Pracownik", b =>
                {
                    b.Navigation("Zamowienia");
                });

            modelBuilder.Entity("probKol.Models.WyrobCukierniczy", b =>
                {
                    b.Navigation("Zamowienie_WyrobCukierniczy");
                });

            modelBuilder.Entity("probKol.Models.Zamowienie", b =>
                {
                    b.Navigation("Zamowienie_WyrobCukierniczy");
                });
#pragma warning restore 612, 618
        }
    }
}
