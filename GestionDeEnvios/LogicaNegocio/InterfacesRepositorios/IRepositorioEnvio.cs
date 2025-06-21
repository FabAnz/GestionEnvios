using LogicaNegocio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioEnvio : IRepositorio<Envio>
    {
        public List<Envio> ListarEnProceso();
        public List<Envio> ListarPorCliente(string email);
        public Envio BuscarPorNTraking(string email, int nTraking);
        public int ObtenerNTracking();
        public List<Envio> Filtrar(string email, DateTime? fInicio, DateTime? fFin, string? estado, string? comentario);
    }
}
