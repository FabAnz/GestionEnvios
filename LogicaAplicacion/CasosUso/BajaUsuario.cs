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
    public class BajaUsuario : AccionAuditable, IBajaUsuario
    {
        public IRepositorioUsuario RepoUsuario { get; set; }

        public BajaUsuario(
            IRepositorioUsuario repoUsuario,
            IRepositorioRegistroAuditable repoRegistro
            ) : base(repoUsuario, repoRegistro)
        {
            RepoUsuario = repoUsuario;
        }

        public void EjecutarBaja(int id, UsuarioDTO usuarioActivo)
        {

            UsuarioDTO dto = MapperUsuario.ToDTO(RepoUsuario.FindById(id));
            if (dto == null)
                throw new DatosInvalidosException("El usuario no existe");
            RepoUsuario.Remove(id);

            GenerarRegistro("Baja de usuario", usuarioActivo, dto.Email);
        }
    }
}
