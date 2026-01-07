using System.ComponentModel.DataAnnotations;

namespace DaibucatAntonia_CherechesIlincaMaria.Models
{
    public class User
    {
        public int UserId { get; set; }
      
        public string Email { get; set; }
        public string ParolaHash { get; set; } // Stochezi parola criptată
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Telefon { get; set; }
        public string Rol { get; set; } // "Admin" sau "Client"
        
    }
}
