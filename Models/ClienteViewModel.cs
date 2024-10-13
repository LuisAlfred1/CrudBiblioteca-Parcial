using System.ComponentModel.DataAnnotations;

namespace CrudBiblioteca.Models
{
    public class ClienteViewModel
    {
        [Key]
        public int ClienteId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres"),]
        public string Nombre { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Correo electronico inválido")]
        public string CorreoElectronico { get; set; }

        [Required]
        [StringLength(8, ErrorMessage = "El telefono debe tener 8 digitos")]
        public string Telefono { get; set; }
    }
}
