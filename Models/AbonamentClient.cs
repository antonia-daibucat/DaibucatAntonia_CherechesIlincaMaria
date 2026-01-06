namespace DaibucatAntonia_CherechesIlincaMaria.Models
{
    public class AbonamentClient
    {
        public int AbonamentClientId { get; set; }

        public int UserId { get; set; } // FK
        public User User { get; set; } 

        public int AbonamentId { get; set; } // FK
        public Abonament Abonament { get; set; } 

        public DateTime DataInceput { get; set; }
        public DateTime DataSfarsit { get; set; }
        public bool Activ { get; set; }

        // Relație: Un AbonamentClient poate avea multe Plati
        public ICollection<Plata> Plati { get; set; }
    }
}
