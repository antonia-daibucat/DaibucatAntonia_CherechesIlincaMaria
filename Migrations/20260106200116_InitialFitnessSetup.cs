using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DaibucatAntonia_CherechesIlincaMaria.Migrations
{
    /// <inheritdoc />
    public partial class InitialFitnessSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abonament",
                columns: table => new
                {
                    AbonamentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeAbonament = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pret = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Descriere = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abonament", x => x.AbonamentId);
                });

            migrationBuilder.CreateTable(
                name: "ClasaFitness",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeClasa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descriere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Antrenor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ora = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClasaFitness", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParolaHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AbonamentClient",
                columns: table => new
                {
                    AbonamentClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AbonamentId = table.Column<int>(type: "int", nullable: false),
                    DataInceput = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataSfarsit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Activ = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbonamentClient", x => x.AbonamentClientId);
                    table.ForeignKey(
                        name: "FK_AbonamentClient_Abonament_AbonamentId",
                        column: x => x.AbonamentId,
                        principalTable: "Abonament",
                        principalColumn: "AbonamentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AbonamentClient_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plata",
                columns: table => new
                {
                    PlataId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AbonamentClientId = table.Column<int>(type: "int", nullable: false),
                    Suma = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataPlata = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MetodaPlata = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plata", x => x.PlataId);
                    table.ForeignKey(
                        name: "FK_Plata_AbonamentClient_AbonamentClientId",
                        column: x => x.AbonamentClientId,
                        principalTable: "AbonamentClient",
                        principalColumn: "AbonamentClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbonamentClient_AbonamentId",
                table: "AbonamentClient",
                column: "AbonamentId");

            migrationBuilder.CreateIndex(
                name: "IX_AbonamentClient_UserId",
                table: "AbonamentClient",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Plata_AbonamentClientId",
                table: "Plata",
                column: "AbonamentClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClasaFitness");

            migrationBuilder.DropTable(
                name: "Plata");

            migrationBuilder.DropTable(
                name: "AbonamentClient");

            migrationBuilder.DropTable(
                name: "Abonament");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
