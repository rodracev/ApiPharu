using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPharu.Model;
using ApiPharu.Data;

namespace ApiPharu.Controllers
{
    [Route("api/inventario/articulos")]
    [ApiController]
    public class InventarioController : ControllerBase
    {
        private readonly Bc365 _context;
        public InventarioController(Bc365 context)
        {
             _context = context;
        }


       
        [HttpGet("Todos")]
        public async Task<IActionResult> ObtenerArticulosPaginados([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 100)
        {
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1) pageSize = 100;

            var totalRegistros = await _context.PharuInvs.CountAsync();  // Total de registros
            var totalPaginas = (int)Math.Ceiling(totalRegistros / (double)pageSize);  // Total de páginas

            var skip = (pageNumber - 1) * pageSize;

            var articulos = await _context.PharuInvs
                .OrderBy(a => a.InvtID)
                .Skip(skip)
                .Take(pageSize)
                .ToListAsync();

            var result = new
            {
                TotalRegistros = totalRegistros,
                TotalPaginas = totalPaginas,
                PageNumber = pageNumber,
                PageSize = pageSize,
                Articulos = articulos
            };

            return Ok(result);
        }
        [HttpGet("invtid/{invtID}")]
        public async Task<IActionResult> ObtenerArticuloPorId(string invtID)
        {
            // Busca el artículo por el ID proporcionado
            var articulo = await _context.PharuInvs
                                        .FirstOrDefaultAsync(a => a.InvtID == invtID);

            if (articulo == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra el artículo
            }

            return Ok(articulo); // Devuelve el artículo si se encuentra
        }
         [HttpGet("siteid/{siteID}")]
        public async Task<IActionResult> ObtenerArticuloPorSite(string siteID)
        {
            // Busca el artículo por el ID proporcionado
            var articulo = await _context.PharuInvs
                                      .Where(a => a.SiteID == siteID)
                                      .ToListAsync();

        if (articulo == null || articulo.Count == 0)
        {
            return NotFound(); // Devuelve 404 si no se encuentran artículos
        }

            return Ok(articulo); // Devuelve el artículo si se encuentra
        }
          [HttpGet("repuestos")]
        public async Task<IActionResult> ObtenerRepuesto()
        {
            // Busca el artículo por el ID proporcionado
            var articulo = await _context.Inventorys
                                    .Where(a =>  EF.Functions.Like(a.Classid, "%REPUESTO%"))
                                    .ToListAsync();

        if (articulo == null || articulo.Count == 0)
        {
            return NotFound(); // Devuelve 404 si no se encuentran artículos
        }

            return Ok(articulo); // Devuelve el artículo si se encuentra
        }
         [HttpGet("repuestosfecha")]
        public async Task<IActionResult> ObtenerRepuestofecha([FromQuery] DateTime fechaDesde, [FromQuery] DateTime fechaHasta)
        {
            // Busca el artículo por el ID proporcionado
            var articulo = await _context.Inventorys
                                    .Where(a =>  EF.Functions.Like(a.Classid, "%REPUESTO%") && a.Last_Date_Modified >=fechaDesde && a.Last_Date_Modified <= fechaHasta)
                                    .ToListAsync();

        if (articulo == null || articulo.Count == 0)
        {
            return NotFound(); // Devuelve 404 si no se encuentran artículos
        }

            return Ok(articulo); // Devuelve el artículo si se encuentra
        }
    }
}