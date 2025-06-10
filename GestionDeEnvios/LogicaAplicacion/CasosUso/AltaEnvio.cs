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
    public class AltaEnvio : IAltaEnvio
    {
        public IRepositorioEnvio RepoEnvio { get; set; }

        public AltaEnvio(IRepositorioEnvio repoEnvio)
        {
            RepoEnvio = repoEnvio;
        }
        public void Ejecutar(EnvioDTO dto)
        {
            Envio envio = MapperEnvio.ToEnvio(dto);

            envio.Validar();
            RepoEnvio.Add(envio);
        }
    }
}
