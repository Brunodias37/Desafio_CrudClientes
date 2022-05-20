using CrudClientes.Models;
using System.Collections.Generic;

namespace CrudClientes.Repositories
{
    public interface IItensNotaFiscalRepository
    {
        List<ItensNotaFiscal> GetItensNotasFiscais();

        ItensNotaFiscal GetItemNotaFiscal(int id);
        void Delete(int id);
        void Create(ItensNotaFiscal itensNotaFiscal);
        void Edit(ItensNotaFiscal itensNotaFiscal, int id);

         int QuantidadeUniVendidasCif();
        decimal ValorTotalTipoFob();
        int QuantidadeVendidasMouse();

        decimal QuantidadeVendidasMouseTeclado();

    }
}
