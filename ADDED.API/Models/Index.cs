using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADDED.API.Models
{
    public class Index
    {   [Key]
        public int IdIndex { get; set; }
        [ForeignKey("Detaille")]
        public int IdOrdr { get; set; }
        [Column(TypeName = "decimal(6,0)")]
        public decimal? NouvIndex { get; set; }
        public DateTime? DatIndex { get; set; }
        public string Observ { get; set; }

        public virtual Detaille IdOrdrNavigation { get; set; }
    }
}
