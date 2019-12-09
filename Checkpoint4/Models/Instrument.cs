using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Checkpoint4.Models
{
    [Table("Instrument")]
    public class Instrument
    {
        [Key]
        public int Instrument_ID { get; set; }
        public string Desc { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public int? Client_ID { get; set; }

    }
}