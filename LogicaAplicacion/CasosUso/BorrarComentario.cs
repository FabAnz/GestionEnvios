using CasosUso.InterfacesCasosUso;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class BorrarComentario : IBorrarComentario
    {
        public IRepositorioComentario RepoComentario { get; set; }

        public BorrarComentario(IRepositorioComentario repo)
        {
            RepoComentario = repo;
        }

        public void Borrar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
