using CasosUso.DTOs;

namespace Presentacion.Models
{
    public class UsuarioRolesViewModel
    {
        public UsuarioDTO Usuario { get; set; }
        public List<RolDTO> Roles { get; set; }
    }
}
