using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArticleShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ComprasController : ControllerBase
    {
        private readonly Context _context;

        public ComprasController(Context context)
        {
            _context = context;
        }

        public bool Existe(int CompraId)
        {
            return (_context.Compras?.Any(c => c.CompraId == CompraId)).GetValueOrDefault();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Compras>>> Obtener()
        {
            if(_context.Compras == null)
            {
                return NotFound();
            }
            else
            {
                
                return await _context.Compras.ToListAsync();
            }
        }

        [HttpGet("{CompraId}")]
        public async Task<ActionResult<Compras>> ObtenerCompra(int CompraId)
        {
            if(_context.Compras == null)
            {
                return NotFound();
            }
            
            var compra = await _context.Compras.Include(c => c.CompraDetalle).Where(c => c.CompraId == CompraId).FirstOrDefaultAsync();

            if(compra == null)
            {
                return NotFound();
            }

            return compra;
        }

        [HttpPost]
        public async Task<ActionResult<Compras>> PostCompras(Compras compras)
        {
            if(!Existe(compras.CompraId))
            {
                Articulos? articulos = new Articulos();

                foreach(var ArticuloVacio in compras.CompraDetalle)
                {
                    articulos = _context.Articulos.Find(ArticuloVacio.ArticuloId);

                    if(articulos != null)
                    {
                        articulos.Existencia += ArticuloVacio.CantidadUtilizada;
                        _context.Articulos.Update(articulos);
                        await _context.SaveChangesAsync();
                        _context.Entry(articulos).State = EntityState.Detached;
                    }
                }
                await _context.Compras.AddAsync(compras);
            }
            else
            {
                var compraAnterior = _context.Compras.Include(c => c.CompraDetalle).AsNoTracking()
                .FirstOrDefault(c => c.CompraId == compras.CompraId);

                Articulos? articulos = new Articulos();

                if(compraAnterior != null && compraAnterior.CompraDetalle != null)
                {
                    foreach(var ArticuloVacio in compraAnterior.CompraDetalle)
                    {
                        if(ArticuloVacio != null)
                        {
                            articulos = _context.Articulos.Find(ArticuloVacio.ArticuloId);

                            if(articulos != null)
                            {
                                articulos.Existencia -= ArticuloVacio.CantidadUtilizada;
                                _context.Articulos.Update(articulos);
                                await _context.SaveChangesAsync();
                                _context.Entry(articulos).State = EntityState.Detached;
                            }
                        }
                    }
                }

                if(compraAnterior != null)
                {
                    articulos  = _context.Articulos.Find(compraAnterior.ArticuloId);

                    if(articulos != null)
                    {
                        articulos.Existencia += compraAnterior.CantidadProducida;
                        _context.Articulos.Update(articulos);
                        await _context.SaveChangesAsync();
                        _context.Entry(articulos).State = EntityState.Detached;
                    }
                }

                _context.Database.ExecuteSql($"Delete from ComprasDetalle where CompraId = {compras.CompraId}");

                foreach(var ArticuloVacio in compras.CompraDetalle)
                {
                    articulos = _context.Articulos.Find(ArticuloVacio.ArticuloId);

                    if(articulos != null)
                    {
                        articulos.Existencia += ArticuloVacio.CantidadUtilizada;
                        _context.Articulos.Update(articulos);
                        await _context.SaveChangesAsync();
                        _context.Entry(articulos).State = EntityState.Detached;
                        _context.Entry(ArticuloVacio).State = EntityState.Added;
                    }
                }

                articulos = _context.Articulos.Find(compras.ArticuloId);

                if(articulos != null)
                {
                    articulos.Existencia -= compras.CantidadProducida;
                    _context.Articulos.Update(articulos);
                    await _context.SaveChangesAsync();
                    _context.Entry(articulos).State = EntityState.Detached;
                }
                _context.Compras.Update(compras);
            }

            await _context.SaveChangesAsync();
            _context.Entry(compras).State = EntityState.Detached;
            return Ok(compras);
        }

        [HttpDelete("{CompraId}")]
        public async Task<IActionResult> EliminarCompra(int CompraId)
        {
            var compra = await _context.Compras.Include(c => c.CompraDetalle).FirstOrDefaultAsync(c => c.CompraId == CompraId);

            if(compra == null)
            {
                return NotFound();
            }

            foreach(var ArticuloVacio in compra.CompraDetalle)
            {
                var articulos = await _context.Articulos.FindAsync(ArticuloVacio.ArticuloId);

                if(articulos != null)
                {
                    articulos.Existencia -= ArticuloVacio.CantidadUtilizada;
                    _context.Articulos.Update(articulos);
                }
            }

            var articuloInicial = await _context.Articulos.FindAsync(compra.ArticuloId);

            if(articuloInicial != null)
            {
                articuloInicial.Existencia -= compra.CantidadProducida;
                _context.Articulos.Update(articuloInicial);
            }

            _context.Compras.Remove(compra);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}