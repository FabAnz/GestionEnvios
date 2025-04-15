using AccesoDatos.ContextoEF;
using ExcepcionesPropias.Excepciones;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Repositorios
{
    public class RepositorioAgencia : IRepositorioAgencia
    {
        public GestionDeEnviosContext Contexto { get; set; }

        public RepositorioAgencia(GestionDeEnviosContext ctx)
        {
            Contexto = ctx;
        }
        public void Add(Agencia obj)
        {
            throw new NotImplementedException();
        }

        public List<Agencia> FindAll()
        {
            return Contexto.Agencias.ToList();
        }

        public Agencia FindById(int id)
        {
            Agencia aRetornar = Contexto.Agencias.Find(id);
            if (aRetornar == null)
                throw new DatosInvalidosException("La agencia buscada no existe");
            return aRetornar;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Agencia obj)
        {
            throw new NotImplementedException();
        }
    }
}
