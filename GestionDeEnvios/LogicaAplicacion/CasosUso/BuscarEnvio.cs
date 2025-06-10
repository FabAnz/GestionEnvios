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
    public class BuscarEnvio : IBuscarEnvio
    {
        public IRepositorioEnvio RepoEnvio { get; set; }

        public BuscarEnvio(IRepositorioEnvio repoEnvio)
        {
            RepoEnvio = repoEnvio;
        }
        public EnvioDTO Buscar(int id)
        {
            return MapperEnvio.ToDTO(RepoEnvio.FindById(id));
        }
    }
}
