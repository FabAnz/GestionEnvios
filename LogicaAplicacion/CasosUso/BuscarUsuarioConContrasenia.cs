using CasosUso.DTOs;
using CasosUso.InterfacesCasosUso;
using LogicaAplicacion.Mappers;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class BuscarUsuarioConContrasenia : IBuscarUsuarioConContrasenia
    {
        public IRepositorioUsuario RepoUsuario { get; set; }

        public BuscarUsuarioConContrasenia(IRepositorioUsuario repo)
        {
            RepoUsuario = repo;
        }
        public UsuarioConContraseniaDTO Buscar(int id)
        {
            return MapperUsuarioConContrasenia.ToDTO(RepoUsuario.FindById(id));
        }
    }
}
