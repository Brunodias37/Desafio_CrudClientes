using CrudClientes.Models;
using System.Collections.Generic;

namespace CrudClientes.Repositories
{
    public interface IClienteRepository
    {
        List<Cliente> GetClientes();

        Cliente GetCliente(int id);
        void Delete(int id);
        void Create(Cliente cliente);
        void Edit(Cliente cliente, int id);
    }
}
