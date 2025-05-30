using CasosUso.DTOs;
using CasosUso.InterfacesCasosUso;
using LogicaAplicacion.Mappers;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class AltaComentario : IAltaComentario
    {
        public IRepositorioComentario RepoComentario { get; set; }

        public AltaComentario(IRepositorioComentario repo)
        {
            RepoComentario = repo;
        }

        public void Comentar(ComentarioDTO comentario, int idEnvio)
        {
            RepoComentario.Agregar(MapperComentario.ToComentario(comentario), idEnvio);
        }
    }
}
