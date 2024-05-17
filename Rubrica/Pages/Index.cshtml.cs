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
    public class IndexModel : PageModel
    {
        private readonly RubricaDbContext _context;

        public IndexModel(RubricaDbContext context)
        {
            _context = context;
        }

        public IList<Contatto> Contatti { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Contatti = await _context.Contatti.ToListAsync();
        }
    }
}
