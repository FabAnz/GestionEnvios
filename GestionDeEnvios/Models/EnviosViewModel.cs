using CasosUso.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Presentacion.Models
{
    public class EnviosViewModel
    {
        public EnvioDTO Envio { get; set; }
        public List<UsuarioDTO> Clientes { get; set; }

        [Required(ErrorMessage = "Seleccione un cliente")]
        public int ClienteId { get; set; }
        public List<AgenciaDTO> Agencias { get; set; }

        [Required(ErrorMessage = "Seleccione una agencia")]
        public int AgenciaId { get; set; }
        public string TipoEnvio { get; set; }
    }
}
