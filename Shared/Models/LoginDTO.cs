using System.ComponentModel.DataAnnotations;

public class LoginDTO
{
    [Key]
    public string? Correo { get; set; }
    public string? Clave { get; set; }
}