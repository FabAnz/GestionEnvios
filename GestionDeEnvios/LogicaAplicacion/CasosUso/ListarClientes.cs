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
    public class ListarClientes : IListarClientes
    {
        public IRepositorioUsuario RepoUsuario { get; set; }

        public ListarClientes(IRepositorioUsuario repoUsuario)
        {
            RepoUsuario = repoUsuario;
        }
        public List<UsuarioDTO> Listar()
        {
            List<Usuario> usuarios = RepoUsuario.FindAll().Where(u => u.Rol.Id == 3).ToList();
            return MapperUsuario.ToListDTO(usuarios);
        }
    }
}
