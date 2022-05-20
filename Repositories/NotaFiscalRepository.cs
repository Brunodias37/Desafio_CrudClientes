using CrudClientes.Context;
using CrudClientes.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Globalization;

namespace CrudClientes.Repositories
{
    public class NotaFiscalRepository : INotaFiscalRepository
    {
        private readonly CrudClienteContext _context;

        public NotaFiscalRepository(CrudClienteContext context)
        {
            _context = context;
        }


        public List<NotaFiscal> GetNotasFiscais()
        {
            return _context.NotaFiscal.Include(c => c.Cliente).OrderBy(c => c.Id).ToList();
            //return _context.NotaFiscal.OrderBy(c => c.Id).ToList();
        }

        public NotaFiscal GetNotaFiscal(int id)
        {
            //return _context.NotaFiscal.FirstOrDefault(c => c.Id == id);
            return _context.NotaFiscal.Include(c => c.Cliente).FirstOrDefault(c => c.Id == id);

        }

        public void Create(NotaFiscal notaFiscal)
        {
            //var aux = _context.NotaFiscal.FirstOrDefault(c => c.Id == notaFiscal.Cliente.Id);


            _context.NotaFiscal.Add(notaFiscal);
            _context.SaveChanges();
        }

        public void Edit(NotaFiscal notaFiscal, int id)
        {
            var clienteInDb = _context.NotaFiscal.FirstOrDefault(c => c.Id == id);

            clienteInDb.ClienteId = notaFiscal.ClienteId;
            clienteInDb.DataEmissao = notaFiscal.DataEmissao;
            clienteInDb.TipoDeFrete = notaFiscal.TipoDeFrete;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var notaFiscal = _context.NotaFiscal.FirstOrDefault(x => x.Id == id);
            _context.NotaFiscal.Remove(notaFiscal);
            _context.SaveChanges();

        }

        public int QuantidadeNfEmitidas()
        {
            return _context.NotaFiscal.Count();
        }

        public string DataHoraPrimeiraNf()
        {
            return _context.NotaFiscal.OrderBy(d => d.DataEmissao).FirstOrDefault().DataEmissao.ToString("dd-MM-yyyy");

        }






    }
}
