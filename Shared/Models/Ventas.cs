using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Ventas
{
    [Key]

    public int VentaId { get; set; }
    public DateTime FechaDeCompra { get; set; } = DateTime.Now; 
    [Required(ErrorMessage = "Escriba el nombre del comprador")]
    public string? Nombre { get; set; }
    [Required(ErrorMessage = "El ID articulo es obligatorio")]
    public int ArticuloId { get; set; }
    [Required(ErrorMessage = "La cantidad a producir es un campo obligatorio")]
    public int CantidadProducida { get; set; }
    public double Total { get; set; }

    [ForeignKey("VentaId")]
    public List<VentasDetalle> ventasDetalles { get; set; } = new List<VentasDetalle>();
}

public class VentasDetalle
{
    [Key]

    public int DetalleId { get; set; }
    public int VentaId { get; set; }
    public int ArticuloId { get; set; }
    public int CantidadUtilizada { get; set; }
    public double Precio { get; set; }

    [NotMapped]
    public double? Importe
    {
        get { return CantidadUtilizada * Precio; }
    }
}