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

        public ListarUsuarios(IRepositorioUsuario repoUsuario)
        {
            RepoUsuario = repoUsuario;
        }
        public List<UsuarioDTO> Listar()
        {
            List<Usuario> usuarios = RepoUsuario.FindAll();
            return MapperUsuario.ToListDTO(usuarios);
        }
    }
}
