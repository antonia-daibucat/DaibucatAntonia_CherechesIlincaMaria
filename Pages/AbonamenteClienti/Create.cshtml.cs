using DaibucatAntonia_CherechesIlincaMaria.Data;
using DaibucatAntonia_CherechesIlincaMaria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            var users = _context.User.Select(u => new {
                u.UserId,
                FullName = u.Nume + " " + u.Prenume + " (" + u.Email + ")"
            });
            ViewData["UserId"] = new SelectList(users, "UserId", "FullName");

         
            ViewData["AbonamentId"] = new SelectList(_context.Abonament, "AbonamentId", "NumeAbonament");
            return Page();
        }

        [BindProperty]
        public AbonamentClient AbonamentClient { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string ClientEmail)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.Email == ClientEmail);
            if (user == null)
            {
                ModelState.AddModelError("", "Clientul cu acest email nu există.");
                return Page();
            }
            AbonamentClient.UserId = user.UserId;
            ModelState.Remove("AbonamentClient.User");
            ModelState.Remove("AbonamentClient.Abonament");
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
