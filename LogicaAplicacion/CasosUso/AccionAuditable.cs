using CasosUso.DTOs;
using CasosUso.InterfacesCasosUso;
using LogicaAplicacion.Mappers;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public abstract class AccionAuditable : IAccionAuditable
    {
        public IRepositorioUsuario RepoUsuario { get; set; }
        public IRepositorioRegistroAuditable RepoRegistroAuditable { get; set; }

        protected AccionAuditable(
            IRepositorioUsuario repoUsuario,
            IRepositorioRegistroAuditable repoRegistroAuditable
            )
        {
            RepoUsuario = repoUsuario;
            RepoRegistroAuditable = repoRegistroAuditable;
        }

        public void GenerarRegistro(string accion, int idUsuarioActivo, UsuarioDTO usuarioAfectado)
        {
            RegistroAuditable registro = new RegistroAuditable();
            registro.Accion = accion;
            registro.UsuarioRealizoAcccion = RepoUsuario.FindById(idUsuarioActivo);
            registro.UsuarioAfectado = MapperUsuario.ToUsuario(usuarioAfectado);

            registro.Validar();
            RepoRegistroAuditable.Add(registro);
        }

    }
}
