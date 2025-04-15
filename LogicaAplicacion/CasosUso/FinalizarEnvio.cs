using CasosUso.InterfacesCasosUso;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class FinalizarEnvio : IFinalizarEnvio
    {
        public IRepositorioEnvio RepoEnvio { get; set; }

        public FinalizarEnvio(IRepositorioEnvio repoEnvio)
        {
            RepoEnvio = repoEnvio;
        }
        public void Finalizar(int id)
        {
            Envio envio = RepoEnvio.FindById(id);
            envio.FinalizarEnvio();
            envio.Validar();
            RepoEnvio.Update(envio);
        }
    }
}
