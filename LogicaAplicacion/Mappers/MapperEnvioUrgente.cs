using CasosUso.DTOs;
using LogicaNegocio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Mappers
{
    internal class MapperEnvioUrgente
    {
        internal static Urgente ToUsuario(EnvioUrgenteDTO dto)
        {
            Urgente aRetornar = new Urgente();

            return aRetornar;
        }

        internal static EnvioUrgenteDTO ToDTO(Urgente envio)
        {
            EnvioUrgenteDTO aRetornar = new EnvioUrgenteDTO();

            return aRetornar;
        }

        internal static List<EnvioUrgenteDTO> ToListDTO(List<Urgente> lista)
        {
            List<EnvioUrgenteDTO> aRetornar = new List<EnvioUrgenteDTO>();

            return aRetornar;
        }
    }
}
