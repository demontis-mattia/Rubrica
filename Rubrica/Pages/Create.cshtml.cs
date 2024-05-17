using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rubrica.Models;

namespace Rubrica.Pages
{
    public class CreateModel : PageModel
    {
        private readonly Rubrica.Models.RubricaDbContext _context;

        public CreateModel(Rubrica.Models.RubricaDbContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            Citta = await _context.Città.ToListAsync();
        }

        [BindProperty]
        public Contatto Contatto { get; set; } = default!;
        public IList<Città> Citta {  get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Contatti.Add(Contatto);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
