﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ArticleShop.Server.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.9");

            modelBuilder.Entity("Articulos", b =>
                {
                    b.Property<int>("ArticuloId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Costo")
                        .HasColumnType("REAL");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Existencia")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<string>("Imagen")
                        .HasColumnType("TEXT");

                    b.Property<double>("Precio")
                        .HasColumnType("REAL");

                    b.HasKey("ArticuloId");

                    b.ToTable("Articulos");

                    b.HasData(
                        new
                        {
                            ArticuloId = 1,
                            Cantidad = 0,
                            Categoria = "Utiles escolares",
                            Costo = 7.0,
                            Descripcion = "Lapiz",
                            Existencia = 500,
                            Fecha = new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Imagen = "https://papeleradelonce.com.ar/wp-content/uploads/2020/11/9421.jpg",
                            Precio = 10.0
                        },
                        new
                        {
                            ArticuloId = 2,
                            Cantidad = 0,
                            Categoria = "Utiles escolares",
                            Costo = 10.0,
                            Descripcion = "Lapiceros",
                            Existencia = 500,
                            Fecha = new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Imagen = "https://w7.pngwing.com/pngs/457/85/png-transparent-faber-castell-pencil-writing-implement-ballpoint-pen-pen.png",
                            Precio = 15.0
                        },
                        new
                        {
                            ArticuloId = 3,
                            Cantidad = 0,
                            Categoria = "Utiles escolares",
                            Costo = 8.0,
                            Descripcion = "Borras",
                            Existencia = 600,
                            Fecha = new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Imagen = "https://raulperez.tieneblog.net/wp-content/uploads/2015/02/goma-de-borrar.jpg",
                            Precio = 15.0
                        },
                        new
                        {
                            ArticuloId = 4,
                            Cantidad = 0,
                            Categoria = "Utiles escolares",
                            Costo = 40.0,
                            Descripcion = "Cuadernos",
                            Existencia = 300,
                            Fecha = new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Imagen = "https://w7.pngwing.com/pngs/537/490/png-transparent-notebook-pen-%D0%91%D0%BB%D0%BE%D0%BA%D0%BD%D0%BE%D1%82-stationery-notebook-miscellaneous-pencil-file-folders.png",
                            Precio = 60.0
                        },
                        new
                        {
                            ArticuloId = 5,
                            Cantidad = 0,
                            Categoria = "Utiles escolares",
                            Costo = 30.0,
                            Descripcion = "Reglas",
                            Existencia = 300,
                            Fecha = new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Imagen = "https://images.vexels.com/media/users/3/212457/isolated/preview/40771eb8012d98083f41f19abb89c171-icono-plano-regla-recta-verde.png",
                            Precio = 50.0
                        },
                        new
                        {
                            ArticuloId = 6,
                            Cantidad = 0,
                            Categoria = "Utiles escolares",
                            Costo = 15.0,
                            Descripcion = "Carpetas",
                            Existencia = 600,
                            Fecha = new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Imagen = "https://w7.pngwing.com/pngs/568/36/png-transparent-emoji-file-folders-directory-ring-binder-emoji-angle-rectangle-orange.png",
                            Precio = 30.0
                        },
                        new
                        {
                            ArticuloId = 7,
                            Cantidad = 0,
                            Categoria = "Utiles escolares",
                            Costo = 35.0,
                            Descripcion = "Pegamentos",
                            Existencia = 350,
                            Fecha = new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Imagen = "https://www.pngmart.com/files/7/Glue-PNG-Clipart.png",
                            Precio = 50.0
                        },
                        new
                        {
                            ArticuloId = 8,
                            Cantidad = 0,
                            Categoria = "Utiles escolares",
                            Costo = 40.0,
                            Descripcion = "Tijeras",
                            Existencia = 300,
                            Fecha = new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Imagen = "https://w7.pngwing.com/pngs/221/616/png-transparent-scissors-scissors-image-file-formats-photography-technic.png",
                            Precio = 60.0
                        },
                        new
                        {
                            ArticuloId = 9,
                            Cantidad = 0,
                            Categoria = "Utiles escolares",
                            Costo = 35.0,
                            Descripcion = "Marcadores",
                            Existencia = 500,
                            Fecha = new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Imagen = "https://www.pngfind.com/pngs/m/424-4243505_marcadores-png-imagenes-de-marcadores-png-transparent-png.png",
                            Precio = 50.0
                        },
                        new
                        {
                            ArticuloId = 10,
                            Cantidad = 0,
                            Categoria = "Utiles escolares",
                            Costo = 35.0,
                            Descripcion = "Resaltadores",
                            Existencia = 500,
                            Fecha = new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Imagen = "https://us.123rf.com/450wm/djvstock/djvstock1903/djvstock190323963/124180351-resaltadores-colores-iconos-aislados-vector-ilustraci%C3%B3n-dise%C3%B1o.jpg?ver=6",
                            Precio = 50.0
                        },
                        new
                        {
                            ArticuloId = 11,
                            Cantidad = 0,
                            Categoria = "Utiles escolares",
                            Costo = 45.0,
                            Descripcion = "Compases",
                            Existencia = 500,
                            Fecha = new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Imagen = "https://ae01.alicdn.com/kf/HTB1eLzZjER1BeNjy0Fmq6z0wVXaw/Juego-de-br-jula-de-matem-ticas-para-dibujar-herramientas-de-dibujo-material-escolar-papeler-a.jpg",
                            Precio = 60.0
                        },
                        new
                        {
                            ArticuloId = 12,
                            Cantidad = 0,
                            Categoria = "Utiles escolares",
                            Costo = 100.0,
                            Descripcion = "Calculadoras",
                            Existencia = 350,
                            Fecha = new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Imagen = "https://e7.pngegg.com/pngimages/834/1004/png-clipart-calculator-calculator.png",
                            Precio = 150.0
                        },
                        new
                        {
                            ArticuloId = 13,
                            Cantidad = 0,
                            Categoria = "Utiles escolares",
                            Costo = 225.0,
                            Descripcion = "Mochilas",
                            Existencia = 300,
                            Fecha = new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Imagen = "https://www.pngall.com/wp-content/uploads/2016/04/Backpack-PNG-Image.png",
                            Precio = 300.0
                        },
                        new
                        {
                            ArticuloId = 14,
                            Cantidad = 0,
                            Categoria = "Utiles escolares",
                            Costo = 2.0,
                            Descripcion = "Papeles",
                            Existencia = 2500,
                            Fecha = new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Imagen = "https://cdn.pixabay.com/photo/2022/08/11/16/49/papers-7379900_1280.png",
                            Precio = 5.0
                        },
                        new
                        {
                            ArticuloId = 15,
                            Cantidad = 0,
                            Categoria = "Utiles escolares",
                            Costo = 7.0,
                            Descripcion = "Sobres",
                            Existencia = 2000,
                            Fecha = new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Imagen = "https://www.seekpng.com/png/full/176-1762578_mail-clipart-long-envelope-imagenes-de-sobres-animados.png",
                            Precio = 15.0
                        },
                        new
                        {
                            ArticuloId = 16,
                            Cantidad = 0,
                            Categoria = "Utiles escolares",
                            Costo = 20.0,
                            Descripcion = "Pegatinas",
                            Existencia = 1500,
                            Fecha = new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Imagen = "https://e7.pngegg.com/pngimages/63/758/png-clipart-post-it-note-sticky-notes-home-screen-paper-desktop-notes-sticky-notes-rectangle-notes.png",
                            Precio = 35.0
                        },
                        new
                        {
                            ArticuloId = 17,
                            Cantidad = 0,
                            Categoria = "Utiles escolares",
                            Costo = 45.0,
                            Descripcion = "Rotuladores",
                            Existencia = 500,
                            Fecha = new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Imagen = "https://www3.gobiernodecanarias.org/medusa/mediateca/ecoescuela/wp-content/uploads/sites/2/2013/11/17-Rotulador.png",
                            Precio = 60.0
                        });
                });

            modelBuilder.Entity("Compras", b =>
                {
                    b.Property<int>("CompraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArticuloId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CantidadProducida")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FechaDeCompra")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Total")
                        .HasColumnType("REAL");

                    b.HasKey("CompraId");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("ComprasDetalle", b =>
                {
                    b.Property<int>("DetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArticuloId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CantidadUtilizada")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CompraId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Precio")
                        .HasColumnType("REAL");

                    b.HasKey("DetalleId");

                    b.HasIndex("CompraId");

                    b.ToTable("ComprasDetalle");
                });

            modelBuilder.Entity("LoginDTO", b =>
                {
                    b.Property<string>("Correo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Clave")
                        .HasColumnType("TEXT");

                    b.HasKey("Correo");

                    b.ToTable("LoginDTO");
                });

            modelBuilder.Entity("SesionDTO", b =>
                {
                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<string>("Correo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Rol")
                        .HasColumnType("TEXT");

                    b.HasKey("Nombre");

                    b.ToTable("SesionDTO");
                });

            modelBuilder.Entity("Ventas", b =>
                {
                    b.Property<int>("VentaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArticuloId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CantidadProducida")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FechaDeCompra")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Total")
                        .HasColumnType("REAL");

                    b.HasKey("VentaId");

                    b.ToTable("Ventas");
                });

            modelBuilder.Entity("VentasDetalle", b =>
                {
                    b.Property<int>("DetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArticuloId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CantidadUtilizada")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Precio")
                        .HasColumnType("REAL");

                    b.Property<int>("VentaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("DetalleId");

                    b.HasIndex("VentaId");

                    b.ToTable("VentasDetalle");
                });

            modelBuilder.Entity("ComprasDetalle", b =>
                {
                    b.HasOne("Compras", null)
                        .WithMany("CompraDetalle")
                        .HasForeignKey("CompraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VentasDetalle", b =>
                {
                    b.HasOne("Ventas", null)
                        .WithMany("ventasDetalles")
                        .HasForeignKey("VentaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Compras", b =>
                {
                    b.Navigation("CompraDetalle");
                });

            modelBuilder.Entity("Ventas", b =>
                {
                    b.Navigation("ventasDetalles");
                });
#pragma warning restore 612, 618
        }
    }
}
