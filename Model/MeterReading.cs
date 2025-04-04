using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPharu.Model
{
       [Table("meterreading", Schema = "dbo")]
    public class MeterReading
    {
        public int MeterReadingId { get; set; }
        public string AssetNum { get; set; }
        public DateTime EnterDate { get; set; }
        public decimal Reading { get; set; }
    }
}