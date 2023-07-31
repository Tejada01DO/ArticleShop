using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArticleShop.Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class VentasController : ControllerBase
    {
        private readonly Context _context;

        public VentasController(Context context)
        {
            _context = context;
        }

        public bool Existe(int VentaId)
        {
            return (_context.Ventas?.Any(v => v.CompraId == VentaId)).GetValueOrDefault();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ventas>>> Obtener()
        {
            if(_context.Ventas == null)
            {
                return NotFound();
            }
            else
            {
                return await _context.Ventas.ToListAsync();
            }
        }

        [HttpGet("{VentaId}")]
        public async Task<ActionResult<Ventas>> ObtenerVenta(int VentaId)
        {
            if(_context.Ventas == null)
            {
                return NotFound();
            }

            var venta = await _context.Ventas.Include(v => v.CompraDetalle).Where(v => v.CompraId == VentaId).FirstOrDefaultAsync();

            if(venta == null)
            {
                return NotFound();
            }

            foreach(var item in venta.CompraDetalle)
            {
                Console.WriteLine($"{item.DetalleId}, {item.CompraId}, {item.ArticuloId}, {item.CantidadUtilizada}, {item.Precio}");
            }

            return venta;
        }

        [HttpPost]
        public async Task<ActionResult<Ventas>> PostVentas(Ventas ventas)
        {
            if(!Existe(ventas.CompraId))
            {
                Articulos? articulos = new Articulos();

                foreach(var ArticuloVacio in ventas.CompraDetalle)
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
                await _context.Ventas.AddAsync(ventas);
            }
            else
            {
                var ventaAnterior = _context.Ventas.Include(c => c.CompraDetalle).AsNoTracking()
                .FirstOrDefault(c => c.CompraId == ventas.CompraId);

                Articulos? articulos = new Articulos();

                if(ventaAnterior != null && ventaAnterior.CompraDetalle != null)
                {
                    foreach(var ArticuloVacio in ventaAnterior.CompraDetalle)
                    {
                        if(ArticuloVacio != null)
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
                    }
                }

                if(ventaAnterior != null)
                {
                    articulos  = _context.Articulos.Find(ventaAnterior.ArticuloId);

                    if(articulos != null)
                    {
                        articulos.Existencia -= ventaAnterior.CantidadProducida;
                        _context.Articulos.Update(articulos);
                        await _context.SaveChangesAsync();
                        _context.Entry(articulos).State = EntityState.Detached;
                    }
                }

                _context.Database.ExecuteSql($"Delete from ComprasDetalle where CompraId = {ventas.CompraId}");

                foreach(var ArticuloVacio in ventas.CompraDetalle)
                {
                    articulos = _context.Articulos.Find(ArticuloVacio.ArticuloId);

                    if(articulos != null)
                    {
                        articulos.Existencia -= ArticuloVacio.CantidadUtilizada;
                        _context.Articulos.Update(articulos);
                        await _context.SaveChangesAsync();
                        _context.Entry(articulos).State = EntityState.Detached;
                        _context.Entry(ArticuloVacio).State = EntityState.Added;
                    }
                }

                articulos = _context.Articulos.Find(ventas.ArticuloId);

                if(articulos != null)
                {
                    articulos.Existencia += ventas.CantidadProducida;
                    _context.Articulos.Update(articulos);
                    await _context.SaveChangesAsync();
                    _context.Entry(articulos).State = EntityState.Detached;
                }
                _context.Ventas.Update(ventas);
            }

            await _context.SaveChangesAsync();
            _context.Entry(ventas).State = EntityState.Detached;
            return Ok(ventas);
        }

        [HttpDelete("{VentaId}")]
        public async Task<IActionResult> EliminarVenta(int VentaId)
        {
            var venta = await _context.Ventas.Include(v => v.CompraDetalle).FirstOrDefaultAsync(v => v.CompraId == VentaId);

            if(venta == null)
            {
                return NotFound();
            }

            foreach(var ArticuloVacio in venta.CompraDetalle)
            {
                var articulos = await _context.Articulos.FindAsync(ArticuloVacio.ArticuloId);

                if(articulos != null)
                {
                    articulos.Existencia += ArticuloVacio.CantidadUtilizada;
                    _context.Articulos.Update(articulos);
                }
            }

            var articuloInicial = await _context.Articulos.FindAsync(venta.ArticuloId);

            if(articuloInicial != null)
            {
                articuloInicial.Existencia += venta.CantidadProducida;
                _context.Articulos.Update(articuloInicial);
            }

            _context.Ventas.Remove(venta);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}