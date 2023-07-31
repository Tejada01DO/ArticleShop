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
            return (_context.Ventas?.Any(v => v.VentaId == VentaId)).GetValueOrDefault();
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

            var venta = await _context.Ventas.Include(v => v.ventasDetalles).Where(v => v.VentaId == VentaId).FirstOrDefaultAsync();

            if(venta == null)
            {
                return NotFound();
            }

            foreach(var item in venta.ventasDetalles)
            {
                Console.WriteLine($"{item.DetalleId}, {item.VentaId}, {item.ArticuloId}, {item.CantidadUtilizada}, {item.Precio}");
            }

            return venta;
        }

        [HttpPost]
        public async Task<ActionResult<Ventas>> PostVentas(Ventas ventas)
        {
            if(!Existe(ventas.VentaId))
            {
                Articulos? articulos = new Articulos();

                foreach(var ArticuloVacio in ventas.ventasDetalles)
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
                var ventaAnterior = _context.Ventas.Include(v => v.ventasDetalles).AsNoTracking()
                .FirstOrDefault(v => v.VentaId == ventas.VentaId);

                Articulos? articulos = new Articulos();

                if(ventaAnterior != null && ventaAnterior.ventasDetalles != null)
                {
                    foreach(var ArticuloVacio in ventaAnterior.ventasDetalles)
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

                _context.Database.ExecuteSql($"Delete from VentasDetalle where VentaId = {ventas.VentaId}");

                foreach(var ArticuloVacio in ventas.ventasDetalles)
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
            var venta = await _context.Ventas.Include(v => v.ventasDetalles).FirstOrDefaultAsync(v => v.VentaId == VentaId);

            if(venta == null)
            {
                return NotFound();
            }

            foreach(var ArticuloVacio in venta.ventasDetalles)
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