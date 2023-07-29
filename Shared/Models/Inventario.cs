using System.ComponentModel.DataAnnotations;

public class Inventario
{
    [Key]

    public int InventarioId { get; set; }
    public int ArticuloId { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Today;
    public string? Motivo { get; set; }
    public int Cantidad { get; set; } = 0;
    public int Cantidad_Anterior { get; set; }
    public int Total { get; set; }
}

public class Entrada : Inventario
{

}

public class Salida : Inventario
{

}