using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCliente.DTOs
{
    public class EnvioDTO
    {
        [DisplayName("N° Tracking")]
        [Required(ErrorMessage = "Ingreese el N° de tracking")]
        [Range(1, int.MaxValue, ErrorMessage = "El N° debe ser mayor a 0")]
        public int NTracking { get; set; }
        public string? Vendedor { get; set; }
        public string? Cliente { get; set; }
        public int? Peso { get; set; }
        public string? Estado { get; set; }
        [DisplayName("Fecha de envio")]
        public DateTime? FechaEnvio { get; set; }
        [DisplayName("Fecha de entrega")]
        public DateTime? FechaEntrega { get; set; }
        public List<ComentarioDTO>? Comentarios { get; set; }

        [DisplayName("Dirección")]
        public string? Direccion { get; set; }
    }
}
