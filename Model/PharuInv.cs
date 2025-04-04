using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPharu.Model
{
    [Table("Pharu_Inv", Schema = "BI")]
    public class PharuInv
    {
         [Required]
        public string InvtID { get; set; }

        [Required]
        public string SiteID { get; set; }

        public string Descr { get; set; }

        public double Cantidad { get; set; }

        public string Clase { get; set; }

        public string Unidad_Usuaria { get; set; }

        public string Unidad { get; set; }

        public double Costo_Unitario { get; set; }

        public double Costo_Ext { get; set; }

        public double Reservas { get; set; }
    }
}