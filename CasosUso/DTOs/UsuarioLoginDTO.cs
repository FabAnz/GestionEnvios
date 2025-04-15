using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosUso.DTOs
{
    public class UsuarioLoginDTO
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Contrasenia { get; set; }
        public string? Rol { get; set; }
    }
}
