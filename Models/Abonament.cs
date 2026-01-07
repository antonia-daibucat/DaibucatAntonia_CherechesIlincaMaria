using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaibucatAntonia_CherechesIlincaMaria.Models
{
    public class Abonament
    {
        public int AbonamentId { get; set; }
        [Display(Name = "Tip Abonament")]
        public string NumeAbonament { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Pret { get; set; }
        public string Descriere { get; set; }

    }
}
