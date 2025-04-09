using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ApiPharu.Model.Compras
{
    [Table("POTran", Schema = "BI")]
    public class POTran
    {
        public string CpnyID { get; set; }
        public string RcptNbr { get; set; }
        public string LineRef { get; set; }
        public string PONbr { get; set; }
        public string InvtID { get; set; }
        public double? Qty { get; set; }
        public DateTime? RcptDate { get; set; }
    }
}