using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ADDED.API.Models
{
    public class District
    {
        public District()
        {
            Localite = new HashSet<Localite>();
            Chef = new HashSet<Chef>();
        }
        [Key]
        public int CodDist { get; set; }
        public string NomDist { get; set; }
        public string AdrDist { get; set; }
        public string TelDist { get; set; }
        public string MailDist { get; set; }

        public virtual ICollection<Localite> Localite { get; set; }
        public virtual ICollection<Chef> Chef { get; set; }
    }
}
