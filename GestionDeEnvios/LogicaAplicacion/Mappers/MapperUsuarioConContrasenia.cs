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
    internal class MapperUsuarioConContrasenia
    {
        internal static Usuario ToUsuario(UsuarioConContraseniaDTO dto)
        {
            Usuario aRetornar = new Usuario()
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Direccion = dto.Direccion,
                Telefono = dto.Telefono,
                Email = new Email(dto.Email),
                Contrasenia = new Contrasenia(dto.Contrasenia),
                Rol = new Rol() { Id = dto.Rol.Id }
            };

            return aRetornar;
        }

        internal static UsuarioConContraseniaDTO ToDTO(Usuario usuario)
        {
            UsuarioConContraseniaDTO aRetornar = new UsuarioConContraseniaDTO()
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Direccion = usuario.Direccion,
                Telefono = usuario.Telefono,
                Email = usuario.Email.Valor,
                Contrasenia=usuario.Contrasenia.Valor,
                Rol = MapperRol.ToDTO(usuario.Rol)
            };

            return aRetornar;
        }

        internal static List<UsuarioConContraseniaDTO> ToListDTO(List<Usuario> lista)
        {
            List<UsuarioConContraseniaDTO> aRetornar = new List<UsuarioConContraseniaDTO>();

            foreach (Usuario usuario in lista)
            {
                aRetornar.Add(ToDTO(usuario));
            }
            return aRetornar;
        }
    }
}
