using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DaibucatAntonia_CherechesIlincaMaria.Models;

namespace DaibucatAntonia_CherechesIlincaMaria.Data
{
    public class DaibucatAntonia_CherechesIlincaMariaContext : DbContext
    {
        public DaibucatAntonia_CherechesIlincaMariaContext (DbContextOptions<DaibucatAntonia_CherechesIlincaMariaContext> options)
            : base(options)
        {
        }

        public DbSet<DaibucatAntonia_CherechesIlincaMaria.Models.User> User { get; set; } = default!;
        public DbSet<DaibucatAntonia_CherechesIlincaMaria.Models.Abonament> Abonament { get; set; } = default!;
        public DbSet<DaibucatAntonia_CherechesIlincaMaria.Models.AbonamentClient> AbonamentClient { get; set; } = default!;
        public DbSet<DaibucatAntonia_CherechesIlincaMaria.Models.Plata> Plata { get; set; } = default!;
        public DbSet<DaibucatAntonia_CherechesIlincaMaria.Models.ClasaFitness> ClasaFitness { get; set; } = default!;
    }
}
