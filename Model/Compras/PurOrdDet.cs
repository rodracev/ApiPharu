using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPharu.Model.Compras
{
    [Table("PurOrdDet", Schema = "BI")]
    public class PurOrdDet
    {
        public string CpnyID { get; set; }
        public string PONbr { get; set; }
        public string InvtID { get; set; }
        public DateTime? PromDate { get; set; }
        public decimal? ExtCost { get; set; }
        public decimal? QtyOrd { get; set; }

        [Column("user1")]
        public string User1 { get; set; }

        public string TranDesc { get; set; }
        public decimal? UnitCost { get; set; }
        public string PurchaseType { get; set; }
        public string SiteID { get; set; }

        [Column("User5")]
        public string User5 { get; set; }

        [Column("rcptstage")]
        public string RcptStage { get; set; }

        [Column("qtyrcvd")]
        public decimal? QtyRcvd { get; set; }

        [Column("qtyreturned")]
        public int? QtyReturned { get; set; }

        public string PurSub { get; set; }
        public string ProjectID { get; set; }

        [Column("PC_Status")]
        public string PC_Status { get; set; }
    }
}