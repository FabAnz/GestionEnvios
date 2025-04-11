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
    public class RepositorioRol : IRepositorioRol
    {
        public GestionDeEnviosContext Contexto { get; set; }

        public RepositorioRol(GestionDeEnviosContext ctx)
        {
            Contexto = ctx;
        }

        public void Add(Rol obj)
        {
            throw new NotImplementedException();
        }

        public List<Rol> FindAll()
        {
            return Contexto.Roles.ToList();
        }

        public Rol FindById(int id)
        {
            Rol aRetornar = Contexto.Roles.Find(id);
            if (aRetornar == null)
                throw new DatosInvalidosException("El rol buscado no existe");
            return aRetornar;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Rol obj)
        {
            throw new NotImplementedException();
        }
    }
}
