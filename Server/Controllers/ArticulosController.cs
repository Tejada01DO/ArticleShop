using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArticleShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ArticulosController : ControllerBase
    {
        private readonly Context _context;

        public ArticulosController(Context context)
        {
            _context = context;
        }

        public bool Existe(int ArticuloId)
        {
            return (_context.Articulos?.Any(a => a.ArticuloId == ArticuloId)).GetValueOrDefault();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Articulos>>> Obtener()
        {
            if(_context.Articulos == null)
            {
                return NotFound();
            }
            else
            {
                return await _context.Articulos.ToListAsync();
            }
        }

        [HttpGet("{ArticuloId}")]
        public async Task<ActionResult<Articulos>> ObtenerArticulos(int ArticuloId)
        {
            if(_context.Articulos == null)
            {
                return NotFound();
            }

            var articulo = await _context.Articulos.FindAsync(ArticuloId);

            if(articulo == null)
            {
                return NotFound();
            }
            return articulo;
        }

        [HttpPost]
        public async Task<ActionResult<Articulos>> PostArticulos(Articulos articulos)
        {
            if(!Existe(articulos.ArticuloId))
            {
                _context.Articulos.Add(articulos);
            }
            else
            {
                _context.Articulos.Update(articulos);
            }

            await _context.SaveChangesAsync();
            return Ok(articulos);
        }

        [HttpDelete("{ArticuloId}")]
        public async Task<IActionResult> EliminarArticulos(int ArticuloId)
        {
            if(_context.Articulos == null)
            {
                return NotFound();
            }

            var articulo = await _context.Articulos.FindAsync(ArticuloId);

            if(articulo == null)
            {
                return NotFound();
            }

            _context.Articulos.Remove(articulo);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}