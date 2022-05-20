using CrudClientes.Models;
using System.Collections.Generic;

namespace CrudClientes.Repositories
{
    public interface INotaFiscalRepository
    {
        List<NotaFiscal> GetNotasFiscais();

        NotaFiscal GetNotaFiscal(int id);
        void Delete(int id);
        void Create(NotaFiscal notaFiscal);
        void Edit(NotaFiscal notaFiscal, int id);
        int QuantidadeNfEmitidas();
        string DataHoraPrimeiraNf();
    }
}
