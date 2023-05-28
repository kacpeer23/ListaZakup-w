using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using listaZakupow.Data;
using listaZakupow.Models;

namespace listaZakupow.Pages.Produkty
{
    public class CreateModel : PageModel
    {
        private readonly listaZakupow.Data.listaZakupowContext _context;

        public CreateModel(listaZakupow.Data.listaZakupowContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Produkt Produkt { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Produkt == null || Produkt == null)
            {
                return Page();
            }

            _context.Produkt.Add(Produkt);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
