using DaibucatAntonia_CherechesIlincaMaria.Data;
using DaibucatAntonia_CherechesIlincaMaria.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaibucatAntonia_CherechesIlincaMaria.Pages.Plati
{
    
    public class IndexModel : PageModel
    {
        private readonly DaibucatAntonia_CherechesIlincaMaria.Data.DaibucatAntonia_CherechesIlincaMariaContext _context;

        public IndexModel(DaibucatAntonia_CherechesIlincaMaria.Data.DaibucatAntonia_CherechesIlincaMariaContext context)
        {
            _context = context;
        }

        public IList<Plata> Plata { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Plata = await _context.Plata
                    .Include(p => p.AbonamentClient)
                    .ThenInclude(ac => ac.User)
                    .Include(p => p.AbonamentClient) 
                    .ThenInclude(ac => ac.Abonament)
                    .ToListAsync();
        }
    }
}
