using CasosUso.DTOs;
using CasosUso.InterfacesCasosUso;
using ExcepcionesPropias.Excepciones;
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
    public class AltaUsuario : IAltaUsuario
    {
        public IRepositorioUsuario RepoUsuario { get; set; }
        public IRepositorioRegistroAuditable RepoRegistroAuditable { get; set; }

        public AltaUsuario(IRepositorioUsuario repoUsuario, IRepositorioRegistroAuditable repoRegistro)
        {
            RepoUsuario = repoUsuario;
            RepoRegistroAuditable = repoRegistro;
        }

        public void EjecutarAlta(UsuarioDTO dto, int idUsuarioActivo)
        {
            if (dto == null)
                throw new DatosInvalidosException("Usuario vacio, intente nuevamente");
            Usuario usuario = MapperUsuario.ToUsuario(dto);
            usuario.Validar();
            RepoUsuario.Add(usuario);
            GenerarRegistro("Alta de usuario", idUsuarioActivo, dto);
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
