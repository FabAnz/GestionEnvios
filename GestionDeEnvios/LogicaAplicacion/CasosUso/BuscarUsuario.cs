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
    public class BuscarUsuario : IBuscarUsuario
    {
        public IRepositorioUsuario RepoUsuario { get; set; }

        public BuscarUsuario(IRepositorioUsuario repo)
        {
            RepoUsuario = repo;
        }
        public UsuarioDTO BuscarPorId(int id)
        {
            return MapperUsuario.ToDTO(RepoUsuario.FindById(id));
        }

        public UsuarioDTO BuscarPorEmail(string email)
        {
            return MapperUsuario.ToDTO(RepoUsuario.BuscarUsuarioPorEmail(email));
        }
    }
}
