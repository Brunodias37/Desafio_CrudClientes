using CrudClientes.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudClientes.Context
{
    public class CrudClienteContext : DbContext
    {
        //Tables
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<NotaFiscal> NotaFiscal { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<ItensNotaFiscal> ItensNotaFiscal { get; set; }


        public CrudClienteContext(DbContextOptions<CrudClienteContext> options) : base(options)
        {

        }







    }
}
