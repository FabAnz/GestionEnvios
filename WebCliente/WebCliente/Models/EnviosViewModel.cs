using System.ComponentModel;
using WebCliente.DTOs;

namespace WebCliente.Models
{
    public class EnviosViewModel
    {
        public List<EnvioDTO> Envios { get; set; }

        [DisplayName("Inicio")]
        public DateTime? FInicio { get; set; }

        [DisplayName("Fin")]
        public DateTime? FFin { get; set; }

        public string? Estado { get; set; }
        public string? Comentario { get; set; }
    }
}
