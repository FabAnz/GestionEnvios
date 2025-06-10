using LogicaNegocio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioUsuario : IRepositorio<Usuario>
    {
        public Usuario BuscarUsuarioPorEmail(string email);
        public Usuario VerificarCredenciales(string email, string contrasenia);
        public List<Usuario> ListarVendedores();

        public void ModificarContrasenia(string email, string actual, string nueva);
    }
}
