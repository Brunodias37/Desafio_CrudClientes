using CrudClientes.Context;
using CrudClientes.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CrudClientes.Repositories
{
    public class ItensNotaFiscalRepository : IItensNotaFiscalRepository
    {
        private readonly CrudClienteContext _context;

        public ItensNotaFiscalRepository(CrudClienteContext context)
        {
            _context = context;
        }

       
        public List<ItensNotaFiscal> GetItensNotasFiscais()
        {
            return _context.ItensNotaFiscal.Include(c => c.Produto).OrderBy(c => c.Id).ToList();

        }

        public ItensNotaFiscal GetItemNotaFiscal(int id)
        {
            return _context.ItensNotaFiscal.Include(c => c.Produto).FirstOrDefault(c => c.Id == id);

        }

        public void Create(ItensNotaFiscal ItensnotaFiscal)
        {
            //var aux = _context.NotaFiscal.FirstOrDefault(c => c.Id == notaFiscal.Cliente.Id);
               
            
            _context.ItensNotaFiscal.Add(ItensnotaFiscal);
            _context.SaveChanges();
        }

        public void Edit(ItensNotaFiscal notaFiscal, int id)
        {
            var itensNotaFiscalInDb = _context.ItensNotaFiscal.FirstOrDefault(c => c.Id == id);

            //itensNotaFiscalInDb.NotaFiscalId = notaFiscal.NotaFiscalId;
            //itensNotaFiscalInDb.ProdutoId = notaFiscal.ProdutoId;
            itensNotaFiscalInDb.Quantidade = notaFiscal.Quantidade;
            itensNotaFiscalInDb.PrecoUnitario = notaFiscal.PrecoUnitario;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var itensNotaFiscal = _context.ItensNotaFiscal.FirstOrDefault(x => x.Id == id);
            _context.ItensNotaFiscal.Remove(itensNotaFiscal);
            _context.SaveChanges();

        }
        public int QuantidadeUniVendidasCif()
        {
            return _context.ItensNotaFiscal.Where(c => c.NotaFiscal.TipoDeFrete == "CIF").Count();
        }

        public decimal ValorTotalTipoFob()
        {
            return _context.ItensNotaFiscal.Where(c => c.NotaFiscal.TipoDeFrete == "FOB").Sum(c => c.PrecoUnitario * c.Quantidade);
        }

        public int QuantidadeVendidasMouse()
        {
            return _context.ItensNotaFiscal.Where(c => c.Produto.NomeProduto == "MOUSE").Count();
        }
        public decimal QuantidadeVendidasMouseTeclado()
        {
            return _context.ItensNotaFiscal.Where(c => c.Produto.NomeProduto.Contains("Mouse") || c.Produto.NomeProduto.Contains("TECLADO")).Sum(c => c.PrecoUnitario * c.Quantidade);
        }
    }
}
