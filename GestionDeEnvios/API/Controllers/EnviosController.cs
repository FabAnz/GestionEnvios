using CasosUso.DTOs;
using CasosUso.InterfacesCasosUso;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnviosController : ControllerBase
    {
        public IBuscarEnvioPorNTracking CUBuscarEnvioPorNTracking { get; set; }

        public EnviosController(IBuscarEnvioPorNTracking cuBuscarEnvioPorNTracking)
        {
            CUBuscarEnvioPorNTracking = cuBuscarEnvioPorNTracking;
        }

        // GET api/<EnviosController>/5
        [HttpGet("{nTracking}")]
        public IActionResult Get(int nTracking)
        {
            try
            {
                EnvioAClienteDTOs envio = CUBuscarEnvioPorNTracking.Buscar(nTracking);
                if (envio == null) return NotFound("El envio con N° Tracking " + nTracking + " no existe");

                return Ok(envio);
            }
            catch
            {
                return StatusCode(500, "Ocurrio un problema, contacte al administrador");
            }
        }
    }
}
