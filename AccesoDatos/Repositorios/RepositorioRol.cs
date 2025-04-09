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
        private static List<Rol> s_roles = new List<Rol>()
        {
            new Rol(){Id=1,Nombre="Administrador"},
            new Rol(){Id=2,Nombre="Funcionario"},
        };

        private static int s_ultId = 3;

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
            foreach (Rol obj in s_roles)
            {
                if (obj.Id == id) return obj;
            }
            throw new DatosInvalidosException("El rol buscado no existe");
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
