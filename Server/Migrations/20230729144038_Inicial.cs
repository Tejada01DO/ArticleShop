using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ArticleShop.Server.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articulos",
                columns: table => new
                {
                    ArticuloId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Precio = table.Column<double>(type: "REAL", nullable: false),
                    Existencia = table.Column<int>(type: "INTEGER", nullable: false),
                    Categoria = table.Column<string>(type: "TEXT", nullable: true),
                    Imagen = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulos", x => x.ArticuloId);
                });

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    CompraId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FechaDeCompra = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    ArticuloId = table.Column<int>(type: "INTEGER", nullable: false),
                    CantidadProducida = table.Column<int>(type: "INTEGER", nullable: false),
                    Total = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.CompraId);
                });

            migrationBuilder.CreateTable(
                name: "Entradas",
                columns: table => new
                {
                    InventarioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArticuloId = table.Column<int>(type: "INTEGER", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Motivo = table.Column<string>(type: "TEXT", nullable: true),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    Cantidad_Anterior = table.Column<int>(type: "INTEGER", nullable: false),
                    Total = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entradas", x => x.InventarioId);
                });

            migrationBuilder.CreateTable(
                name: "LoginDTO",
                columns: table => new
                {
                    Correo = table.Column<string>(type: "TEXT", nullable: false),
                    Clave = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginDTO", x => x.Correo);
                });

            migrationBuilder.CreateTable(
                name: "Salidas",
                columns: table => new
                {
                    InventarioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArticuloId = table.Column<int>(type: "INTEGER", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Motivo = table.Column<string>(type: "TEXT", nullable: true),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    Cantidad_Anterior = table.Column<int>(type: "INTEGER", nullable: false),
                    Total = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salidas", x => x.InventarioId);
                });

            migrationBuilder.CreateTable(
                name: "SesionDTO",
                columns: table => new
                {
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Correo = table.Column<string>(type: "TEXT", nullable: true),
                    Rol = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SesionDTO", x => x.Nombre);
                });

            migrationBuilder.CreateTable(
                name: "ComprasDetalle",
                columns: table => new
                {
                    DetalleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompraId = table.Column<int>(type: "INTEGER", nullable: false),
                    ArticuloId = table.Column<int>(type: "INTEGER", nullable: false),
                    CantidadUtilizada = table.Column<int>(type: "INTEGER", nullable: false),
                    Costo = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComprasDetalle", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_ComprasDetalle_Compras_CompraId",
                        column: x => x.CompraId,
                        principalTable: "Compras",
                        principalColumn: "CompraId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Articulos",
                columns: new[] { "ArticuloId", "Categoria", "Descripcion", "Existencia", "Fecha", "Imagen", "Precio" },
                values: new object[,]
                {
                    { 1, "Utiles escolares", "Lapiz", 500, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10.0 },
                    { 2, "Utiles escolares", "Lapiceros", 500, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 15.0 },
                    { 3, "Utiles escolares", "Borras", 600, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 15.0 },
                    { 4, "Utiles escolares", "Cuadernos", 300, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 60.0 },
                    { 5, "Utiles escolares", "Reglas", 300, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 50.0 },
                    { 6, "Utiles escolares", "Carpetas", 600, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 30.0 },
                    { 7, "Utiles escolares", "Pegamentos", 350, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 50.0 },
                    { 8, "Utiles escolares", "Tijeras", 300, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 60.0 },
                    { 9, "Utiles escolares", "Marcadores", 500, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 50.0 },
                    { 10, "Utiles escolares", "Resaltadores", 500, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 50.0 },
                    { 11, "Utiles escolares", "Compases", 500, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 60.0 },
                    { 12, "Utiles escolares", "Calculadoras", 350, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 150.0 },
                    { 13, "Utiles escolares", "Mochilas", 300, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 300.0 },
                    { 14, "Utiles escolares", "Papeles", 2500, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5.0 },
                    { 15, "Utiles escolares", "Papel para impresora", 2000, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7.0 },
                    { 16, "Utiles escolares", "Sobres", 2000, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 15.0 },
                    { 17, "Utiles escolares", "Pegatinas", 1500, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 35.0 },
                    { 18, "Utiles escolares", "Rotuladores", 500, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 60.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComprasDetalle_CompraId",
                table: "ComprasDetalle",
                column: "CompraId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articulos");

            migrationBuilder.DropTable(
                name: "ComprasDetalle");

            migrationBuilder.DropTable(
                name: "Entradas");

            migrationBuilder.DropTable(
                name: "LoginDTO");

            migrationBuilder.DropTable(
                name: "Salidas");

            migrationBuilder.DropTable(
                name: "SesionDTO");

            migrationBuilder.DropTable(
                name: "Compras");
        }
    }
}
