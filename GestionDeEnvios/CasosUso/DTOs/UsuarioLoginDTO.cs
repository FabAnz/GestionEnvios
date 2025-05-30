using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosUso.DTOs
{
    public class UsuarioLoginDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese un email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Ingrese una contraseña")]
        public string? Contrasenia { get; set; }
        public string? Rol { get; set; }
    }
}
