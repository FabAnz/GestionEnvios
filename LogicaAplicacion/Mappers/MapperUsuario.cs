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
    internal class MapperUsuario
    {
        internal static Usuario ToUsuario(UsuarioDTO dto)
        {
            Usuario aRetornar = new Usuario()
            {
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Direccion = dto.Direccion,
                Telefono = dto.Telefono,
                Email = new Email(dto.Email),
                Contrasenia = new Contrasenia(dto.Contrasenia),
                Rol = MapperRol.ToRol(dto.Rol)
            };

            return aRetornar;
        }

        internal static UsuarioDTO ToDTO(Usuario usuario)
        {
            UsuarioDTO aRetornar = new UsuarioDTO()
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Direccion = usuario.Direccion,
                Telefono = usuario.Telefono,
                Email = usuario.Email.Valor,
                Rol = MapperRol.ToDTO(usuario.Rol)
            };

            return aRetornar;
        }

        internal static List<UsuarioDTO> ToListDTO(List<Usuario> lista)
        {
            List<UsuarioDTO> aRetornar = new List<UsuarioDTO>();

            foreach (Usuario usuario in lista)
            {
                aRetornar.Add(ToDTO(usuario));
            }
            return aRetornar;
        }
    }
}
