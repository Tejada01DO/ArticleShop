using System.ComponentModel.DataAnnotations;

public class Usuarios
{
    [Key]

    public int UsuarioId { get; set; }
    public string? Nombre { get; set; }
    public string? Correo { get; set; }
    public string? Clave { get; set; }
    public string? Rol { get; set; }
}