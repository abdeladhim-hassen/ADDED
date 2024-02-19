using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADDED.API.Models
{
    public class Chef
    {
        public Chef()
        {
            ChoixPlan = new HashSet<ChoixPlan>();
            Tournee = new HashSet<Tournee>();
        }
        [Key]
        public int IdChef { get; set; }
        [ForeignKey("District")]
        public int CodDist { get; set; }
        public string NomChef { get; set; }
        public string PrenomChef { get; set; }
        public int TelChef { get; set; }
        public string MailChef { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public virtual District CodDistNavigation { get; set; }
        public virtual ICollection<ChoixPlan> ChoixPlan { get; set; }
        public virtual ICollection<Tournee> Tournee { get; set; }
    }
}
