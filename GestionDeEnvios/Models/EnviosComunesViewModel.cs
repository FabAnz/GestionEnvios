using CasosUso.DTOs;

namespace Presentacion.Models
{
    public class EnviosComunesViewModel
    {
        public EnvioDTO Envio { get; set; }
        public List<AgenciaDTO> Agencias { get; set; }
    }
}
