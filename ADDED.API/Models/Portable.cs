using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADDED.API.Models
{
    public class Portable
    {   [Key]
        public int IdPort { get; set; }
        [ForeignKey("Releveur")]
        public int? IdReleveur { get; set; }
        public string MarquePort { get; set; }
        public int? EtatPort { get; set; }
        public DateTime? DatAffect { get; set; }
        public virtual Releveur IdReleveurNavigation { get; set; }
    }
}
