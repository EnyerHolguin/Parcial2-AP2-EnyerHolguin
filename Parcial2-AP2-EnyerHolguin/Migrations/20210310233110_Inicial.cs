using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Parcial2_AP2_EnyerHolguin.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Cobro",
                columns: table => new
                {
                    CobroId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BalanceCobro = table.Column<double>(type: "REAL", nullable: false),
                    Totales = table.Column<int>(type: "INTEGER", nullable: false),
                    Observaciones = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cobro", x => x.CobroId);
                    table.ForeignKey(
                        name: "FK_Cobro_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Venta",
                columns: table => new
                {
                    VentaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false),
                    Monto = table.Column<double>(type: "REAL", nullable: false),
                    Balance = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venta", x => x.VentaId);
                    table.ForeignKey(
                        name: "FK_Venta_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CobrosDetalles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CobroId = table.Column<int>(type: "INTEGER", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Monto = table.Column<double>(type: "REAL", nullable: false),
                    Balance = table.Column<double>(type: "REAL", nullable: false),
                    Cobrado = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CobrosDetalles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CobrosDetalles_Cobro_CobroId",
                        column: x => x.CobroId,
                        principalTable: "Cobro",
                        principalColumn: "CobroId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "ClienteId", "Nombres" },
                values: new object[] { 1, "FERRETERIA GAMA" });

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "ClienteId", "Nombres" },
                values: new object[] { 2, "AVALON DISCO" });

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "ClienteId", "Nombres" },
                values: new object[] { 3, "PRESTAMOS CEFIPROD" });

            migrationBuilder.InsertData(
                table: "Venta",
                columns: new[] { "VentaId", "Balance", "ClienteId", "Fecha", "Monto" },
                values: new object[] { 1, 1000.0, 1, new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000.0 });

            migrationBuilder.InsertData(
                table: "Venta",
                columns: new[] { "VentaId", "Balance", "ClienteId", "Fecha", "Monto" },
                values: new object[] { 2, 800.0, 1, new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 900.0 });

            migrationBuilder.InsertData(
                table: "Venta",
                columns: new[] { "VentaId", "Balance", "ClienteId", "Fecha", "Monto" },
                values: new object[] { 3, 2000.0, 2, new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2000.0 });

            migrationBuilder.InsertData(
                table: "Venta",
                columns: new[] { "VentaId", "Balance", "ClienteId", "Fecha", "Monto" },
                values: new object[] { 4, 1800.0, 2, new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1900.0 });

            migrationBuilder.InsertData(
                table: "Venta",
                columns: new[] { "VentaId", "Balance", "ClienteId", "Fecha", "Monto" },
                values: new object[] { 5, 3000.0, 3, new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3000.0 });

            migrationBuilder.InsertData(
                table: "Venta",
                columns: new[] { "VentaId", "Balance", "ClienteId", "Fecha", "Monto" },
                values: new object[] { 6, 1900.0, 3, new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2900.0 });

            migrationBuilder.CreateIndex(
                name: "IX_Cobro_ClienteId",
                table: "Cobro",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_CobrosDetalles_CobroId",
                table: "CobrosDetalles",
                column: "CobroId");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_ClienteId",
                table: "Venta",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CobrosDetalles");

            migrationBuilder.DropTable(
                name: "Venta");

            migrationBuilder.DropTable(
                name: "Cobro");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
