using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADDED.API.Models
{
    public class Tournee
    {
        public Tournee()
        {
            Detaille = new HashSet<Detaille>();
        }
        [Key]
        public int IdTour { get; set; }
        public int Tour { get; set; }
        [ForeignKey("Releveur")]
        public int? IdReleveur { get; set; }
        [ForeignKey("Chef")]
        public int? IdChef { get; set; }
        [ForeignKey("ChoixPlan")]
        public string IdPeriode { get; set; }
        public DateTime? DatAffect { get; set; }
        public bool? Etat { get; set; }

        public virtual ChoixPlan IdPeriodeNavigation { get; set; }
        public virtual Releveur IdReleveurNavigation { get; set; }
        public virtual Chef IdChefNavigation { get; set; }
        public virtual ICollection<Detaille> Detaille { get; set; }
    }
}
