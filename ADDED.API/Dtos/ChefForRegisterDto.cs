using System.ComponentModel.DataAnnotations;

namespace ADDED.API.Dtos
{
    public class ChefForRegisterDto
    {   [Required]
        public int CodDist { get; set; }
        [Required]
        public string NomChef { get; set; }
        [Required]
        public string PrenomChef { get; set; }
        [Required]
        public int TelChef { get; set; }
        [Required]
        public string MailChef { get; set; }
         [Required]
         [StringLength(8,MinimumLength = 4,ErrorMessage = "il faut que la mot de passe entre 4 and 8 caracters")]
        public string Password { get; set; }
    }
}