using CasosUso.DTOs;
using LogicaNegocio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Mappers
{
    internal class MapperComentario
    {
        internal static Comentario ToUsuario(ComentarioDTO dto)
        {
            Comentario aRetornar = new Comentario();

            return aRetornar;
        }

        internal static ComentarioDTO ToDTO(Comentario envio)
        {
            ComentarioDTO aRetornar = new ComentarioDTO();

            return aRetornar;
        }

        internal static List<ComentarioDTO> ToListDTO(List<Comentario> lista)
        {
            List<ComentarioDTO> aRetornar = new List<ComentarioDTO>();

            return aRetornar;
        }
    }
}
