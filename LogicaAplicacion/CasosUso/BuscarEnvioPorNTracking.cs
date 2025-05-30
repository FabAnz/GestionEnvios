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
    public class BuscarEnvioPorNTracking : IBuscarEnvioPorNTracking
    {
        public IRepositorioEnvio RepoEnvio { get; set; }

        public BuscarEnvioPorNTracking(IRepositorioEnvio repoEnvio)
        {
            RepoEnvio = repoEnvio;
        }
        public EnvioDTO Buscar(int nTracking)
        {
            return MapperEnvio.ToDTO(RepoEnvio.BuscarPorNTraking(nTracking));
        }
    }
}
