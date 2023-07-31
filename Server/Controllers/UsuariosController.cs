using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArticleShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsuariosController : ControllerBase
    {
        private readonly Context _context;

        public UsuariosController(Context context)
        {
            _context = context;
        }

        [HttpPost("{Login}")]
        public async Task<IActionResult> PostLogin([FromBody] LoginDTO login)
        {
            SesionDTO sesionDTO = new SesionDTO();

            if(login.Correo == "admin@gmail.com" && login.Clave == "admin")
            {
                sesionDTO.Nombre = "admin";
                sesionDTO.Correo = login.Correo;
                sesionDTO.Rol = "Administrador";
            }
            else if(login.Correo == "empleado@gmail.com" && login.Clave == "nuevoEmpleado")
            {
                sesionDTO.Nombre = "empleado";
                sesionDTO.Correo = login.Correo;
                sesionDTO.Rol = "Empleado";
            }
            else if(login.Correo == "estudiante@gmail.com" && login.Clave == "nuevoEstudiante")
            {
                sesionDTO.Nombre = "estudiante";
                sesionDTO.Correo = login.Correo;
                sesionDTO.Rol = "Estudiante";
            }
            else
            {
                return NotFound("Ese usuario no esta creado");
            }

            return StatusCode(StatusCodes.Status200OK, sesionDTO);
        }
    }
}