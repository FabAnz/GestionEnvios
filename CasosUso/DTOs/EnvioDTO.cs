using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosUso.DTOs
{
    public class EnvioDTO
    {
        public int Id { get; set; }
        [DisplayName("N° Tracking")]
        public int NTracking { get; set; }
        public UsuarioDTO Vendedor { get; set; }
        [DisplayName("Cliente")]
        public string EmailCliente { get; set; }
        public int Peso { get; set; }
        public string Estado { get; set; }
        [DisplayName("Fecha de envio")]
        public DateTime FechaEnvio { get; set; }
        [DisplayName("Fecha de entrega")]
        public DateTime FechaEntrega { get; set; }
        public List<ComentarioDTO> Comentarios { get; set; }
        public string? Direccion { get; set; }
        public bool EntregaEficiente { get; set; }
        public AgenciaDTO? Agencia { get; set; }
    }
}
