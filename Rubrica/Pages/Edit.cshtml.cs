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
    public class EditModel : PageModel
    {
        private readonly Rubrica.Models.RubricaDbContext _context;

        public EditModel(Rubrica.Models.RubricaDbContext context)
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

            var contatto =  await _context.Contatti.FirstOrDefaultAsync(m => m.Id == id);
            if (contatto == null)
            {
                return NotFound();
            }
            Contatto = contatto;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Contatto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContattoExists(Contatto.Id))
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

        private bool ContattoExists(int id)
        {
            return _context.Contatti.Any(e => e.Id == id);
        }
    }
}
