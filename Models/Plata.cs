using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaibucatAntonia_CherechesIlincaMaria.Models
{
    public class Plata
    {
        public int PlataId { get; set; }

        public int AbonamentClientId { get; set; } // FK
        public AbonamentClient AbonamentClient { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Suma { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataPlata { get; set; }
        public string MetodaPlata { get; set; } 
    }
}
