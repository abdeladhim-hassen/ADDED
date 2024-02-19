using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADDED.API.Models
{
    public class Detaille
    {
        public Detaille()
        {
            Compteur = new HashSet<Compteur>();
            Historique = new HashSet<Historique>();
            Index = new HashSet<Index>();
            ListAnomalie = new HashSet<ListAnomalie>();
        }
        [Key]
        public int IdOrdr { get; set; }
        [ForeignKey("Tournee")]
        public int IdTour { get; set; }
        public int? Ordre { get; set; }
        public string Police { get; set; }
        public string NomAbn { get; set; }
        public string AdrAbn { get; set; }
        public byte? Marche { get; set; }
        public byte? Resilie { get; set; }
        public int? CodeUsage { get; set; }
        [Column(TypeName = "decimal(6,0)")]
        public decimal? AncienIndex { get; set; }
        public int? Categ { get; set; }

        public virtual Tournee IdTourNavigation { get; set; }
        public virtual ICollection<Compteur> Compteur { get; set; }
        public virtual ICollection<Historique> Historique { get; set; }
        public virtual ICollection<Index> Index { get; set; }
        public virtual ICollection<ListAnomalie> ListAnomalie { get; set; }
    }
}
