using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosUso.DTOs
{
    public class EnvioDTO
    {
        public int Id { get; set; }
        public int NTracking { get; set; }
        public UsuarioDTO Vendedor { get; set; }
        public string EmailCliente { get; set; }
        public int Peso { get; set; }
        public string Estado { get; set; }
        public DateTime FechaEnvio { get; set; }
        public string? Direccion { get; set; }
        public bool EntregaEficiente { get; set; }
        public AgenciaDTO? Agencia { get; set; }
    }
}
