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
    public class AltaUsuario : IAltaUsuario
    {
        public IRepositorioUsuario RepoUsuario { get; set; }
        public IRepositorioRegistroAuditable RepoRegistroAuditable { get; set; }

        public AltaUsuario(IRepositorioUsuario repoUsuario, IRepositorioRegistroAuditable repoRegistro)
        {
            RepoUsuario = repoUsuario;
            RepoRegistroAuditable = repoRegistro;
        }

        public void EjecutarAlta(UsuarioDTO usuario)
        {
            throw new NotImplementedException();
        }

        public void GenerarRegistro()
        {
            throw new NotImplementedException();
        }
    }
}
