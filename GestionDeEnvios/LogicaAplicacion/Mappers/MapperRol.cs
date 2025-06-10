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
    internal class MapperRol
    {
        internal static Rol ToRol(RolDTO dto)
        {
            Rol aRetornar = new Rol()
            {
                Id = dto.Id,
                Nombre = dto.Nombre
            };

            return aRetornar;
        }

        internal static RolDTO ToDTO(Rol rol)
        {
            RolDTO aRetornar = new RolDTO()
            {
                Id = rol.Id,
                Nombre = rol.Nombre
            };

            return aRetornar;
        }

        internal static List<RolDTO> ToListDTO(List<Rol> lista)
        {
            List<RolDTO> aRetornar = new List<RolDTO>();

            foreach (Rol rol in lista)
            {
                aRetornar.Add(ToDTO(rol));
            }

            return aRetornar;
        }
    }
}
