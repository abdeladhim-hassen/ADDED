using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADDED.API.Models
{
    public class ChoixPlan
    {
        public ChoixPlan()
        {
            Tournee = new HashSet<Tournee>();
        }
        [Key]
        public string IdPeriode { get; set; }
        [ForeignKey("Chef")]
        public int IdChef { get; set; }
        public DateTime? DatExploi { get; set; }

        public virtual Chef IdChefNavigation { get; set; }
        public virtual ICollection<Tournee> Tournee { get; set; }
    }
}
