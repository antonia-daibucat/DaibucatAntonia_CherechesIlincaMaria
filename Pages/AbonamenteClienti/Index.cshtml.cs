using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DaibucatAntonia_CherechesIlincaMaria.Data;
using DaibucatAntonia_CherechesIlincaMaria.Models;

namespace DaibucatAntonia_CherechesIlincaMaria.Pages.AbonamenteClienti
{
    public class IndexModel : PageModel
    {
        private readonly DaibucatAntonia_CherechesIlincaMaria.Data.DaibucatAntonia_CherechesIlincaMariaContext _context;

        public IndexModel(DaibucatAntonia_CherechesIlincaMaria.Data.DaibucatAntonia_CherechesIlincaMariaContext context)
        {
            _context = context;
        }

        public IList<AbonamentClient> AbonamentClient { get;set; } = default!;

        public async Task OnGetAsync()
        {
            AbonamentClient = await _context.AbonamentClient
                .Include(a => a.Abonament)
                .Include(a => a.User).ToListAsync();
        }
    }
}
