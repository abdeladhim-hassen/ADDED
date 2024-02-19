using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADDED.API.Models
{
    public class Localite
    {
        public Localite()
        {
            Releveur = new HashSet<Releveur>();
        }
        [Key]
        public int CodLocalite { get; set; }
        [ForeignKey("District")]
        public int CodDist { get; set; }
        public string LibLocalite { get; set; }
        public string TelLocalite { get; set; }

        public virtual District CodDistNavigation { get; set; }
        public virtual ICollection<Releveur> Releveur { get; set; }
    }
}
