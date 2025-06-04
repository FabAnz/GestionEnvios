using AccesoDatos.ContextoEF;
using ExcepcionesPropias.Excepciones;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Repositorios
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        public GestionDeEnviosContext Contexto { get; set; }

        public RepositorioUsuario(GestionDeEnviosContext ctx)
        {
            Contexto = ctx;
        }

        public void Add(Usuario obj)
        {
            if (obj == null)
                throw new DatosInvalidosException("Usuario vacio, intente nuevamente");

            if (BuscarUsuarioPorEmail(obj.Email.Valor) != null)
                throw new DatosInvalidosException("Ya existe un usuario con ese email");


            obj.Rol = Contexto.Roles.Find(obj.Rol.Id);
            obj.Validar();

            Contexto.Usuarios.Add(obj);
            Contexto.SaveChanges();
        }

        public Usuario BuscarUsuarioPorEmail(string email)
        {
            Usuario aRetornar = Contexto.Usuarios
                .Include(usuario => usuario.Rol)
                .Where(usuario => usuario.Email.Valor == email)
                .SingleOrDefault();

            return aRetornar;
        }

        public List<Usuario> FindAll()
        {
            return Contexto.Usuarios.Include(usuario => usuario.Rol).ToList();
        }

        public Usuario FindById(int id)
        {
            Usuario aRetornar = Contexto.Usuarios
                .Include(usuario => usuario.Rol)
                .Where(usuario => usuario.Id == id)
                .SingleOrDefault();
            if (aRetornar == null)
                throw new DatosInvalidosException("El usuario buscado no existe");
            return aRetornar;
        }

        public void Remove(int id)
        {
            Usuario aBorrar = FindById(id);

            bool hayEnvios =
                Contexto.Envios.Any(e => e.Vendedor.Id == id || e.Cliente.Id == id);

            if (aBorrar == null) throw new DatosInvalidosException("El usuario no existe");
            if (hayEnvios) throw new OperacionConflictivaException("El usuario tiene envios asociados, no se puede eliminar");
            Contexto.Usuarios.Remove(aBorrar);
            Contexto.SaveChanges();
        }

        public void Update(Usuario obj)
        {
            if (obj == null)
                throw new DatosInvalidosException("Usuario vacio, intente nuevamente");

            Usuario aModificar = FindById(obj.Id);
            Contexto.Entry(aModificar).State = EntityState.Detached;

            if (!obj.Email.Equals(aModificar.Email))
                if (BuscarUsuarioPorEmail(obj.Email.Valor) != null)
                    throw new DatosInvalidosException("Ya existe un usuario con ese email");

            obj.Rol = Contexto.Roles.Find(obj.Rol.Id);
            obj.Validar();
            Contexto.Usuarios.Update(obj);
            Contexto.SaveChanges();
        }

        public Usuario VerificarCredenciales(string email, string contrasenia)
        {
            Usuario aRetornar = BuscarUsuarioPorEmail(email);
            if (aRetornar == null || aRetornar.Contrasenia.Valor != contrasenia)
                throw new NoAutorizadoException("Email y/o contraseña incorrectos");
            return aRetornar;
        }

        public List<Usuario> ListarVendedores()
        {
            return Contexto.Usuarios
                .Include(usuario => usuario.Rol)
                .Where(usuario => usuario.Rol.Id != 3)
                .ToList();
        }

        public void ModificarContrasenia(string email, string actual, string nueva)
        {
            try
            {
                Usuario usuario = VerificarCredenciales(email, actual);
                usuario.Contrasenia = new Contrasenia(nueva);

                usuario.Validar();
                Contexto.Usuarios.Update(usuario);
                Contexto.SaveChanges();
            }
            catch (NoAutorizadoException ex)
            {
                throw new NoAutorizadoException("Contraseña actual incorrecta");
            }
        }
    }
}
