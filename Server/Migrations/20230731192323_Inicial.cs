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
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Precio = table.Column<double>(type: "REAL", nullable: false),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    Existencia = table.Column<int>(type: "INTEGER", nullable: false),
                    Categoria = table.Column<string>(type: "TEXT", nullable: false),
                    Costo = table.Column<double>(type: "REAL", nullable: false),
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
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    ArticuloId = table.Column<int>(type: "INTEGER", nullable: false),
                    CantidadProducida = table.Column<int>(type: "INTEGER", nullable: false),
                    Total = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.CompraId);
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
                name: "Ventas",
                columns: table => new
                {
                    VentaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FechaDeCompra = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    ArticuloId = table.Column<int>(type: "INTEGER", nullable: false),
                    CantidadProducida = table.Column<int>(type: "INTEGER", nullable: false),
                    Total = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.VentaId);
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
                    Precio = table.Column<double>(type: "REAL", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "VentasDetalle",
                columns: table => new
                {
                    DetalleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VentaId = table.Column<int>(type: "INTEGER", nullable: false),
                    ArticuloId = table.Column<int>(type: "INTEGER", nullable: false),
                    CantidadUtilizada = table.Column<int>(type: "INTEGER", nullable: false),
                    Precio = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentasDetalle", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_VentasDetalle_Ventas_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Ventas",
                        principalColumn: "VentaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Articulos",
                columns: new[] { "ArticuloId", "Cantidad", "Categoria", "Costo", "Descripcion", "Existencia", "Fecha", "Imagen", "Precio" },
                values: new object[,]
                {
                    { 1, 0, "Utiles escolares", 7.0, "Lapiz", 500, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://papeleradelonce.com.ar/wp-content/uploads/2020/11/9421.jpg", 10.0 },
                    { 2, 0, "Utiles escolares", 10.0, "Lapiceros", 500, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://w7.pngwing.com/pngs/457/85/png-transparent-faber-castell-pencil-writing-implement-ballpoint-pen-pen.png", 15.0 },
                    { 3, 0, "Utiles escolares", 8.0, "Borras", 600, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://raulperez.tieneblog.net/wp-content/uploads/2015/02/goma-de-borrar.jpg", 15.0 },
                    { 4, 0, "Utiles escolares", 40.0, "Cuadernos", 300, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://w7.pngwing.com/pngs/537/490/png-transparent-notebook-pen-%D0%91%D0%BB%D0%BE%D0%BA%D0%BD%D0%BE%D1%82-stationery-notebook-miscellaneous-pencil-file-folders.png", 60.0 },
                    { 5, 0, "Utiles escolares", 30.0, "Reglas", 300, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://images.vexels.com/media/users/3/212457/isolated/preview/40771eb8012d98083f41f19abb89c171-icono-plano-regla-recta-verde.png", 50.0 },
                    { 6, 0, "Utiles escolares", 15.0, "Carpetas", 600, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://w7.pngwing.com/pngs/568/36/png-transparent-emoji-file-folders-directory-ring-binder-emoji-angle-rectangle-orange.png", 30.0 },
                    { 7, 0, "Utiles escolares", 35.0, "Pegamentos", 350, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.pngmart.com/files/7/Glue-PNG-Clipart.png", 50.0 },
                    { 8, 0, "Utiles escolares", 40.0, "Tijeras", 300, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://w7.pngwing.com/pngs/221/616/png-transparent-scissors-scissors-image-file-formats-photography-technic.png", 60.0 },
                    { 9, 0, "Utiles escolares", 35.0, "Marcadores", 500, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.pngfind.com/pngs/m/424-4243505_marcadores-png-imagenes-de-marcadores-png-transparent-png.png", 50.0 },
                    { 10, 0, "Utiles escolares", 35.0, "Resaltadores", 500, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://us.123rf.com/450wm/djvstock/djvstock1903/djvstock190323963/124180351-resaltadores-colores-iconos-aislados-vector-ilustraci%C3%B3n-dise%C3%B1o.jpg?ver=6", 50.0 },
                    { 11, 0, "Utiles escolares", 45.0, "Compases", 500, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://ae01.alicdn.com/kf/HTB1eLzZjER1BeNjy0Fmq6z0wVXaw/Juego-de-br-jula-de-matem-ticas-para-dibujar-herramientas-de-dibujo-material-escolar-papeler-a.jpg", 60.0 },
                    { 12, 0, "Utiles escolares", 100.0, "Calculadoras", 350, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://e7.pngegg.com/pngimages/834/1004/png-clipart-calculator-calculator.png", 150.0 },
                    { 13, 0, "Utiles escolares", 225.0, "Mochilas", 300, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.pngall.com/wp-content/uploads/2016/04/Backpack-PNG-Image.png", 300.0 },
                    { 14, 0, "Utiles escolares", 2.0, "Papeles", 2500, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://cdn.pixabay.com/photo/2022/08/11/16/49/papers-7379900_1280.png", 5.0 },
                    { 15, 0, "Utiles escolares", 7.0, "Sobres", 2000, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.seekpng.com/png/full/176-1762578_mail-clipart-long-envelope-imagenes-de-sobres-animados.png", 15.0 },
                    { 16, 0, "Utiles escolares", 20.0, "Pegatinas", 1500, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://e7.pngegg.com/pngimages/63/758/png-clipart-post-it-note-sticky-notes-home-screen-paper-desktop-notes-sticky-notes-rectangle-notes.png", 35.0 },
                    { 17, 0, "Utiles escolares", 45.0, "Rotuladores", 500, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www3.gobiernodecanarias.org/medusa/mediateca/ecoescuela/wp-content/uploads/sites/2/2013/11/17-Rotulador.png", 60.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComprasDetalle_CompraId",
                table: "ComprasDetalle",
                column: "CompraId");

            migrationBuilder.CreateIndex(
                name: "IX_VentasDetalle_VentaId",
                table: "VentasDetalle",
                column: "VentaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articulos");

            migrationBuilder.DropTable(
                name: "ComprasDetalle");

            migrationBuilder.DropTable(
                name: "LoginDTO");

            migrationBuilder.DropTable(
                name: "SesionDTO");

            migrationBuilder.DropTable(
                name: "VentasDetalle");

            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "Ventas");
        }
    }
}
