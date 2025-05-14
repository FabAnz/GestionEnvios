using CasosUso.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Presentacion.Models
{
    public class UsuarioRolesViewModel
    {
        public UsuarioConContraseniaDTO Usuario { get; set; }

        [Required(ErrorMessage = "Seleccione un rol")]
        public int RolId { get; set; }
        public List<RolDTO> Roles { get; set; }
    }
}
