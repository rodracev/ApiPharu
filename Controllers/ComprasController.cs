using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiPharu.Model;
using ApiPharu.Model.Compras;
using ApiPharu.Data;

namespace ApiPharu.Controllers
{
    [Route("api/compras")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
         private readonly Bc365 _context;
        public ComprasController(Bc365 context)
        {
             _context = context;
        }
        [HttpGet("fecha")]
        public async Task<IActionResult> GetReporteCompletoPorFecha([FromQuery] DateTime fechaDesde, [FromQuery] DateTime fechaHasta)
        {
           var data = await (from b in _context.PharuPMs
                  join a in _context.PurOrdDets on new { PONbr = b.OC, InvtID = b.Articulo } equals new { a.PONbr, a.InvtID } into a_join
                  from a in a_join.DefaultIfEmpty()
                  join c in _context.PurchOrds on b.OC equals c.PONbr into c_join
                  from c in c_join.DefaultIfEmpty()
                  join d in _context.POTrans on new { PONbr = b.OC, InvtID = b.Articulo } equals new { d.PONbr, d.InvtID } into d_join
                  from d in d_join.DefaultIfEmpty()
                  where b.Fecha >= fechaDesde && b.Fecha <= fechaHasta
                  select new OrdenCompraDto
                  {
                      Departamento = b.Departamento,
                      Solicitante = b.Solicitante,
                      Comprador = b.Comprador,
                      PendCompras = b.PendCompras,
                      Documento = b.Documento,
                      Estado = b.Estado,
                      OC = b.OC,
                      RcptStage = a != null ? a.RcptStage : null,
                      EstadoOC = b.EstadoOC,
                      Bodega = b.Bodega,
                      Aprobador = b.Aprobador,
                      Equipo = b.Equipo,
                      Descripcion = b.Descripcion,
                      Importe = b.Importe ,
                      Moneda = b.Moneda,
                      Fecha = b.Fecha,
                      FechaEntrega = b.FechaEntrega,
                      Procedencia = b.Procedencia,
                      FechaGeneracionOC = b.FechaGeneracionOC,
                      VendID = b.VendID,
                      Vendname =  c.Vendname,
                      OT = b.OT,
                      FechaRecepcion =  d.RcptDate,
                      Entidad = b.Entidad,
                      Articulo = b.Articulo,
                      DescripArticulo = b.DescripArticulo ,
                      Cantidad = b.Cantidad ,
                      CU = b.CU,
                      CE = b.CE ,
                      LineNbr = b.LineNbr,
                      CantidadRecibida = d.Qty,
                      MetodoRetiro = b.MetodoRetiro,
                      UU = b.UUsuaria,
                     Ult_act_Linea =b.Ult_act_Linea
                  }).Distinct().ToListAsync();

            return Ok(data);
        }
        [HttpGet("fechaupdate")]
        public async Task<IActionResult> GetReporteCompletoupdate([FromQuery] DateTime fechaDesde, [FromQuery] DateTime fechaHasta)
        {
           var data = await (from b in _context.PharuPMs
                  join a in _context.PurOrdDets on new { PONbr = b.OC, InvtID = b.Articulo } equals new { a.PONbr, a.InvtID } into a_join
                  from a in a_join.DefaultIfEmpty()
                  join c in _context.PurchOrds on b.OC equals c.PONbr into c_join
                  from c in c_join.DefaultIfEmpty()
                  join d in _context.POTrans on new { PONbr = b.OC, InvtID = b.Articulo } equals new { d.PONbr, d.InvtID } into d_join
                  from d in d_join.DefaultIfEmpty()
                  where b.Ult_act_Linea >= fechaDesde && b.Ult_act_Linea <= fechaHasta
                  select new OrdenCompraDto
                  {
                      Departamento = b.Departamento,
                      Solicitante = b.Solicitante,
                      Comprador = b.Comprador,
                      PendCompras = b.PendCompras,
                      Documento = b.Documento,
                      Estado = b.Estado,
                      OC = b.OC,
                      RcptStage = a != null ? a.RcptStage : null,
                      EstadoOC = b.EstadoOC,
                      Bodega = b.Bodega,
                      Aprobador = b.Aprobador,
                      Equipo = b.Equipo,
                      Descripcion = b.Descripcion,
                      Importe = b.Importe ,
                      Moneda = b.Moneda,
                      Fecha = b.Fecha,
                      FechaEntrega = b.FechaEntrega,
                      Procedencia = b.Procedencia,
                      FechaGeneracionOC = b.FechaGeneracionOC,
                      VendID = b.VendID,
                      Vendname =  c.Vendname,
                      OT = b.OT,
                      FechaRecepcion =  d.RcptDate,
                      Entidad = b.Entidad,
                      Articulo = b.Articulo,
                      DescripArticulo = b.DescripArticulo ,
                      Cantidad = b.Cantidad ,
                      CU = b.CU,
                      CE = b.CE ,
                      LineNbr = b.LineNbr,
                      CantidadRecibida = d.Qty,
                      MetodoRetiro = b.MetodoRetiro,
                      UU = b.UUsuaria,
                     Ult_act_Linea =b.Ult_act_Linea
                  }).Distinct().ToListAsync();

            return Ok(data);
        }

    }
}