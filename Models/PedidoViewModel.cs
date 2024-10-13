using System.ComponentModel.DataAnnotations;

namespace CrudBiblioteca.Models
{
    public class PedidoViewModel
    {
        [Key]
        public int PedidoId { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
