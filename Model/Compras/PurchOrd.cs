using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ApiPharu.Model.Compras
{
    [Table("PurchOrd", Schema = "BI")]
    public class PurchOrd
    {
        public string PONbr { get; set; }
        public DateTime? PODate { get; set; }
        public string VendID { get; set; }
        public string Vendname { get; set; }
        public string? LastRcptDate { get; set; }
        public string Status { get; set; }

        [Column("RcptStage")]
        public string RcptStage { get; set; }

        public string User1 { get; set; }
        public string CuryID { get; set; }

        [Column("Crtd_DateTime")]
        public string? CrtdDateTime { get; set; }

        public string CpnyID { get; set; }
        public string PerEnt { get; set; }

        [Column("crtd_prog")]
        public string CrtdProg { get; set; }

        public int POAmt { get; set; }
        public string User5 { get; set; }
        public string User6 { get; set; }
    }
}