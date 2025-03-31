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
    public class ListarUsuarios : IListarUsuarios
    {
        public IRepositorioUsuario RepoUsuario { get; set; }

        public ListarUsuarios(IRepositorioUsuario repo)
        {
            RepoUsuario = repo;
        }
        public List<UsuarioDTO> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
