using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DaibucatAntonia_CherechesIlincaMaria.Data;
using DaibucatAntonia_CherechesIlincaMaria.Models;

namespace DaibucatAntonia_CherechesIlincaMaria.Pages.AbonamenteClienti
{
    public class EditModel : PageModel
    {
        private readonly DaibucatAntonia_CherechesIlincaMaria.Data.DaibucatAntonia_CherechesIlincaMariaContext _context;

        public EditModel(DaibucatAntonia_CherechesIlincaMaria.Data.DaibucatAntonia_CherechesIlincaMariaContext context)
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

            var abonamentclient =  await _context.AbonamentClient.FirstOrDefaultAsync(m => m.AbonamentClientId == id);
            if (abonamentclient == null)
            {
                return NotFound();
            }
            AbonamentClient = abonamentclient;
            var users = _context.User.Select(u => new {
                u.UserId,
                FullName = u.Nume + " " + u.Prenume + " (" + u.Email + ")"
            });
            ViewData["AbonamentId"] = new SelectList(_context.Abonament, "AbonamentId", "NumeAbonament");
           ViewData["UserId"] = new SelectList(_context.User, "UserId", "Email");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("AbonamentClient.User");
            ModelState.Remove("AbonamentClient.Abonament");
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(AbonamentClient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AbonamentClientExists(AbonamentClient.AbonamentClientId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AbonamentClientExists(int id)
        {
            return _context.AbonamentClient.Any(e => e.AbonamentClientId == id);
        }
    }
}
