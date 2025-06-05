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
    public class BuscarEnviosPorCliente : IBuscarEnviosPorCliente
    {
        public IRepositorioEnvio RepoEnvios { get; set; }
        public IRepositorioUsuario RepoUsuarios { get; set; }

        public BuscarEnviosPorCliente(IRepositorioEnvio repoEnvio, IRepositorioUsuario repoUsuarios)
        {
            RepoEnvios = repoEnvio;
            RepoUsuarios = repoUsuarios;
        }

        public List<EnvioAClienteDTOs> Buscar(string email)
        {
            Usuario usuario = RepoUsuarios.BuscarUsuarioPorEmail(email);
            if (usuario == null) throw new DatosInvalidosException($"No existe el usuario con email {email}");

            return MapperEnvioACliente.ToListDTO(RepoEnvios.ListarPorCliente(email));
        }
    }
}
