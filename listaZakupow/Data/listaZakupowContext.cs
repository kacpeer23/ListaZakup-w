using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using listaZakupow.Models;

namespace listaZakupow.Data
{
    public class listaZakupowContext : DbContext
    {
        public listaZakupowContext (DbContextOptions<listaZakupowContext> options)
            : base(options)
        {
        }
        
        public DbSet<listaZakupow.Models.Produkt> Produkt { get; set; } = default!;
    }
}
