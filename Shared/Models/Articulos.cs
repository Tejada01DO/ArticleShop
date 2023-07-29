using System.ComponentModel.DataAnnotations;

public class Articulos
{
    [Key]

    public int ArticuloId { get; set; }
    public string? Descripcion { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Today;
    public double Precio { get; set; }
    public int Existencia { get; set; }
    public string? Categoria { get; set; }
    public string? Imagen { get; set; }
}