using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CrudClientes.Models
{
    public class ItensNotaFiscal
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }

        [DisplayFormat(DataFormatString = "{0:f2}")]
        public decimal PrecoUnitario { get; set; }


        public int NotaFiscalId { get; set; }
        public NotaFiscal NotaFiscal { get; set; }

        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }


    }
}
