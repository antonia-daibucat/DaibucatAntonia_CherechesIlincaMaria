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
        [BindProperty]
        public string MetodaPlataSelectata { get; set; }

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string ClientEmail)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.Email == ClientEmail);
            if (user == null)
            {
                ModelState.AddModelError("", "Clientul cu acest email nu există.");
                return Page();
            }

            // Setăm FK-ul corect
            AbonamentClient.UserId = user.UserId;

            // Bypass validare pentru proprietățile de navigare
            ModelState.Remove("AbonamentClient.User");
            ModelState.Remove("AbonamentClient.Abonament");

            if (!ModelState.IsValid)
            {
                // Dacă validarea eșuează din alte motive (ex: DataSfarsit lipsă), se reafișează pagina.
                return Page();
            }

            // 1. Găsește tipul de Abonament pentru a obține prețul
            var abonamentTip = await _context.Abonament
                .FirstOrDefaultAsync(a => a.AbonamentId == AbonamentClient.AbonamentId);

            if (abonamentTip == null)
            {
                // Aceasta nu ar trebui să se întâmple, dar e bine să ne protejăm
                ModelState.AddModelError("", "Tipul de abonament selectat nu este valid.");
                return Page();
            }

            // 2. Adaugă noul AbonamentClient la context
            _context.AbonamentClient.Add(AbonamentClient);

            // 3. Crearea și Adăugarea Obiectului Plata
            var plataNoua = new Plata
            {
                // Leagă plata de noul AbonamentClient
                AbonamentClient = AbonamentClient,

                Suma = abonamentTip.Pret,
                DataPlata = DateTime.Now,

                // 👈 MODIFICAREA CHEIE: Folosește valoarea din dropdown
                MetodaPlata = MetodaPlataSelectata
            };

            _context.Plata.Add(plataNoua);

            // 4. Salvează ambele obiecte (AbonamentClient și Plata) în baza de date
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
