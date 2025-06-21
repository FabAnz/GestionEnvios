using CasosUso.DTOs;
using CasosUso.InterfacesCasosUso;
using ExcepcionesPropias.Excepciones;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
        public IFiltrarEnvios CUFiltrarEnvios { get; set; }

        public EnviosController(
            IBuscarEnvioPorNTracking cuBuscarEnvioPorNTracking,
            IBuscarEnviosPorCliente cUBuscarEnviosPorCliente,
            IFiltrarEnvios cuFiltrarEnvios)
        {
            CUBuscarEnvioPorNTracking = cuBuscarEnvioPorNTracking;
            CUBuscarEnviosPorCliente = cUBuscarEnviosPorCliente;
            CUFiltrarEnvios = cuFiltrarEnvios;
        }

        private string EmailActivo()
        {
            return User.FindFirst(ClaimTypes.Email)?.Value;
        }

        /// <summary>
        /// Permite obtener los detalles de un envio por su numero de tracking
        /// </summary>
        /// <param name="nTracking">El n° de tracking</param>
        /// <returns>El dto del envio, 404 NotFound</returns>
        [HttpGet("{nTracking}")]
        [ProducesResponseType(typeof(EnvioAClienteDTOs), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult Get(int nTracking)
        {
            try
            {
                EnvioAClienteDTOs envio = CUBuscarEnvioPorNTracking.Buscar(null, nTracking);
                if (envio == null) return NotFound($"El envio con N° Tracking {nTracking} no existe");

                return Ok(envio);
            }
            catch
            {
                return StatusCode(500, "Ocurrio un problema, contacte al administrador");
            }
        }

        /// <summary>
        /// Permite al usuario logueado obtener los detalles de un envio propio con su numero de tracking
        /// </summary>
        /// <param name="nTracking">El n° de tracking</param>
        /// <returns>El dto del envio, 404 NotFound, 403 forbidden</returns>
        /// <remarks>Si hay usuario logueado extrae el email del token y a nivel repositorio se verifica que el envio corresponda al usuario</remarks>
        [HttpGet("detalle/{nTracking}")]
        [Authorize(Roles = "Cliente")]
        [ProducesResponseType(typeof(EnvioAClienteDTOs), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult GetDetalle(int nTracking)
        {
            try
            {
                EnvioAClienteDTOs envio = CUBuscarEnvioPorNTracking.Buscar(EmailActivo(), nTracking);
                if (envio == null) return NotFound($"El envio con N° Tracking {nTracking} no existe");

                return Ok(envio);
            }
            catch (NoAutorizadoException ex)
            {
                return StatusCode(403, ex.Message);
            }
            catch
            {
                return StatusCode(500, "Ocurrio un problema, contacte al administrador");
            }
        }

        /// <summary>
        /// Lista los envios del usuario filtrados por fecha y por palabras que aparezcan en los comentarios
        /// </summary>
        /// <param name="fInicio">Fecha de envio</param>
        /// <param name="fFin">Fecha de envio</param>
        /// <param name="estado">En proceso o Finalizado</param>
        /// <param name="comentario">Comentario</param>
        /// <returns>Lista de DTOs de envios, 404 NotFound, 400 BadRequest</returns>
        /// <remarks>Los filtros son opcionales, si no se pasa ninguno devuelve la lista sin filtrar</remarks>
        [HttpGet()]
        [Authorize(Roles = "Cliente")]
        [ProducesResponseType(typeof(List<EnvioAClienteDTOs>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult Get(
            [FromQuery] DateTime? fInicio,
            [FromQuery] DateTime? fFin,
            [FromQuery] string? estado,
            [FromQuery] string? comentario)
        {
            try
            {
                List<EnvioAClienteDTOs> envios = CUFiltrarEnvios.Filtrar(EmailActivo(), fInicio, fFin, estado, comentario);
                if (envios == null) return NotFound("No hay envios");
                return Ok(envios);
            }
            catch (DatosInvalidosException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrio un problema, contacte al administrador");
            }
        }
    }
}
