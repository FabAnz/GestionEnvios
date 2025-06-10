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
    public class ListarEnviosEnProceso : IListarEnviosEnProceso
    {
        public IRepositorioEnvio RepoEnvio { get; set; }

        public ListarEnviosEnProceso(IRepositorioEnvio repoEnvio)
        {
            RepoEnvio = repoEnvio;
        }
        public List<EnvioDTO> Listar()
        {
            return MapperEnvio.ToListDTO(RepoEnvio.ListarEnProceso());
        }
    }
}
