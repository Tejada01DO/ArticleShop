using Microsoft.EntityFrameworkCore;

public class Context : DbContext
{
    public DbSet<Articulos> Articulos { get; set; }
    public DbSet<Compras> Compras { get; set; }
    public DbSet<Ventas> Ventas { get; set; }
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
                Imagen = "https://papeleradelonce.com.ar/wp-content/uploads/2020/11/9421.jpg",
                ArticuloId = 1,
                Descripcion = "Lapiz",
                Fecha = new DateTime(2023, 07, 20),
                Costo = 7,
                Precio = 10,
                Existencia = 500,
                Categoria = "Utiles escolares"
            },

            new Articulos
            {
                Imagen = "https://w7.pngwing.com/pngs/457/85/png-transparent-faber-castell-pencil-writing-implement-ballpoint-pen-pen.png",
                ArticuloId = 2,
                Descripcion = "Lapiceros",
                Fecha = new DateTime(2023, 07, 20),
                Costo = 10,
                Precio = 15,
                Existencia = 500,
                Categoria = "Utiles escolares",
            },

            new Articulos
            {
                Imagen = "https://raulperez.tieneblog.net/wp-content/uploads/2015/02/goma-de-borrar.jpg",
                ArticuloId = 3,
                Descripcion = "Borras",
                Fecha = new DateTime(2023, 07, 20),
                Costo = 8,
                Precio = 15,
                Existencia = 600,
                Categoria = "Utiles escolares"
            },

            new Articulos
            {
                Imagen = "https://w7.pngwing.com/pngs/537/490/png-transparent-notebook-pen-%D0%91%D0%BB%D0%BE%D0%BA%D0%BD%D0%BE%D1%82-stationery-notebook-miscellaneous-pencil-file-folders.png",
                ArticuloId = 4,
                Descripcion = "Cuadernos",
                Fecha = new DateTime(2023, 07, 20),
                Costo = 40,
                Precio = 60,
                Existencia = 300,
                Categoria = "Utiles escolares"
            },

            new Articulos
            {
                Imagen = "https://images.vexels.com/media/users/3/212457/isolated/preview/40771eb8012d98083f41f19abb89c171-icono-plano-regla-recta-verde.png",
                ArticuloId = 5,
                Descripcion = "Reglas",
                Fecha = new DateTime(2023, 07, 20),
                Costo = 30,
                Precio = 50,
                Existencia = 300,
                Categoria = "Utiles escolares"
            },

            new Articulos
            {
                Imagen = "https://w7.pngwing.com/pngs/568/36/png-transparent-emoji-file-folders-directory-ring-binder-emoji-angle-rectangle-orange.png",
                ArticuloId = 6,
                Descripcion = "Carpetas",
                Fecha = new DateTime(2023, 07, 20),
                Costo = 15,
                Precio = 30,
                Existencia = 600,
                Categoria = "Utiles escolares"
            },

            new Articulos
            {
                Imagen = "https://www.pngmart.com/files/7/Glue-PNG-Clipart.png",
                ArticuloId = 7,
                Descripcion = "Pegamentos",
                Fecha = new DateTime(2023, 07, 20),
                Costo = 35,
                Precio = 50,
                Existencia = 350,
                Categoria = "Utiles escolares"
            },

            new Articulos
            {
                Imagen = "https://w7.pngwing.com/pngs/221/616/png-transparent-scissors-scissors-image-file-formats-photography-technic.png",
                ArticuloId = 8,
                Descripcion = "Tijeras",
                Fecha = new DateTime(2023, 07, 20),
                Costo = 40,
                Precio = 60,
                Existencia = 300,
                Categoria = "Utiles escolares"
            },

            new Articulos
            {
                Imagen = "https://www.pngfind.com/pngs/m/424-4243505_marcadores-png-imagenes-de-marcadores-png-transparent-png.png",
                ArticuloId = 9,
                Descripcion = "Marcadores",
                Fecha = new DateTime(2023, 07, 20),
                Costo = 35,
                Precio = 50,
                Existencia = 500,
                Categoria = "Utiles escolares"
            },

            new Articulos
            {
                Imagen = "https://us.123rf.com/450wm/djvstock/djvstock1903/djvstock190323963/124180351-resaltadores-colores-iconos-aislados-vector-ilustraci%C3%B3n-dise%C3%B1o.jpg?ver=6",
                ArticuloId = 10,
                Descripcion = "Resaltadores",
                Fecha = new DateTime(2023, 07, 20),
                Costo = 35,
                Precio = 50,
                Existencia = 500,
                Categoria = "Utiles escolares"
            },

            new Articulos
            {
                Imagen = "https://ae01.alicdn.com/kf/HTB1eLzZjER1BeNjy0Fmq6z0wVXaw/Juego-de-br-jula-de-matem-ticas-para-dibujar-herramientas-de-dibujo-material-escolar-papeler-a.jpg",
                ArticuloId = 11,
                Descripcion = "Compases",
                Fecha = new DateTime(2023, 07, 20),
                Costo = 45,
                Precio = 60,
                Existencia = 500,
                Categoria = "Utiles escolares"
            },

            new Articulos
            {
                Imagen = "https://e7.pngegg.com/pngimages/834/1004/png-clipart-calculator-calculator.png",
                ArticuloId = 12,
                Descripcion = "Calculadoras",
                Fecha = new DateTime(2023, 07, 20),
                Costo = 100,
                Precio = 150,
                Existencia = 350,
                Categoria = "Utiles escolares"
            },

            new Articulos
            {
                Imagen = "https://www.pngall.com/wp-content/uploads/2016/04/Backpack-PNG-Image.png",
                ArticuloId = 13,
                Descripcion = "Mochilas",
                Fecha = new DateTime(2023, 07, 20),
                Costo = 225,
                Precio = 300,
                Existencia = 300,
                Categoria = "Utiles escolares"
            },

            new Articulos
            {
                Imagen = "https://cdn.pixabay.com/photo/2022/08/11/16/49/papers-7379900_1280.png",
                ArticuloId = 14,
                Descripcion = "Papeles",
                Fecha = new DateTime(2023, 07, 20),
                Costo = 2,
                Precio = 5,
                Existencia = 2500,
                Categoria = "Utiles escolares"
            },

            new Articulos
            {
                Imagen = "https://www.seekpng.com/png/full/176-1762578_mail-clipart-long-envelope-imagenes-de-sobres-animados.png",
                ArticuloId = 15,
                Descripcion = "Sobres",
                Fecha = new DateTime(2023, 07, 20),
                Costo = 7,
                Precio = 15,
                Existencia = 2000,
                Categoria = "Utiles escolares"
            },

            new Articulos
            {
                Imagen = "https://e7.pngegg.com/pngimages/63/758/png-clipart-post-it-note-sticky-notes-home-screen-paper-desktop-notes-sticky-notes-rectangle-notes.png",
                ArticuloId = 16,
                Descripcion = "Pegatinas",
                Fecha = new DateTime(2023, 07, 20),
                Costo = 20,
                Precio = 35,
                Existencia = 1500,
                Categoria = "Utiles escolares"
            },

            new Articulos
            {
                Imagen = "https://www3.gobiernodecanarias.org/medusa/mediateca/ecoescuela/wp-content/uploads/sites/2/2013/11/17-Rotulador.png",
                ArticuloId = 17,
                Descripcion = "Rotuladores",
                Fecha = new DateTime(2023, 07, 20),
                Costo = 45,
                Precio = 60,
                Existencia = 500,
                Categoria = "Utiles escolares"
            }
        );
    }
}