using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace CrudClientes.Models
{
    public class NotaFiscal
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataEmissao  { get; set; }
        

        public String TipoDeFrete { get; set; }


        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        


    }
}
