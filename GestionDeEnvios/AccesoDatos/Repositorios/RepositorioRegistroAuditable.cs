using AccesoDatos.ContextoEF;
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
        public GestionDeEnviosContext Contexto { get; set; }

        public RepositorioRegistroAuditable(GestionDeEnviosContext ctx)
        {
            Contexto = ctx;
        }

        public void Add(RegistroAuditable obj)
        {
            if (obj == null)
                throw new DatosInvalidosException("Registro vacio, intente nuevamente");

            obj.UsuarioRealizoAcccion = Contexto.Usuarios.Find(obj.UsuarioRealizoAcccion.Id);
            obj.Validar();
            Contexto.RegistroSAuditables.Add(obj);
            Contexto.SaveChanges();
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
