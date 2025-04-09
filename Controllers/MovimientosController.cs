using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiPharu.Model;
using ApiPharu.Data;

namespace ApiPharu.Controllers
{
    
    [Route("api/inventario/movimientos")]
    [ApiController]
    public class MovimientosController : ControllerBase
    {
        private readonly Bc365 _context;
         private readonly Maximo _mcontext;
        public MovimientosController(Bc365 context,Maximo mcontext)
        {
             _context = context;
             _mcontext = mcontext;
        }
         [HttpGet("fecha")]
        public async Task<IActionResult> ObtenerMovimientosPorRangoFecha([FromQuery] string startDate, [FromQuery] string endDate)
        {
            if (DateTime.TryParse(startDate, out var parsedStartDate) && DateTime.TryParse(endDate, out var parsedEndDate))
            {
                if (parsedStartDate > parsedEndDate)
                {
                    return BadRequest("La fecha de inicio no puede ser mayor que la fecha de fin.");
                }

                var movimientos = await _context.PharuMovs
                    .AsNoTracking()
                    .Where(m => m.Fecha >= parsedStartDate && m.Fecha <= parsedEndDate)
                    .ToListAsync();
                return Ok(movimientos);
            }
            else
            {
                return BadRequest("Las fechas proporcionadas no son válidas.");
            }
        }
         [HttpGet("articulo/{invtID}")]
        public async Task<IActionResult> ObtenerMovimientosPorArticulos(string invtID,[FromQuery] string startDate, [FromQuery] string endDate)
        {
            if (DateTime.TryParse(startDate, out var parsedStartDate) && DateTime.TryParse(endDate, out var parsedEndDate))
            {
                if (parsedStartDate > parsedEndDate)
                {
                    return BadRequest("La fecha de inicio no puede ser mayor que la fecha de fin.");
                }
                var Movarticulos = await _context.PharuMovs
                                            .Where(a => a.Articulo == invtID &&  a.Fecha >= parsedStartDate && a.Fecha <= parsedEndDate)
                                            .ToListAsync();

                if (Movarticulos == null)
                {
                    return NotFound(); // Devuelve 404 si no se encuentra el artículo
                }

                return Ok(Movarticulos); // Devuelve el artículo si se encuentra
            }
            else
            {
                return BadRequest("Las fechas proporcionadas no son válidas.");
            }
            
        }

         [HttpGet("bodega/{Bodega}")]
        public async Task<IActionResult> ObtenerMovimientosPorBodega(string Bodega,[FromQuery] string startDate, [FromQuery] string endDate)
        {
            if (DateTime.TryParse(startDate, out var parsedStartDate) && DateTime.TryParse(endDate, out var parsedEndDate))
            {
                if (parsedStartDate > parsedEndDate)
                {
                    return BadRequest("La fecha de inicio no puede ser mayor que la fecha de fin.");
                }
                var Movarticulos = await _context.PharuMovs
                                            .Where(a => a.Bodega == Bodega &&  a.Fecha >= parsedStartDate && a.Fecha <= parsedEndDate)
                                            .ToListAsync();
                if (Movarticulos == null)
                {
                    return NotFound(); // Devuelve 404 si no se encuentra el artículo
                }
                return Ok(Movarticulos); // Devuelve el artículo si se encuentra
            }
            else
            {
                return BadRequest("Las fechas proporcionadas no son válidas.");
            }

            
        }
        
    }
}