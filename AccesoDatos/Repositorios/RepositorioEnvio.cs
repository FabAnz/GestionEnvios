using AccesoDatos.ContextoEF;
using ExcepcionesPropias.Excepciones;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Repositorios
{
    public class RepositorioEnvio : IRepositorioEnvio
    {
        public GestionDeEnviosContext Contexto { get; set; }

        public RepositorioEnvio(GestionDeEnviosContext ctx)
        {
            Contexto = ctx;
        }

        public void Add(Envio obj)
        {
            if (obj == null) throw new DatosInvalidosException("El envio esta vacio");

            obj.Vendedor = Contexto.Usuarios.Find(obj.Vendedor.Id);
            if (obj is Comun)
                ((Comun)obj).Destino = Contexto.Agencias.Find(((Comun)obj).Destino.Id);
            obj.Validar();
            Contexto.Envios.Add(obj);
            Contexto.SaveChanges();
        }

        public List<Envio> FindAll()
        {
            return Contexto.Envios
                .Include(envio => envio.Vendedor)
                .Include(envio => envio.Vendedor.Rol)
                .Include(envio => ((Comun)envio).Destino)
                .ToList();
        }

        public Envio FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Envio obj)
        {
            throw new NotImplementedException();
        }
    }
}
