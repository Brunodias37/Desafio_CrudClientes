using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudClientes.ViewModels
{
    public class RespostaViewModel
    {
        public int QuantidadeNfEmitidas { get; set; }
        public  string DataHoraPrimeiraNf { get; set; }
        public int QuantidadeUniVendidasCif { get; set; }
        public decimal ValorTotalTipoFob { get; set; }
        public int QuantidadeVendidasMouse { get; set; }
        public decimal QuantidadeVendidasMouseTeclado { get; set; }

    }
}
