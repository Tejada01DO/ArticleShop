using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Compras
{
    [Key]

    public int CompraId { get; set; }
    public DateTime FechaDeCompra { get; set; } = DateTime.Today; 
    public string? Nombre { get; set; }
    public int ArticuloId { get; set; }
    public int CantidadProducida { get; set; }
    public double Total { get; set; }

    [ForeignKey("CompraId")]
    public List<ComprasDetalle> CompraDetalle { get; set; } = new List<ComprasDetalle>();
}

public class ComprasDetalle
{
    [Key]

    public int DetalleId { get; set; }
    public int CompraId { get; set; }
    public int ArticuloId { get; set; }
    public int CantidadUtilizada { get; set; }
    public double Costo { get; set; }

    [NotMapped]
    public double? Importe
    {
        get { return CantidadUtilizada * Costo; }
    }
}