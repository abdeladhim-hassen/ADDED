using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADDED.API.Models
{
    public class ListAnomalie
    {
        [Key]
        public int ListAno { get; set; }
        [ForeignKey("Anomalie")]
        public string IdAno { get; set; }
        [ForeignKey("Detaille")]
        public int IdOrdr { get; set; }

        public virtual Anomalie IdAnoNavigation { get; set; }
        public virtual Detaille IdOrdrNavigation { get; set; }
    }
}
