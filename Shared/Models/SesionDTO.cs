using System.ComponentModel.DataAnnotations;

public class SesionDTO
{
    [Key]
    public string? Nombre { get; set; }
    public string? Correo { get; set; }
    public string? Rol { get; set; }
}