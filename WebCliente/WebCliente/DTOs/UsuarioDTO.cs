using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebCliente.DTOs
{
    public class UsuarioDTO
    {
        [Required(ErrorMessage = "Ingrese el email")]
        public string Email { get; set; }

        [DisplayName("Contraseña")]
        [Required(ErrorMessage = "Ingrese la contraseña")]
        public string Contrasenia { get; set; }
    }
}
