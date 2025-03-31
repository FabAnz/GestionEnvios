using CasosUso.DTOs;
using CasosUso.InterfacesCasosUso;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class AltaEnvioUrgente : IAltaEnvioUrgente
    {
        public IRepositorioEnvio RepoEnvio { get; set; }

        public AltaEnvioUrgente(IRepositorioEnvio repo)
        {
            RepoEnvio = repo;
        }

        public void Emitir(EnvioUrgenteDTO envio)
        {
            throw new NotImplementedException();
        }
    }
}
