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
    public class ListarVendedores : IListarVendedores
    {
        public IRepositorioUsuario RepoUsuario { get; set; }

        public ListarVendedores(IRepositorioUsuario repoUsuario)
        {
            RepoUsuario = repoUsuario;
        }
        public List<UsuarioDTO> Listar()
        {
            List<Usuario> usuarios = RepoUsuario.FindAll().Where(u => u.Rol.Id == 1 || u.Rol.Id == 2).ToList();
            return MapperUsuario.ToListDTO(usuarios);
        }
    }
}
