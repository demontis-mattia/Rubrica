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
    public class DetailsModel : PageModel
    {
        private readonly RubricaDbContext _context;

        public DetailsModel(RubricaDbContext context)
        {
            _context = context;
        }

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
    }
}
