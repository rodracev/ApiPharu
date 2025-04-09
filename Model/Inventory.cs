using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPharu.Model
{
    [Table("Inventory", Schema = "BI")]
    public class Inventory
    {
        public string CpnyID { get; set; }
        public string InvtID { get; set; }
        public string Classid { get; set; }
        public string Descr { get; set; }
        public string ValMthd { get; set; }
        public string TranStatusCode { get; set; }
        public int User6 { get; set; }
        public string StkUnit { get; set; }
        public string InvtAcct { get; set; }
        public string InvtSub { get; set; }
        public DateTime Last_Date_Modified{ get; set; }
    }
}