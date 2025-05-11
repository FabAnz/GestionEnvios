using CasosUso.DTOs;

namespace Presentacion.Models
{
    public class EnviosViewModel
    {
        public EnvioDTO Envio { get; set; }
        public List<UsuarioDTO> Clientes { get; set; }
        public List<AgenciaDTO> Agencias { get; set; }
        public string TipoEnvio { get; set; }
    }
}
