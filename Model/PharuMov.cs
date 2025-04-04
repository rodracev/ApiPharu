using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPharu.Model
{
     [Table("Pharu_Movs", Schema = "BI")]
    public class PharuMov
    {
         public string Periodo { get; set; }
        public string Movimiento { get; set; }
        
        [Column("Tipode Salida")]
        public string TipodeSalida { get; set; }
        
        public string Bodega { get; set; }
        public string Localizacion { get; set; }
        public string Clase { get; set; }
        public string Articulo { get; set; }
        public string Descripcion { get; set; }
        public string UM { get; set; }
        public double Cantidad { get; set; }
        
        public DateTime Fecha { get; set; }
        
        [Column("Fecha Afectacion")]
        public DateTime FechaAfectacion { get; set; }
        
        [Column("Año")]
        public string Anio { get; set; }
        
        public int Lote { get; set; }
        public string Referencia { get; set; }
        
        [Column("Cuenta Costo")]
        public string CuentaCosto { get; set; }
        
        [Column("Entidad Costo")]
        public string EntidadCosto { get; set; }
        
        [Column("Cuenta Inventario")]
        public string CuentaInventario { get; set; }
        
        [Column("Entidad Inventario")]
        public string EntidadInventario { get; set; }
        
        public string Proyecto { get; set; }
        public string Actividad { get; set; }
        public string CargoA { get; set; }
        
        public string OT_MAXIMO { get; set; }
        public string Equipo { get; set; }
        
        public double CostoUnit { get; set; }
        public double CostoExtendido { get; set; }
        
        [Column("RUT_Empleado")]
        public string RUTEmpleado { get; set; }
        
        [Column("U. Usuaria")]
        public string UUsuaria { get; set; }
        
        public string Usuario { get; set; }
        public string OC { get; set; }
    }
}