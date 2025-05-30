using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        public UsuarioDTO Cliente { get; set; }

        [Required(ErrorMessage = "Ingrese el peso")]
        [Range(1, int.MaxValue, ErrorMessage = "El peso debe ser mayor a 0")]
        public int Peso { get; set; }
        public string Estado { get; set; }
        [DisplayName("Fecha de envio")]
        public DateTime FechaEnvio { get; set; }
        [DisplayName("Fecha de entrega")]
        public DateTime FechaEntrega { get; set; }
        public List<ComentarioDTO> Comentarios { get; set; }

        [Required(ErrorMessage = "Ingrese la dirección")]
        [DisplayName("Dirección")]
        public string? Direccion { get; set; }
        public bool EntregaEficiente { get; set; }
        public AgenciaDTO? Agencia { get; set; }
    }
}
