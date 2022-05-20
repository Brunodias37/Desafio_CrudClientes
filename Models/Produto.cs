using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CrudClientes.Models
{
    public class Produto
    {

        public int Id { get; set; } 

        [StringLength(100)]
        public string NomeProduto { get; set; }





    }
}
