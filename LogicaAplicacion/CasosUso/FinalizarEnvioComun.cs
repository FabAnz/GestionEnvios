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
    public class FinalizarEnvioComun : IFinalizarEnvioComun
    {
        public IRepositorioEnvio RepoEnvio { get; set; }

        public FinalizarEnvioComun(IRepositorioEnvio repo)
        {
            RepoEnvio = repo;
        }

        public void Finalizar(EnvioComunDTO envio)
        {
            throw new NotImplementedException();
        }
    }
}
