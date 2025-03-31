using CasosUso.DTOs;
using LogicaNegocio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Mappers
{
    internal class MapperEnvioComun
    {
        internal static Comun ToUsuario(EnvioComunDTO dto)
        {
            Comun aRetornar = new Comun();

            return aRetornar;
        }

        internal static EnvioComunDTO ToDTO(Comun envio)
        {
            EnvioComunDTO aRetornar = new EnvioComunDTO();

            return aRetornar;
        }

        internal static List<EnvioComunDTO> ToListDTO(List<Comun> lista)
        {
            List<EnvioComunDTO> aRetornar = new List<EnvioComunDTO>();

            return aRetornar;
        }
    }
}
