using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADDED.API.Models
{
    public class Historique
    {   [Key]
        public int IdHisto { get; set; }
        [ForeignKey("Detaille")]
        public int IdOrdr { get; set; }
        public int? TrimHisto { get; set; }
        public int? AnHisto { get; set; }
        [Column(TypeName = "decimal(6,0)")]
        public decimal? ConsHisto { get; set; }

        public virtual Detaille IdOrdrNavigation { get; set; }
    }
}
