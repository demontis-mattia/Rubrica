using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Rubrica.Models;

namespace Rubrica.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly Rubrica.Models.RubricaDbContext _context;

        public DeleteModel(Rubrica.Models.RubricaDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Contatto Contatto { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contatto = await _context.Contatti.FirstOrDefaultAsync(m => m.Id == id);

            if (contatto == null)
            {
                return NotFound();
            }
            else
            {
                Contatto = contatto;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contatto = await _context.Contatti.FindAsync(id);
            if (contatto != null)
            {
                Contatto = contatto;
                _context.Contatti.Remove(Contatto);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
