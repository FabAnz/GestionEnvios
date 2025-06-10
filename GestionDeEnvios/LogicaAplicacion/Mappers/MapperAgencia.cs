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
    internal class MapperAgencia
    {
        internal static Agencia ToAgencia(AgenciaDTO dto)
        {
            Agencia aRetornar = new Agencia();

            aRetornar.Id = dto.Id;
            aRetornar.Nombre = dto.Nombre;
            aRetornar.Direccion = dto.Direccion;
            aRetornar.Coordenadas = new Coordenadas(dto.Latitud, dto.Longitud);

            return aRetornar;
        }

        internal static AgenciaDTO ToDTO(Agencia agencia)
        {
            AgenciaDTO aRetornar = new AgenciaDTO();

            aRetornar.Id = agencia.Id;
            aRetornar.Nombre = agencia.Nombre;
            aRetornar.Direccion = agencia.Direccion;
            aRetornar.Latitud = agencia.Coordenadas.Latitud;
            aRetornar.Longitud = agencia.Coordenadas.Longitud;

            return aRetornar;
        }

        internal static List<AgenciaDTO> ToListDTO(List<Agencia> lista)
        {
            List<AgenciaDTO> aRetornar = new List<AgenciaDTO>();

            foreach (Agencia agencia in lista)
            {
                aRetornar.Add(ToDTO(agencia));
            }

            return aRetornar;
        }
    }
}
