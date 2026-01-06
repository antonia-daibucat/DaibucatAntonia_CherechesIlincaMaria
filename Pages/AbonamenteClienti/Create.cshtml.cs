using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DaibucatAntonia_CherechesIlincaMaria.Data;
using DaibucatAntonia_CherechesIlincaMaria.Models;

namespace DaibucatAntonia_CherechesIlincaMaria.Pages.AbonamenteClienti
{
    public class CreateModel : PageModel
    {
        private readonly DaibucatAntonia_CherechesIlincaMaria.Data.DaibucatAntonia_CherechesIlincaMariaContext _context;

        public CreateModel(DaibucatAntonia_CherechesIlincaMaria.Data.DaibucatAntonia_CherechesIlincaMariaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AbonamentId"] = new SelectList(_context.Abonament, "AbonamentId", "AbonamentId");
        ViewData["UserId"] = new SelectList(_context.User, "UserId", "Email");
            return Page();
        }

        [BindProperty]
        public AbonamentClient AbonamentClient { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.AbonamentClient.Add(AbonamentClient);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
