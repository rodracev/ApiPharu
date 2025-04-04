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
          [HttpGet("Todos")]
       public async Task<IActionResult> ObtenerMovimientos()
        {
            // Realizar la consulta LINQ equivalente a la SQL que enviaste
          // Obtener los datos de PharuMovs desde _context
var movimientos = await _context.PharuMovs.AsNoTracking().ToListAsync();

// Obtener los datos de WorkOrders y MeterReadings desde _mcontext
var workOrders = await _mcontext.WorkOrders.AsNoTracking().Where(w => w.Woclass == "WORKORDER")
.ToListAsync();
var meterReadings = await _mcontext.MeterReadings.AsNoTracking().ToListAsync();

// Unir los datos en memoria
var query = (from a in movimientos
             join e in workOrders on a.OT_MAXIMO equals e.Wonum
             select new
             {
                 a.Periodo,
                 a.Movimiento,
                 a.TipodeSalida,
                 a.Bodega,
                 a.Localizacion,
                 a.Clase,
                 Articulo = a.Articulo.Replace("\t", ""),
                 Descripcion = a.Descripcion.Replace("\t", ""),
                 a.UM,
                 a.Cantidad,
                 a.Fecha,
                 a.FechaAfectacion,
                 a.Anio,
                 a.Lote,
                 a.Referencia,
                 a.CuentaCosto,
                 a.EntidadCosto,
                 a.CuentaInventario,
                 a.EntidadInventario,
                 a.Proyecto,
                 a.Actividad,
                 a.CargoA,
                 a.OT_MAXIMO,
                 a.Equipo,
                 a.CostoUnit,
                 a.CostoExtendido,
                 a.RUTEmpleado,
                 a.UUsuaria,
                 a.Usuario,
                 a.OC,
                 Horo = (from m in meterReadings
                         where m.AssetNum == e.AssetNum &&
                               Math.Abs((a.Fecha - m.EnterDate).Days) == 
                               meterReadings.Where(mm => mm.AssetNum == e.AssetNum)
                                            .Min(mm => Math.Abs((a.Fecha - mm.EnterDate).Days))
                         select m.Reading).FirstOrDefault(),
                 e.WorkType
             }).ToList();

            return Ok(query);
        }
        
    }
}