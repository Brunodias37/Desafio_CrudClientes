using CrudClientes.Context;
using CrudClientes.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudClientes.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly CrudClienteContext _context;

        public ProdutoRepository(CrudClienteContext context)
        {
            _context = context;
        }

       
        public async Task<List<Produto>> GetProdutos()
        {
            return  await _context.Produto.OrderBy(c => c.NomeProduto).ToListAsync();
        }

        public Produto GetProduto(int id)
        {
            return _context.Produto.FirstOrDefault(c => c.Id == id);
        }

        public void Create(Produto produto)
        {
            _context.Produto.Add(produto);
            _context.SaveChanges();
        }

        public void Edit(Produto produto, int id)
        {

            var produtoInDb = _context.Produto.FirstOrDefault(c => c.Id == id);

            produtoInDb.NomeProduto = produto.NomeProduto;
            
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var produto = _context.Produto.FirstOrDefault(x => x.Id == id);
            _context.Produto.Remove(produto);
            _context.SaveChanges();

        }

        
    }
}
