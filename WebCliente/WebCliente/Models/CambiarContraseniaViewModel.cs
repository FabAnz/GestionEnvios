using System.ComponentModel.DataAnnotations;
using WebCliente.DTOs;

namespace WebCliente.Models
{
    public class CambiarContraseniaViewModel
    {
        [Required(ErrorMessage = "Ingrese la contraseña actual")]
        public string Actual { get; set; }

        [Required(ErrorMessage = "Ingrese la contraseña nueva")]
        public string Nueva { get; set; }
    }
}
