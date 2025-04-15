using CasosUso.DTOs;
using CasosUso.InterfacesCasosUso;
using ExcepcionesPropias.Excepciones;
using LogicaAplicacion.Mappers;
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

        public UsuarioLoginDTO VerificarCredenciales(UsuarioLoginDTO usuario)
        {
            if (usuario == null) throw new DatosInvalidosException("No se puede pasar un usuario vacio");

            UsuarioLoginDTO dto = MapperUsuarioLogin.ToDTO(RepoUsuario.VerificarCredenciales(usuario.Email, usuario.Contrasenia));

            if (dto == null) throw new DatosInvalidosException("Email y/o contraseña incorrecto");
            return dto;
        }
    }
}
