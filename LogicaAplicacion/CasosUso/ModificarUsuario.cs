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
    public class ModificarUsuario : IModificarUsuario
    {
        public IRepositorioUsuario RepoUsuario { get; set; }
        public IRepositorioRegistroAuditable RepoRegistroAuditable { get; set; }

        public ModificarUsuario(IRepositorioUsuario repoUsuario, IRepositorioRegistroAuditable repoRegistro)
        {
            RepoUsuario = repoUsuario;
            RepoRegistroAuditable = repoRegistro;
        }

        public void Modifiacr(UsuarioDTO usuario, int idUsuarioActivo)
        {
            throw new NotImplementedException();
        }

        public void GenerarRegistro(string accion, int idUsuarioActivo, UsuarioDTO usuarioAfectado)
        {
            throw new NotImplementedException();
        }
    }
}
