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
    public class BajaUsuario : IBajaUsuario
    {
        public IRepositorioUsuario RepoUsuario { get; set; }
        public IRepositorioRegistroAuditable RepoRegistroAuditable { get; set; }

        public BajaUsuario(IRepositorioUsuario repoUsuario, IRepositorioRegistroAuditable repoRegistro)
        {
            RepoUsuario = repoUsuario;
            RepoRegistroAuditable = repoRegistro;
        }
      
        public void EjecutarBaja(int id, int idUsuarioActivo)
        {
            throw new NotImplementedException();
        }
    }
}
