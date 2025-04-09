using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ApiPharu.Model.Compras
{
    [Table("Pharu_PMs", Schema = "BI")]
    public class PharuPM
    {
        public string Departamento { get; set; }
        public string Solicitante { get; set; }
        public string Comprador { get; set; }
        public string PendCompras { get; set; }
        public int Documento { get; set; }
        public string Estado { get; set; }
        public string OC { get; set; }
        public string Status { get; set; }
        public string EstadoLinea { get; set; }

        [Column("Estado OC")]
        public string EstadoOC { get; set; }

        public string Bodega { get; set; }
        public string Aprobador { get; set; }
        public string Equipo { get; set; }
        public string Descripcion { get; set; }
        public decimal Importe { get; set; }
        public string Moneda { get; set; }
        public DateTime? Fecha { get; set; }

        [Column("Fecha entrega")]
        public DateTime? FechaEntrega { get; set; }

        public string Procedencia { get; set; }

        [Column("Fecha Generación OC")]
        public string? FechaGeneracionOC { get; set; }

        public string VendID { get; set; }
        public string OT { get; set; }

        [Column("Fecha U. Recepción OC")]
        public DateTime? FechaURecepcionOC { get; set; }

        public string Entidad { get; set; }
        public string Articulo { get; set; }

        [Column("Descrip.Articulo")]
        public string DescripArticulo { get; set; }

        public decimal Cantidad { get; set; }
        public decimal CU { get; set; }
        public decimal CE { get; set; }
        public decimal LineNbr { get; set; }

        [Column("Cantidad recibida")]
        public string CantidadRecibida { get; set; }

        [Column("Metodo Retiro")]
        public string MetodoRetiro { get; set; }

        public string? PSA_UpdatedAt { get; set; }
        public string CargoA { get; set; }

        [Column("Ult Act Linea")]
        public DateTime? Ult_act_Linea { get; set; }

        [Column("u.usuaria")]
        public string UUsuaria { get; set; }
    }
}