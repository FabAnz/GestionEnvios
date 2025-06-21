using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosUso.DTOs
{
    public class LoginResponseDTO
    {
        public string Email { get; set; }
        public string Rol { get; set; }
        public string Token { get; set; }
    }
}
