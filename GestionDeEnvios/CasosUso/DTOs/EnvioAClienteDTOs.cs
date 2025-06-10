using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosUso.DTOs
{
    public class EnvioAClienteDTOs
    {
        public int NTracking { get; set; }
        public string Vendedor { get; set; }
        public string Cliente { get; set; }
        public int Peso { get; set; }
        public string Estado { get; set; }
        public DateTime FechaEnvio { get; set; }
        public DateTime FechaEntrega { get; set; }
        public List<ComentarioAClienteDTO> Comentarios { get; set; }
        public string Direccion { get; set; }
    }
}
