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
    public class BuscarUsuario : IBuscarUsuario
    {
        public IRepositorioUsuario RepoUsuario { get; set; }

        public BuscarUsuario(IRepositorioUsuario repo)
        {
            RepoUsuario = repo;
        }
        public UsuarioDTO Buscar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
