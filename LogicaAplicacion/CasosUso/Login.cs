using CasosUso.DTOs;
using CasosUso.InterfacesCasosUso;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class Login : ILogin
    {
        public IRepositorioUsuario RepoUsuario { get; set; }

        public Login(IRepositorioUsuario repo)
        {
            RepoUsuario = repo;
        }

        public void VerificarCredenciales(UsuarioLoginDTO usuario)
        {
            throw new NotImplementedException();
        }
    }
}
