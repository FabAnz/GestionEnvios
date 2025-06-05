using CasosUso.DTOs;
using CasosUso.InterfacesCasosUso;
using ExcepcionesPropias.Excepciones;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnviosController : ControllerBase
    {
        public IBuscarEnvioPorNTracking CUBuscarEnvioPorNTracking { get; set; }
        public IBuscarEnviosPorCliente CUBuscarEnviosPorCliente { get; set; }

        public EnviosController(
            IBuscarEnvioPorNTracking cuBuscarEnvioPorNTracking,
            IBuscarEnviosPorCliente cUBuscarEnviosPorCliente)
        {
            CUBuscarEnvioPorNTracking = cuBuscarEnvioPorNTracking;
            CUBuscarEnviosPorCliente = cUBuscarEnviosPorCliente;
        }

        [HttpGet("{nTracking}")]
        public IActionResult Get(int nTracking)
        {
            try
            {
                EnvioAClienteDTOs envio = CUBuscarEnvioPorNTracking.Buscar(nTracking);
                if (envio == null) return NotFound($"El envio con N° Tracking {nTracking} no existe");

                return Ok(envio);
            }
            catch
            {
                return StatusCode(500, "Ocurrio un problema, contacte al administrador");
            }
        }

        [HttpGet()]
        [Authorize(Roles = "Cliente")]
        public IActionResult Get()
        {
            string email = User.FindFirst(ClaimTypes.Email)?.Value;

            if (email == null) return Unauthorized("No hay usuario logueado");

            try
            {
                List<EnvioAClienteDTOs> envios = CUBuscarEnviosPorCliente.Buscar(email);
                if (envios == null) return NotFound("No hay envios");

                return Ok(envios);
            }
            catch (DatosInvalidosException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return StatusCode(500, "Ocurrio un problema, contacte al administrador");
            }

        }
    }
}
