using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ADDED.API.Models
{
    public class Anomalie
    {
        public Anomalie()
        {
            ListAnomalie = new HashSet<ListAnomalie>();
            Creation = new HashSet<Creation>();
        }
        [Key]
        public string IdAno { get; set; }
        public string LibAno { get; set; }

        public virtual ICollection<ListAnomalie> ListAnomalie { get; set; }
        public virtual ICollection<Creation> Creation { get; set; }
    }
}
