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
    public class FiltrarEnvios : IFiltrarEnvios
    {
        public IRepositorioEnvio RepoEnvios { get; set; }

        public FiltrarEnvios(IRepositorioEnvio repo)
        {
            RepoEnvios = repo;
        }
        public List<EnvioAClienteDTOs> Filtrar(string email, DateTime? fInicio, DateTime? fFin, string? estado)
        {
            return MapperEnvioACliente.ToListDTO(RepoEnvios.Filtrar(email, fInicio, fFin, estado));
        }
    }
}
