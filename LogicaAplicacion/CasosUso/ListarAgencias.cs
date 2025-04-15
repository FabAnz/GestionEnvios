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
    public class ListarAgencias : IListarAgencias
    {
        public IRepositorioAgencia RepoAgencia { get; set; }

        public ListarAgencias(IRepositorioAgencia repoAgencia)
        {
            RepoAgencia = repoAgencia;
        }
        public List<AgenciaDTO> Listar()
        {
            return MapperAgencia.ToListDTO(RepoAgencia.FindAll());
        }
    }
}
