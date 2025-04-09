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
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private static List<Usuario> s_usuarios = new List<Usuario>()
        {
            new Usuario()
            {
                Id=1,
                Nombre="Fabian",
                Apellido="Antunez",
                Direccion="Calle 1234",
                Telefono="123456789",
                Email=new Email("fabian@email.com"),
                Contrasenia=new Contrasenia("Fabian123"),
                Rol=new Rol(){Id=1,Nombre="Administrador"}
            }
        };

        private static int s_ultId = 2;

        public void Add(Usuario obj)
        {
            if (obj == null)
                throw new DatosInvalidosException("Usuario vacio, intente nuevamente");
            if (BuscarUsuarioPorEmail(obj.Email.Valor) != null)
                throw new DatosInvalidosException("Ya existe un usuario con ese email");

            obj.Id = s_ultId++;

            obj.Validar();
            s_usuarios.Add(obj);
        }

        public Usuario BuscarUsuarioPorEmail(string email)
        {
            Usuario aux = null;

            foreach (Usuario usuario in s_usuarios)
            {
                if (usuario.Email.Valor == email)
                    return usuario;
            }
            return aux;
        }

        public List<Usuario> FindAll()
        {
            return s_usuarios;
        }

        public Usuario FindById(int id)
        {
            int inicio = 0;
            int fin = s_usuarios.Count() - 1;
            int medio;
            while (inicio <= fin)
            {
                medio = (inicio + fin) / 2;
                if (s_usuarios[medio].Id == id)
                    return s_usuarios[medio];

                if (s_usuarios[medio].Id < id)
                    inicio = medio + 1;

                if (s_usuarios[medio].Id > id)
                    fin = medio - 1;
            }
            throw new DatosInvalidosException("El usuario buscado no existe");
        }

        public void Remove(int id)
        {
            Usuario aBorrar = FindById(id);
            if (aBorrar == null)
                throw new DatosInvalidosException("El usuario no existe");

            s_usuarios.Remove(aBorrar);
        }

        public void Update(Usuario obj)
        {
            if (obj == null)
                throw new DatosInvalidosException("Usuario vacio, intente nuevamente");

            Usuario aModificar = FindById(obj.Id);

            if (!obj.Email.Equals(aModificar.Email))
                if (BuscarUsuarioPorEmail(obj.Email.Valor) != null)
                    throw new DatosInvalidosException("Ya existe un usuario con ese email");

            obj.Validar();
            aModificar.Nombre = obj.Nombre;
            aModificar.Apellido = obj.Apellido;
            aModificar.Direccion = obj.Direccion;
            aModificar.Telefono = obj.Telefono;
            aModificar.Email = obj.Email;
            aModificar.Contrasenia = obj.Contrasenia;
            aModificar.Rol = obj.Rol;
        }

        public Usuario VerificarCredenciales(string email, string contrasenia)
        {
            Usuario aRetornar = new Usuario();

            foreach (Usuario usuario in s_usuarios)
            {
                if (usuario.Email.Valor == email && usuario.Contrasenia.Valor == contrasenia)
                {
                    aRetornar.Id = usuario.Id;
                    aRetornar.Rol = usuario.Rol;
                    return aRetornar;
                }
            }
            throw new DatosInvalidosException("Email y/o contraseña incorrectos");
        }
    }
}
