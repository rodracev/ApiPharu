using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPharu.Model.Compras
{
    public class OrdenCompraDto
  {
    public string Departamento { get; set; }
    public string Solicitante { get; set; }
    public string Comprador { get; set; }
    public string PendCompras { get; set; }
    public int Documento { get; set; }
    public string Estado { get; set; }
    public string OC { get; set; }
    public string RcptStage { get; set; }
    public string EstadoOC { get; set; }
    public string Bodega { get; set; }
    public string Aprobador { get; set; }
    public string Equipo { get; set; }
    public string Descripcion { get; set; }
    public decimal Importe { get; set; }
    public string Moneda { get; set; }
    public DateTime? Fecha { get; set; }
    public DateTime? FechaEntrega { get; set; }
    public string Procedencia { get; set; }
    public string? FechaGeneracionOC { get; set; }
    public string VendID { get; set; }
    public string Vendname { get; set; }
    public string OT { get; set; }
    public DateTime? FechaRecepcion { get; set; }
    public string Entidad { get; set; }
    public string Articulo { get; set; }
    public string DescripArticulo { get; set; }
    public decimal Cantidad { get; set; }
    public decimal CU { get; set; }
    public decimal CE { get; set; }
    public decimal LineNbr { get; set; }
    public double? CantidadRecibida { get; set; }
    public string MetodoRetiro { get; set; }
    public string UU { get; set; }
     public DateTime? Ult_act_Linea { get; set; }
}
}