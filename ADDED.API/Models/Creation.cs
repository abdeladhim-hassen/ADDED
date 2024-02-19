using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADDED.API.Models
{
    public class Creation
    {   [Key]
        public int IdCrea { get; set; }
        [ForeignKey("Anomalie")]
        public string IdAno { get; set; }
        public string CreaNumCtr { get; set; }
        public string CreaAdressse { get; set; }
        public int? CreaTour { get; set; }
        public int? CreaOrdr { get; set; }
        [Column(TypeName = "decimal(6,0)")]
        public decimal? CreaIndex { get; set; }

        public virtual Anomalie AnoNavigation { get; set; }
    }
}
