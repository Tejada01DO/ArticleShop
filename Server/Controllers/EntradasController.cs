using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ArticleShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EntradasController : ControllerBase
    {
        private readonly Context _context;

        public EntradasController(Context context)
        {
            _context = context;
        }

        public bool Existe(int InventarioId)
        {
            return (_context.Entradas?.Any(e => e.InventarioId == InventarioId)).GetValueOrDefault();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entrada>>> Obtener()
        {
            if(_context.Entradas == null)
            {
                return NotFound();
            }
            else
            {
                return await _context.Entradas.ToListAsync();
            }
        }

        [HttpGet("{InventarioId}")]
        public async Task<ActionResult<Entrada>> ObtenerEntrada(int InventarioId)
        {
            if(_context.Entradas == null)
            {
                return NotFound();
            }

            var entrada = await _context.Entradas.FindAsync(InventarioId);

            if(entrada == null)
            {
                return NotFound();
            }
            return entrada;
        }

        [HttpPost]
        public async Task<ActionResult<Entrada>> PostEntradas(Entrada entrada)
        {
            if(!Existe(entrada.InventarioId))
            {
                 _context.Database.ExecuteSqlRaw($"UPDATE Articulos SET Existencia = Existencia + {entrada.Cantidad}  WHERE ArticuloId={entrada.ArticuloId}");
                _context.Entradas.Add(entrada);
            }
            else
            {
                _context.Entry(entrada).State = EntityState.Modified;
                _context.Entry(entrada).State = EntityState.Detached;
                _context.Entradas.Update(entrada);
            }

            await _context.SaveChangesAsync();
            return Ok(entrada);
        }

        [HttpDelete("{InventarioId}")]
        public async Task<IActionResult> EliminarEntrada(int InventarioId)
        {
            if(_context.Entradas == null)
            {
                return NotFound();
            }

            var entrada = await _context.Entradas.FindAsync(InventarioId);

            if(entrada == null)
            {
                return NotFound();
            }
            else
            {
                _context.Entry(entrada).State=EntityState.Deleted;
                _context.Database.ExecuteSqlRaw($"DELETE FROM entrada WHERE InventarioId={entrada.InventarioId};");
                _context.Entry(entrada).State = EntityState.Detached;
            }

            _context.Entradas.Remove(entrada);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        public bool Inventario(Entrada entrada)
        {
            _context.Database.ExecuteSqlRaw($"UPDATE Articulos SET Existencia = {entrada.Cantidad}  WHERE ArticuloID={entrada.ArticuloId}");
            _context.Entradas.Add(entrada);
            return _context.SaveChanges() > 0;
        }
    }
}