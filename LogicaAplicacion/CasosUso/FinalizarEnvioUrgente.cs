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
    public class FinalizarEnvioUrgente : IFinalizarEnvioUrgente
    {
        public IRepositorioEnvio RepoEnvio { get; set; }

        public FinalizarEnvioUrgente(IRepositorioEnvio repo)
        {
            RepoEnvio = repo;
        }

        public void Finalizar(EnvioUrgenteDTO envio)
        {
            throw new NotImplementedException();
        }
    }
}
