using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ArticleShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SalidasController : ControllerBase
    {
        private readonly Context _context;

        public SalidasController(Context context)
        {
            _context = context;
        }

        public bool Existe(int InventarioId)
        {
            return (_context.Salidas?.Any(s => s.InventarioId == InventarioId)).GetValueOrDefault();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Salida>>> Obtener()
        {
            if(_context.Salidas == null)
            {
                return NotFound();
            }
            else
            {
                return await _context.Salidas.ToListAsync();
            }
        }

        [HttpGet("{InventarioId}")]
        public async Task<ActionResult<Salida>> ObtenerSalida(int InventarioId)
        {
            if(_context.Salidas == null)
            {
                return NotFound();
            }

            var salida = await _context.Salidas.FindAsync(InventarioId);

            if(salida == null)
            {
                return NotFound();
            }
            return salida;
        }

        [HttpPost]
        public async Task<ActionResult<Entrada>> PostSalida(Salida salida)
        {
            if(!Existe(salida.InventarioId))
            {
                 _context.Database.ExecuteSqlRaw($"UPDATE Articulos SET Existencia = Existencia - {salida.Cantidad}  WHERE ArticuloId={salida.ArticuloId}");
                _context.Salidas.Add(salida);
            }
            else
            {
                _context.Entry(salida).State = EntityState.Modified;
                _context.Entry(salida).State = EntityState.Detached;
                _context.Salidas.Update(salida);
            }

            await _context.SaveChangesAsync();
            return Ok(salida);
        }

        [HttpDelete("{InventarioId}")]
        public async Task<IActionResult> EliminarSalida(int InventarioId)
        {
            if(_context.Salidas == null)
            {
                return NotFound();
            }

            var salida = await _context.Salidas.FindAsync(InventarioId);

            if(salida == null)
            {
                return NotFound();
            }
            else
            {
                _context.Entry(salida).State=EntityState.Deleted;
                _context.Database.ExecuteSqlRaw($"DELETE FROM Salida WHERE InventarioId={salida.InventarioId};");
                _context.Entry(salida).State = EntityState.Detached;
            }

            _context.Salidas.Remove(salida);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}