using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using listaZakupow.Data;
using listaZakupow.Models;

namespace listaZakupow.Pages.Produkty
{
    public class DeleteModel : PageModel
    {
        private readonly listaZakupow.Data.listaZakupowContext _context;

        public DeleteModel(listaZakupow.Data.listaZakupowContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Produkt Produkt { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Produkt == null)
            {
                return NotFound();
            }

            var produkt = await _context.Produkt.FirstOrDefaultAsync(m => m.Id == id);

            if (produkt == null)
            {
                return NotFound();
            }
            else 
            {
                Produkt = produkt;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Produkt == null)
            {
                return NotFound();
            }
            var produkt = await _context.Produkt.FindAsync(id);

            if (produkt != null)
            {
                Produkt = produkt;
                _context.Produkt.Remove(Produkt);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
