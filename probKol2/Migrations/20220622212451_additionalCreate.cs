using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace probKol2.Migrations
{
    public partial class additionalCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zamowienia_WyrobyCukiernicze_WyrobyCukiernicze_IdWyorbuCukierniczego",
                table: "Zamowienia_WyrobyCukiernicze");

            migrationBuilder.RenameColumn(
                name: "IdWyorbuCukierniczego",
                table: "Zamowienia_WyrobyCukiernicze",
                newName: "IdWyrobuCukierniczego");

            migrationBuilder.RenameIndex(
                name: "IX_Zamowienia_WyrobyCukiernicze_IdWyorbuCukierniczego",
                table: "Zamowienia_WyrobyCukiernicze",
                newName: "IX_Zamowienia_WyrobyCukiernicze_IdWyrobuCukierniczego");

            migrationBuilder.RenameColumn(
                name: "IdWyorbuCukierniczego",
                table: "WyrobyCukiernicze",
                newName: "IdWyrobuCukierniczego");

            migrationBuilder.UpdateData(
                table: "Zamowienia",
                keyColumn: "IdZamowienia",
                keyValue: 1,
                column: "DataPrzyjecia",
                value: new DateTime(2022, 6, 22, 23, 24, 51, 141, DateTimeKind.Local).AddTicks(7725));

            migrationBuilder.UpdateData(
                table: "Zamowienia",
                keyColumn: "IdZamowienia",
                keyValue: 2,
                column: "DataPrzyjecia",
                value: new DateTime(2022, 6, 23, 2, 27, 51, 143, DateTimeKind.Local).AddTicks(5974));

            migrationBuilder.AddForeignKey(
                name: "FK_Zamowienia_WyrobyCukiernicze_WyrobyCukiernicze_IdWyrobuCukierniczego",
                table: "Zamowienia_WyrobyCukiernicze",
                column: "IdWyrobuCukierniczego",
                principalTable: "WyrobyCukiernicze",
                principalColumn: "IdWyrobuCukierniczego",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zamowienia_WyrobyCukiernicze_WyrobyCukiernicze_IdWyrobuCukierniczego",
                table: "Zamowienia_WyrobyCukiernicze");

            migrationBuilder.RenameColumn(
                name: "IdWyrobuCukierniczego",
                table: "Zamowienia_WyrobyCukiernicze",
                newName: "IdWyorbuCukierniczego");

            migrationBuilder.RenameIndex(
                name: "IX_Zamowienia_WyrobyCukiernicze_IdWyrobuCukierniczego",
                table: "Zamowienia_WyrobyCukiernicze",
                newName: "IX_Zamowienia_WyrobyCukiernicze_IdWyorbuCukierniczego");

            migrationBuilder.RenameColumn(
                name: "IdWyrobuCukierniczego",
                table: "WyrobyCukiernicze",
                newName: "IdWyorbuCukierniczego");

            migrationBuilder.UpdateData(
                table: "Zamowienia",
                keyColumn: "IdZamowienia",
                keyValue: 1,
                column: "DataPrzyjecia",
                value: new DateTime(2022, 6, 22, 22, 23, 36, 671, DateTimeKind.Local).AddTicks(2750));

            migrationBuilder.UpdateData(
                table: "Zamowienia",
                keyColumn: "IdZamowienia",
                keyValue: 2,
                column: "DataPrzyjecia",
                value: new DateTime(2022, 6, 23, 1, 26, 36, 673, DateTimeKind.Local).AddTicks(1207));

            migrationBuilder.AddForeignKey(
                name: "FK_Zamowienia_WyrobyCukiernicze_WyrobyCukiernicze_IdWyorbuCukierniczego",
                table: "Zamowienia_WyrobyCukiernicze",
                column: "IdWyorbuCukierniczego",
                principalTable: "WyrobyCukiernicze",
                principalColumn: "IdWyorbuCukierniczego",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
