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
    public class RepositorioComentario : IRepositorioComentario
    {
        public GestionDeEnviosContext Contexto { get; set; }

        public RepositorioComentario(GestionDeEnviosContext ctx)
        {
            Contexto = ctx;
        }

        public void Add(Comentario obj)
        {
            throw new NotImplementedException();
        }

        public List<Comentario> FindAll()
        {
            throw new NotImplementedException();
        }

        public Comentario FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Comentario obj)
        {
            throw new NotImplementedException();
        }

        public void Agregar(Comentario comentario, int idEnvio)
        {
            if (comentario == null)
                throw new DatosInvalidosException("No se paso ningun comentario");
            if (idEnvio == 0)
                throw new DatosInvalidosException("El id de envio es null");

            Envio envio = Contexto.Envios
                .Include(e => e.Comentarios)
                .Where(e => e.Id == idEnvio)
                .SingleOrDefault();

            comentario.Usuario = Contexto.Usuarios.Find(comentario.Usuario.Id);
            comentario.Validar();
            envio.Comentarios.Add(comentario);
            Contexto.SaveChanges();
        }
    }
}
