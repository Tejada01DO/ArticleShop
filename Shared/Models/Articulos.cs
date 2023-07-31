using System.ComponentModel.DataAnnotations;

public class Articulos
{
    [Key]

    public int ArticuloId { get; set; }
    [Required(ErrorMessage = "La descripcion es un campo obligatorio")]
    public string? Descripcion { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Now;
    [Range(minimum: 1, maximum: 10000, ErrorMessage = "Es necesario especificar un precio")]
    public double Precio { get; set; }
    [Required(ErrorMessage = "La cantidad es un campo obligatorio")]
    public int Cantidad { get; set; }
    [Required(ErrorMessage = "Es necesario especificar la cantidad de producto existente")]
    public int Existencia { get; set; }
    [Required(ErrorMessage = "Especifique la categoria, ej. Utiles Escolares")]
    public string? Categoria { get; set; }
    public double Costo { get; set; }
    public string? Imagen { get; set; }
}