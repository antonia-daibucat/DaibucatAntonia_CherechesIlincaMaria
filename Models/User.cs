using System.ComponentModel.DataAnnotations;

namespace DaibucatAntonia_CherechesIlincaMaria.Models
{
    public class User
    {
        public int UserId { get; set; }
      
        public string Email { get; set; }
        public string ParolaHash { get; set; } // Stochezi parola criptată
        [StringLength(30, MinimumLength = 3)]
        [Display(Name = "Nume Membru")]
        public string Nume { get; set; }
        public string Prenume { get; set; }
        [RegularExpression(@"^0[0-9]{9}$", ErrorMessage = "Numărul de telefon trebuie să înceapă cu 0 și să aibă fix 10 cifre.")]
        public string Telefon { get; set; }
        public string Rol { get; set; } // "Admin" sau "Client"
        // Relație: Un utilizator poate avea multe abonamente
        public ICollection<AbonamentClient>? AbonamenteClient { get; set; }
    }

}

