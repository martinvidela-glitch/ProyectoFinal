using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProyectoFinal.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProyectoFinal.EntityFramework
{
    public class CodeFirstDbContext : DbContext
    {
        public DbSet<Cliente> Clientes {  get; set; }

        public DbSet<Factura> Facturas { get; set; }

        public DbSet<Item> Items { get; set; }

        public CodeFirstDbContext()
        {
            
        }
        public CodeFirstDbContext(DbContextOptions<CodeFirstDbContext> options ) : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = BaseParcial3; Integrated Security = True;");
        }
    }
}
