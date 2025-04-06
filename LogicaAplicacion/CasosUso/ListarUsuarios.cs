using CasosUso.DTOs;
using CasosUso.InterfacesCasosUso;
using LogicaAplicacion.Mappers;
using LogicaNegocio.EntidadesDominio;
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
        public IRepositorioRol RepoRol { get; set; }

        public ListarUsuarios(IRepositorioUsuario repoUsuario, IRepositorioRol repoRol)
        {
            RepoUsuario = repoUsuario;
            RepoRol = repoRol;
        }
        public List<UsuarioDTO> Listar()
        {
            List<Usuario> usuarios = RepoUsuario.FindAll();
            List<Rol> roles = RepoRol.FindAll();
            return MapperUsuario.ToListDTO(usuarios, roles);
        }
    }
}
