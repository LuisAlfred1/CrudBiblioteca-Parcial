using System.ComponentModel.DataAnnotations;

namespace CrudBiblioteca.Models
{
    public class ProductoViewModel
    {
        [Key]
        public int ProductoId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
        public string Nombre { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "El precio deber ser positivo")]
        public decimal Precio { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "La cantidad no puede ser negativa")]
        public int Cantidad { get; set; }
    }
}
