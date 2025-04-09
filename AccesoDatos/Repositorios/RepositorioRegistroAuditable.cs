using ExcepcionesPropias.Excepciones;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Repositorios
{
    public class RepositorioRegistroAuditable : IRepositorioRegistroAuditable
    {
        private static List<RegistroAuditable> s_registros = new List<RegistroAuditable>();

        private static int s_ultId = 1;
        public void Add(RegistroAuditable obj)
        {
            if (obj == null)
                throw new DatosInvalidosException("Registro vacio, intente nuevamente");

            obj.Id = s_ultId++;

            obj.Validar();
            s_registros.Add(obj);
        }

        public List<RegistroAuditable> FindAll()
        {
            throw new NotImplementedException();
        }

        public RegistroAuditable FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(RegistroAuditable obj)
        {
            throw new NotImplementedException();
        }
    }
}
