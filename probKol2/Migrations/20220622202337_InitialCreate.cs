using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace probKol2.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klienci",
                columns: table => new
                {
                    IdKlient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klienci", x => x.IdKlient);
                });

            migrationBuilder.CreateTable(
                name: "Pracownicy",
                columns: table => new
                {
                    IdPracownik = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pracownicy", x => x.IdPracownik);
                });

            migrationBuilder.CreateTable(
                name: "WyrobyCukiernicze",
                columns: table => new
                {
                    IdWyorbuCukierniczego = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CenaZaSzt = table.Column<float>(type: "real", nullable: false),
                    Typ = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WyrobyCukiernicze", x => x.IdWyorbuCukierniczego);
                });

            migrationBuilder.CreateTable(
                name: "Zamowienia",
                columns: table => new
                {
                    IdZamowienia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataPrzyjecia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataRealizacji = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Uwagi = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    IdKlient = table.Column<int>(type: "int", nullable: false),
                    IdPracownik = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamowienia", x => x.IdZamowienia);
                    table.ForeignKey(
                        name: "FK_Zamowienia_Klienci_IdKlient",
                        column: x => x.IdKlient,
                        principalTable: "Klienci",
                        principalColumn: "IdKlient",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zamowienia_Pracownicy_IdPracownik",
                        column: x => x.IdPracownik,
                        principalTable: "Pracownicy",
                        principalColumn: "IdPracownik",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zamowienia_WyrobyCukiernicze",
                columns: table => new
                {
                    IdWyorbuCukierniczego = table.Column<int>(type: "int", nullable: false),
                    IdZamowienia = table.Column<int>(type: "int", nullable: false),
                    Ilosc = table.Column<int>(type: "int", nullable: false),
                    Uwagi = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamowienia_WyrobyCukiernicze", x => new { x.IdZamowienia, x.IdWyorbuCukierniczego });
                    table.ForeignKey(
                        name: "FK_Zamowienia_WyrobyCukiernicze_WyrobyCukiernicze_IdWyorbuCukierniczego",
                        column: x => x.IdWyorbuCukierniczego,
                        principalTable: "WyrobyCukiernicze",
                        principalColumn: "IdWyorbuCukierniczego",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zamowienia_WyrobyCukiernicze_Zamowienia_IdZamowienia",
                        column: x => x.IdZamowienia,
                        principalTable: "Zamowienia",
                        principalColumn: "IdZamowienia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Klienci",
                columns: new[] { "IdKlient", "Imie", "Nazwisko" },
                values: new object[,]
                {
                    { 1, "Jan", "Kowalski" },
                    { 2, "Anna", "Nowak" },
                    { 3, "Andrzej", "Kowalski" }
                });

            migrationBuilder.InsertData(
                table: "Pracownicy",
                columns: new[] { "IdPracownik", "Imie", "Nazwisko" },
                values: new object[,]
                {
                    { 1, "Jan", "Kowalski" },
                    { 2, "Anna", "Nowak" },
                    { 3, "Andrzej", "Kowalski" }
                });

            migrationBuilder.InsertData(
                table: "WyrobyCukiernicze",
                columns: new[] { "IdWyorbuCukierniczego", "CenaZaSzt", "Nazwa", "Typ" },
                values: new object[,]
                {
                    { 1, 5.99f, "Ciastko", "Ciasto" },
                    { 2, 7.99f, "Tort", "Tort" },
                    { 3, 5.99f, "Kremowka", "Kremowka" }
                });

            migrationBuilder.InsertData(
                table: "Zamowienia",
                columns: new[] { "IdZamowienia", "DataPrzyjecia", "DataRealizacji", "IdKlient", "IdPracownik", "Uwagi" },
                values: new object[] { 1, new DateTime(2022, 6, 22, 22, 23, 36, 671, DateTimeKind.Local).AddTicks(2750), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, null });

            migrationBuilder.InsertData(
                table: "Zamowienia",
                columns: new[] { "IdZamowienia", "DataPrzyjecia", "DataRealizacji", "IdKlient", "IdPracownik", "Uwagi" },
                values: new object[] { 2, new DateTime(2022, 6, 23, 1, 26, 36, 673, DateTimeKind.Local).AddTicks(1207), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, null });

            migrationBuilder.InsertData(
                table: "Zamowienia_WyrobyCukiernicze",
                columns: new[] { "IdWyorbuCukierniczego", "IdZamowienia", "Ilosc", "Uwagi" },
                values: new object[,]
                {
                    { 1, 1, 1, "Ciastko na zimno" },
                    { 2, 1, 2, null },
                    { 3, 1, 1, "Kremowka na zimno" },
                    { 1, 2, 1, "Ciastko na ciepło" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienia_IdKlient",
                table: "Zamowienia",
                column: "IdKlient");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienia_IdPracownik",
                table: "Zamowienia",
                column: "IdPracownik");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienia_WyrobyCukiernicze_IdWyorbuCukierniczego",
                table: "Zamowienia_WyrobyCukiernicze",
                column: "IdWyorbuCukierniczego");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zamowienia_WyrobyCukiernicze");

            migrationBuilder.DropTable(
                name: "WyrobyCukiernicze");

            migrationBuilder.DropTable(
                name: "Zamowienia");

            migrationBuilder.DropTable(
                name: "Klienci");

            migrationBuilder.DropTable(
                name: "Pracownicy");
        }
    }
}
