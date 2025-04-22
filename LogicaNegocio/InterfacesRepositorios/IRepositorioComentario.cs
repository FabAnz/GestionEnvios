using LogicaNegocio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioComentario : IRepositorio<Comentario>
    {
        public void Agregar(Comentario comentario, int idEnvio);
    }
}
