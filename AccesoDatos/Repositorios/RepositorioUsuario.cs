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
            throw new NotImplementedException();
        }

        public List<Usuario> FindAll()
        {
            return s_usuarios;
        }

        public Usuario FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario obj)
        {
            throw new NotImplementedException();
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
