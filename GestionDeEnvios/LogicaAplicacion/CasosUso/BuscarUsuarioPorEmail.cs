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
    public class BuscarUsuarioPorEmail:IBuscarUsuarioPorEmail
    {
        public IRepositorioUsuario RepoUsuario { get; set; }

        public BuscarUsuarioPorEmail(IRepositorioUsuario repo)
        {
            RepoUsuario = repo;
        }
        public UsuarioDTO BuscarPorEmail(string email)
        {
            return MapperUsuario.ToDTO(RepoUsuario.BuscarUsuarioPorEmail(email));
        }
    }
}
