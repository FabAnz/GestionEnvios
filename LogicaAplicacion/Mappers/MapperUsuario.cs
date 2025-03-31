using CasosUso.DTOs;
using LogicaNegocio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Mappers
{
    internal class MapperUsuario
    {
        internal static Usuario ToUsuario(UsuarioDTO dto)
        {
            Usuario aRetornar = new Usuario();

            return aRetornar;
        }

        internal static UsuarioDTO ToDTO(Usuario usuario)
        {
            UsuarioDTO aRetornar = new UsuarioDTO();

            return aRetornar;
        }

        internal static List<UsuarioDTO> ToListDTO(List<Usuario> lista)
        {
            List<UsuarioDTO> aRetornar= new List<UsuarioDTO>();

            return aRetornar;
        }
    }
}
