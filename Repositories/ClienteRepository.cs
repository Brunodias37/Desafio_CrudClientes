using CrudClientes.Context;
using CrudClientes.Models;
using System.Collections.Generic;
using System.Linq;

namespace CrudClientes.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly CrudClienteContext _context;

        public ClienteRepository(CrudClienteContext context)
        {
            _context = context;
        }

       
        public List<Cliente> GetClientes()
        {
            return _context.Cliente.OrderBy(c => c.Nome).ToList();
        }

        public Cliente GetCliente(int id)
        {
            return _context.Cliente.FirstOrDefault(c => c.Id == id);
        }

        public void Create(Cliente cliente)
        {
            _context.Cliente.Add(cliente);
            _context.SaveChanges();
        }

        public void Edit(Cliente cliente, int id)
        {
            var clienteInDb = _context.Cliente.FirstOrDefault(c => c.Id == id);

            clienteInDb.Nome = cliente.Nome;
            clienteInDb.Cpf = cliente.Cpf;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var cliente = _context.Cliente.FirstOrDefault(x => x.Id == id);
            _context.Cliente.Remove(cliente);
            
            _context.SaveChanges();

        }



    }
}
