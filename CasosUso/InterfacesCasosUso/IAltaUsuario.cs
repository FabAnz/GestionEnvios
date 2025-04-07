using CasosUso.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosUso.InterfacesCasosUso
{
    public interface IAltaUsuario : IRegistroAuditable
    {
        public void EjecutarAlta(UsuarioDTO dto, int idUsuarioActivo);
    }
}
