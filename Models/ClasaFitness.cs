using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace DaibucatAntonia_CherechesIlincaMaria.Models
{
    public class ClasaFitness
    {
      
        public int Id { get; set; }
        public string NumeClasa { get; set; }
        public string Descriere { get; set; }
        public string Antrenor { get; set; }
        public string Zi { get; set; }

        [DataType(DataType.Date)]
        public DateTime Ora { get; set; } 
    }
}
