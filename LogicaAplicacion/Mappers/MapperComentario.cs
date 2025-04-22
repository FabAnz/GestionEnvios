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
        internal static Comentario ToComentario(ComentarioDTO dto)
        {
            Comentario aRetornar = new Comentario();

            aRetornar.Id = dto.Id;
            aRetornar.Texto = dto.Texto;
            if (dto.Fecha != default(DateTime))
                aRetornar.Fecha = dto.Fecha;
            aRetornar.Usuario = MapperUsuario.ToUsuario(dto.Usuario);

            return aRetornar;
        }

        internal static ComentarioDTO ToDTO(Comentario comentario)
        {
            ComentarioDTO aRetornar = new ComentarioDTO();

            aRetornar.Id = comentario.Id;
            aRetornar.Texto = comentario.Texto;
            aRetornar.Fecha = comentario.Fecha;
            aRetornar.Usuario = MapperUsuario.ToDTO(comentario.Usuario);

            return aRetornar;
        }

        internal static List<ComentarioDTO> ToListDTO(List<Comentario> lista)
        {
            List<ComentarioDTO> aRetornar = new List<ComentarioDTO>();

            foreach (Comentario comentario in lista)
            {
                aRetornar.Add(ToDTO(comentario));
            }

            return aRetornar;
        }

        internal static List<Comentario> ToListComentario(List<ComentarioDTO> lista)
        {
            List<Comentario> aRetornar = new List<Comentario>();

            foreach (ComentarioDTO comentario in lista)
            {
                aRetornar.Add(ToComentario(comentario));
            }

            return aRetornar;
        }
    }
}
