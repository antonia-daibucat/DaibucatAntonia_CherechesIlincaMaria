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
    public class DeleteModel : PageModel
    {
        private readonly DaibucatAntonia_CherechesIlincaMaria.Data.DaibucatAntonia_CherechesIlincaMariaContext _context;

        public DeleteModel(DaibucatAntonia_CherechesIlincaMaria.Data.DaibucatAntonia_CherechesIlincaMariaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AbonamentClient AbonamentClient { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var abonamentclient = await _context.AbonamentClient.FirstOrDefaultAsync(m => m.AbonamentClientId == id);

            if (abonamentclient == null)
            {
                return NotFound();
            }
            else
            {
                AbonamentClient = abonamentclient;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var abonamentclient = await _context.AbonamentClient.FindAsync(id);
            if (abonamentclient != null)
            {
                AbonamentClient = abonamentclient;
                _context.AbonamentClient.Remove(AbonamentClient);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
