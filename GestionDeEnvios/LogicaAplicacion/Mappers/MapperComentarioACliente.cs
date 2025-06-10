using CasosUso.DTOs;
using LogicaNegocio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Mappers
{
    internal class MapperComentarioACliente
    {

        internal static ComentarioAClienteDTO ToDTO(Comentario comentario)
        {
            ComentarioAClienteDTO aRetornar = new ComentarioAClienteDTO();

            aRetornar.Texto = comentario.Texto;
            aRetornar.Fecha = comentario.Fecha;

            return aRetornar;
        }

        internal static List<ComentarioAClienteDTO> ToListDTO(List<Comentario> lista)
        {
            List<ComentarioAClienteDTO> aRetornar = lista.Select(c => ToDTO(c)).ToList();

            return aRetornar;
        }
    }
}
