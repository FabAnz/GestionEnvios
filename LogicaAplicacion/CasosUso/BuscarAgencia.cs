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
    public class BuscarAgencia : IBuscarAgencia
    {
        public IRepositorioAgencia RepoAgencia { get; set; }

        public BuscarAgencia(IRepositorioAgencia repoAgencia)
        {
            RepoAgencia = repoAgencia;
        }
        public AgenciaDTO Buscar(int id)
        {
            return MapperAgencia.ToDTO(RepoAgencia.FindById(id));
        }
    }
}
