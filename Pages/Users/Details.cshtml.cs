using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DaibucatAntonia_CherechesIlincaMaria.Data;
using DaibucatAntonia_CherechesIlincaMaria.Models;

namespace DaibucatAntonia_CherechesIlincaMaria.Pages.Users
{
    public class DetailsModel : PageModel
    {
        private readonly DaibucatAntonia_CherechesIlincaMaria.Data.DaibucatAntonia_CherechesIlincaMariaContext _context;

        public DetailsModel(DaibucatAntonia_CherechesIlincaMaria.Data.DaibucatAntonia_CherechesIlincaMariaContext context)
        {
            _context = context;
        }

        public User User { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _context.User
               .Include(u => u.AbonamenteClient)
               .ThenInclude(ac => ac.Abonament)
               .FirstOrDefaultAsync(m => m.UserId == id);
           
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                User = user;
            }
            return Page();
        }
    }
}
