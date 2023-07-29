using Microsoft.EntityFrameworkCore;

public class Context : DbContext
{
    public DbSet<Articulos> Articulos { get; set; }
    public DbSet<Compras> Compras { get; set; }
    public DbSet<Entrada> Entradas { get; set; }
    public DbSet<Salida> Salidas { get; set; }
    public DbSet<LoginDTO> LoginDTO { get; set; }
    public DbSet<SesionDTO> SesionDTO { get; set; }

    public Context(DbContextOptions<Context> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Articulos>().HasData
        (
            new Articulos
            {
                ArticuloId = 1,
                Descripcion = "Lapiz",
                Fecha = new DateTime(2023, 07, 20),
                Precio = 10,
                Existencia = 500,
                Categoria = "Utiles escolares"
            },

            new Articulos
            {
                ArticuloId = 2,
                Descripcion = "Lapiceros",
                Fecha = new DateTime(2023, 07, 20),
                Precio = 15,
                Existencia = 500,
                Categoria = "Utiles escolares",
            },

            new Articulos
            {
                ArticuloId = 3,
                Descripcion = "Borras",
                Fecha = new DateTime(2023, 07, 20),
                Precio = 15,
                Existencia = 600,
                Categoria = "Utiles escolares"
            },

            new Articulos
            {
                ArticuloId = 4,
                Descripcion = "Cuadernos",
                Fecha = new DateTime(2023, 07, 20),
                Precio = 60,
                Existencia = 300,
                Categoria = "Utiles escolares"
            },

            new Articulos
            {
                ArticuloId = 5,
                Descripcion = "Reglas",
                Fecha = new DateTime(2023, 07, 20),
                Precio = 50,
                Existencia = 300,
                Categoria = "Utiles escolares"
            },

            new Articulos
            {
                ArticuloId = 6,
                Descripcion = "Carpetas",
                Fecha = new DateTime(2023, 07, 20),
                Precio = 30,
                Existencia = 600,
                Categoria = "Utiles escolares"
            },

            new Articulos
            {
                ArticuloId = 7,
                Descripcion = "Pegamentos",
                Fecha = new DateTime(2023, 07, 20),
                Precio = 50,
                Existencia = 350,
                Categoria = "Utiles escolares"
            },

            new Articulos
            {
                ArticuloId = 8,
                Descripcion = "Tijeras",
                Fecha = new DateTime(2023, 07, 20),
                Precio = 60,
                Existencia = 300,
                Categoria = "Utiles escolares"
            },

            new Articulos
            {
                ArticuloId = 9,
                Descripcion = "Marcadores",
                Fecha = new DateTime(2023, 07, 20),
                Precio = 50,
                Existencia = 500,
                Categoria = "Utiles escolares"
            },

            new Articulos
            {
                ArticuloId = 10,
                Descripcion = "Resaltadores",
                Fecha = new DateTime(2023, 07, 20),
                Precio = 50,
                Existencia = 500,
                Categoria = "Utiles escolares"
            },

            new Articulos
            {
                ArticuloId = 11,
                Descripcion = "Compases",
                Fecha = new DateTime(2023, 07, 20),
                Precio = 60,
                Existencia = 500,
                Categoria = "Utiles escolares"
            },

            new Articulos
            {
                ArticuloId = 12,
                Descripcion = "Calculadoras",
                Fecha = new DateTime(2023, 07, 20),
                Precio = 150,
                Existencia = 350,
                Categoria = "Utiles escolares"
            },

            new Articulos
            {
                ArticuloId = 13,
                Descripcion = "Mochilas",
                Fecha = new DateTime(2023, 07, 20),
                Precio = 300,
                Existencia = 300,
                Categoria = "Utiles escolares"
            },

            new Articulos
            {
                ArticuloId = 14,
                Descripcion = "Papeles",
                Fecha = new DateTime(2023, 07, 20),
                Precio = 5,
                Existencia = 2500,
                Categoria = "Utiles escolares"
            },

            new Articulos
            {
                ArticuloId = 15,
                Descripcion = "Papel para impresora",
                Fecha = new DateTime(2023, 07, 20),
                Precio = 7,
                Existencia = 2000,
                Categoria = "Utiles escolares"
            },

            new Articulos
            {
                ArticuloId = 16,
                Descripcion = "Sobres",
                Fecha = new DateTime(2023, 07, 20),
                Precio = 15,
                Existencia = 2000,
                Categoria = "Utiles escolares"
            },

            new Articulos
            {
                ArticuloId = 17,
                Descripcion = "Pegatinas",
                Fecha = new DateTime(2023, 07, 20),
                Precio = 35,
                Existencia = 1500,
                Categoria = "Utiles escolares"
            },

            new Articulos
            {
                ArticuloId = 18,
                Descripcion = "Rotuladores",
                Fecha = new DateTime(2023, 07, 20),
                Precio = 60,
                Existencia = 500,
                Categoria = "Utiles escolares"
            }
        );
    }
}