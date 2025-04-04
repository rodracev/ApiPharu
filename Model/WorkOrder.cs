using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPharu.Model
{
    [Table("workorder", Schema = "dbo")]
    public class WorkOrder
    {
        [Key]
        public string Wonum { get; set; }
        public string WorkType { get; set; }
        public string AssetNum { get; set; }
        public string Woclass { get; set; }
    }
}