using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGymMobile.Models
{
    public class UserProfileDTO
    {
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Parola { get; set; }
        public List<AbonamentMobilDTO> Abonamente { get; set; }
    }

    public class AbonamentMobilDTO
    {
        public int AbonamentClientId { get; set; }
        public string TipAbonament { get; set; }
        public DateTime DataInceput { get; set; }
        public DateTime DataSfarsit { get; set; }
        public bool EsteActiv { get; set; }
        public List<PlataMobilDTO> IstoricPlati { get; set; }
    }

    public class PlataMobilDTO
    {
        public int PlataId { get; set; }
        public decimal Suma { get; set; }
        public DateTime DataPlata { get; set; }
        public string MetodaPlata { get; set; }
    }
}
