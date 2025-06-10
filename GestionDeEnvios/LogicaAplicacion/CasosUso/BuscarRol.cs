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
    public class BuscarRol : IBuscarRol
    {
        public IRepositorioRol RepoRol { get; set; }

        public BuscarRol(IRepositorioRol repoRol)
        {
            RepoRol = repoRol;
        }

        public RolDTO Buscar(int id)
        {
            return MapperRol.ToDTO(RepoRol.FindById(id));
        }
    }
}
