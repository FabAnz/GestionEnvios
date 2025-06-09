using CasosUso.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosUso.InterfacesCasosUso
{
    public interface IFiltrarEnvios
    {
        public List<EnvioAClienteDTOs> Filtrar(
            string email, 
            DateTime? fInicio, 
            DateTime? fFin, 
            string? estado, 
            string? comentario);
    }
}
