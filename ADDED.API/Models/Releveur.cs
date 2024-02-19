using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADDED.API.Models
{
    public class Releveur
    {
        public Releveur()
        {
            Tournee = new HashSet<Tournee>();
        }
        [Key]
        public int IdReleveur { get; set; }
        [ForeignKey("Localite")]
        public int CodLocalite { get; set; }
        public string TSPUsername { get; set; }
        public string TSPPassword { get; set; }

        public virtual Localite LocaliteNavigation { get; set; }
        public virtual Portable Portable { get; set; }
        public virtual ICollection<Tournee> Tournee { get; set; }
    }
}
