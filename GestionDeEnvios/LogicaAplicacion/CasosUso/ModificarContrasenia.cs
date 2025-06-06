using CasosUso.DTOs;
using CasosUso.InterfacesCasosUso;
using ExcepcionesPropias.Excepciones;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class ModificarContrasenia : IModificarContrasenia
    {
        public IRepositorioUsuario RepoUsuario { get; set; }

        public ModificarContrasenia(
            IRepositorioUsuario repoUsuario
            )
        {
            RepoUsuario = repoUsuario;
        }
        public void Modificar(string email, ModificarContraseniaDTO dto)
        {
            if (dto == null)
                throw new DatosInvalidosException("Usuario vacio, intente nuevamente");
            RepoUsuario.ModificarContrasenia(email, dto.Actual, dto.Nueva);
        }
    }
}
