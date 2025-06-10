using CasosUso.InterfacesCasosUso;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosUso.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese un nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Ingrese un apellido")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Ingrese una dirección")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Ingrese un teléfono")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Ingrese un correo")]
        public string Email { get; set; }

        public RolDTO Rol { get; set; }
    }
}
