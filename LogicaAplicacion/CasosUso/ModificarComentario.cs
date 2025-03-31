using CasosUso.DTOs;
using CasosUso.InterfacesCasosUso;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class ModificarComentario : IModificarComentario
    {
        public IRepositorioComentario RepoComentario { get; set; }

        public ModificarComentario(IRepositorioComentario repo)
        {
            RepoComentario = repo;
        }

        public void Modificar(ComentarioDTO comentario)
        {
            throw new NotImplementedException();
        }
    }
}
