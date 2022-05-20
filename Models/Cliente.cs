using System.ComponentModel.DataAnnotations;

namespace CrudClientes.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        public string Cpf { get; set; }


    }
}
