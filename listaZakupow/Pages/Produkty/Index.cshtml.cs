using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using listaZakupow.Data;
using listaZakupow.Models;

namespace listaZakupow.Pages.Produkty
{
    public class IndexModel : PageModel
    {
        private readonly listaZakupow.Data.listaZakupowContext _context;

        public IndexModel(listaZakupow.Data.listaZakupowContext context)
        {
            _context = context;
        }

        public IList<Produkt> Produkt { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? MovieGenre { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Produkt
                                            orderby m.Rodzaj
                                            select m.Rodzaj;

            var movies = from m in _context.Produkt
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Opis.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(x => x.Rodzaj == MovieGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Produkt = await movies.ToListAsync();
        }
    }
}
