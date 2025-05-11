using CasosUso.DTOs;
using CasosUso.InterfacesCasosUso;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnviosController : ControllerBase
    {
        public IBuscarEnvio CUBuscarEnvio { get; set; }

        public EnviosController(IBuscarEnvio cuBuscarEnvio)
        {
            CUBuscarEnvio = cuBuscarEnvio;
        }

        // GET api/<EnviosController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                EnvioDTO envio = CUBuscarEnvio.Buscar(id);
                if (envio == null) return NotFound("El envio con id " + id + " no existe");

                return Ok(envio);
            }
            catch
            {
                return StatusCode(500, "Ocurrio un problema, contacte al administrador");
            }
        }
    }
}
