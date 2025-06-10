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
    public class ListarRoles : IListarRoles
    {
        public IRepositorioRol RepoRol { get; set; }

        public ListarRoles(IRepositorioRol repo)
        {
            RepoRol = repo;
        }

        public List<RolDTO> Listar()
        {
            return MapperRol.ToListDTO(RepoRol.FindAll());
        }
    }
}
