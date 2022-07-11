using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZadanieRekrutacyjne.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaKategorii = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZadanieRekrutacyjnes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IdKategorii = table.Column<int>(type: "int", nullable: false),
                    KategoriaId = table.Column<int>(type: "int", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZadanieRekrutacyjnes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZadanieRekrutacyjnes_Kategorias_KategoriaId",
                        column: x => x.KategoriaId,
                        principalTable: "Kategorias",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ZadanieRekrutacyjnes_KategoriaId",
                table: "ZadanieRekrutacyjnes",
                column: "KategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZadanieRekrutacyjnes");

            migrationBuilder.DropTable(
                name: "Kategorias");
        }
    }
}
