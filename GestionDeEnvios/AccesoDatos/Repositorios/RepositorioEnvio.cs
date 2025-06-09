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
            obj.Cliente = Contexto.Usuarios.Find(obj.Cliente.Id);
            if (obj is Comun)
                ((Comun)obj).Destino = Contexto.Agencias.Find(((Comun)obj).Destino.Id);
            obj.NTracking = ObtenerNTracking();
            obj.Validar();
            Contexto.Envios.Add(obj);
            Contexto.SaveChanges();
        }

        public List<Envio> FindAll()
        {
            return Contexto.Envios
                .Include(envio => envio.Vendedor)
                .Include(envio => envio.Vendedor.Rol)
                .Include(envio => envio.Cliente)
                    .ThenInclude(c => c.Rol)
                .Include(envio => ((Comun)envio).Destino)
                .Include(envio => envio.Comentarios)
                .ToList();
        }

        public Envio FindById(int id)
        {
            return Contexto.Envios
                .Include(envio => envio.Vendedor)
                .Include(envio => envio.Vendedor.Rol)
                .Include(envio => envio.Cliente)
                    .ThenInclude(c => c.Rol)
                .Include(envio => ((Comun)envio).Destino)
                .Include(envio => envio.Comentarios)
                .Where(envio => envio.Id == id)
                .SingleOrDefault();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Envio obj)
        {
            if (obj == null) throw new DatosInvalidosException("El envio esta vacio");

            obj.Vendedor = Contexto.Usuarios.Find(obj.Vendedor.Id);
            if (obj is Comun)
                ((Comun)obj).Destino = Contexto.Agencias.Find(((Comun)obj).Destino.Id);
            obj.Validar();
            Contexto.Envios.Update(obj);
            Contexto.SaveChanges();
        }

        public List<Envio> ListarEnProceso()
        {
            return Contexto.Envios
                .Include(envio => envio.Vendedor)
                .Include(envio => envio.Vendedor.Rol)
                .Include(envio => envio.Cliente)
                .Include(envio => envio.Cliente.Rol)
                .Include(envio => ((Comun)envio).Destino)
                .Include(envio => envio.Comentarios)
                .Where(envio => envio.Estado.Equals(EstadoEnvio.EN_PROCESO))
                .ToList();
        }

        public int ObtenerNTracking()
        {
            int num = Contexto.Envios
                .OrderByDescending(e => e.NTracking)
                .Select(e => e.NTracking)
                .FirstOrDefault();

            return num + 1;
        }

        public Envio BuscarPorNTraking(int NTraking)
        {
            return Contexto.Envios
                .Include(envio => envio.Vendedor)
                .Include(envio => envio.Vendedor.Rol)
                .Include(envio => envio.Cliente)
                    .ThenInclude(c => c.Rol)
                .Include(envio => ((Comun)envio).Destino)
                .Include(envio => envio.Comentarios)
                .Where(e => e.NTracking == NTraking)
                .SingleOrDefault();
        }

        public List<Envio> ListarPorCliente(string email)
        {
            if (email == null) throw new DatosInvalidosException("El email esta vacio");

            return Contexto.Envios
                .Include(envio => envio.Vendedor)
                .Include(envio => envio.Vendedor.Rol)
                .Include(envio => envio.Cliente)
                    .ThenInclude(c => c.Rol)
                .Include(envio => ((Comun)envio).Destino)
                .Include(envio => envio.Comentarios)
                .Where(envio => envio.Cliente.Email.Valor == email)
                .OrderBy(envio => envio.FechaEnvio)
                .ToList();
        }

        public List<Envio> Filtrar(string email, DateTime? fInicio, DateTime? fFin, string? estado, string? comentario)
        {
            List<Envio> aRetornar = ListarPorCliente(email);

            if (fInicio != null) aRetornar = aRetornar.Where(e => e.FechaEnvio >= fInicio).OrderBy(e => e.NTracking).ToList();
            if (fFin != null) aRetornar = aRetornar.Where(e => e.FechaEnvio <= fFin).OrderBy(e => e.NTracking).ToList();
            if (!string.IsNullOrEmpty(estado))
            {
                if (estado != "En proceso" && estado != "Finalizado")
                    throw new DatosInvalidosException("El estado debe ser \"Finalizado\" o \"En proceso\"");
                EstadoEnvio estadoEnvio = estado == "En proceso" ? EstadoEnvio.EN_PROCESO : EstadoEnvio.FINALIZADO;
                aRetornar = aRetornar.Where(e => e.Estado == estadoEnvio).OrderBy(e => e.NTracking).ToList();
            }
            if (!string.IsNullOrEmpty(comentario))
                aRetornar = aRetornar
                    .Where(e => e.Comentarios.Any(c => c.Texto.ToLower().Contains(comentario.ToLower())))
                    .OrderBy(e => e.FechaEnvio).ToList();

            return aRetornar;
        }
    }
}
