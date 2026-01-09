using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGymMobile.Models
{
    public class ClasaFitnessDTO
    {
        public int Id { get; set; }
        public string NumeClasa { get; set; }
        public string Descriere { get; set; }
        public string Antrenor { get; set; }
        public string Zi { get; set; }

        // DateTimeOffset este adesea mai sigur decât DateTime pentru datele JSON
        public DateTimeOffset OraInceput { get; set; }
    }
}
