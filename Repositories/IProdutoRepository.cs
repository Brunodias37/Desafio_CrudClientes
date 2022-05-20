using CrudClientes.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudClientes.Repositories
{
    public interface IProdutoRepository
    {
        Task<List<Produto>> GetProdutos();

        Produto GetProduto(int id);
        void Delete(int id);
        void Create(Produto produto);
        void Edit(Produto produto, int id);
    }
}
