using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADDED.API.Models
{
    public class Compteur
    {   [Key]
        public int IdCtr { get; set; }
        [ForeignKey("Detaille")]
        public int IdOrdr { get; set; }
        public int? CodeCtr { get; set; }
        public int? DiamCtr { get; set; }
        public string NumCtr { get; set; }

        public virtual Detaille IdOrdrNavigation { get; set; }
    }
}
