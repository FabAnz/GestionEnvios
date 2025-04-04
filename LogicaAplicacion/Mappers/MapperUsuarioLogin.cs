using CasosUso.DTOs;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Mappers
{
    internal class MapperUsuarioLogin
    {
        internal static Usuario ToUsuario(UsuarioLoginDTO dto)
        {
            Usuario aRetornar = new Usuario()
            {
                Email = new Email(dto.Email),
                Contrasenia = new Contrasenia(dto.Contrasenia)
            };

            return aRetornar;
        }

        internal static UsuarioLoginDTO ToDTO(Usuario usuario)
        {
            UsuarioLoginDTO aRetornar = new UsuarioLoginDTO()
            {
                Id = usuario.Id,
                RolId = usuario.Rol.Id
            };

            return aRetornar;
        }
    }
}
