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
        private static List<Rol> s_roles = new List<Rol>();

        private static int s_ultId = 2;

        public void Add(Rol obj)
        {
            throw new NotImplementedException();
        }

        public List<Rol> FindAll()
        {
            return s_roles;
        }

        public Rol FindById(int id)
        {
            throw new NotImplementedException();
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
