using CasosUso.DTOs;
using CasosUso.InterfacesCasosUso;
using ExcepcionesPropias.Excepciones;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        public ILogin CULogin { get; set; }
        public IModificarContrasenia CUModificarContrasenia { get; set; }
        public IBuscarUsuarioPorEmail CUBuscarUsuarioPorEmail { get; set; }

        public UsuariosController(
            ILogin cuLogin,
            IModificarContrasenia cuModificarContrasenia,
            IBuscarUsuarioPorEmail cuBuscarUsuario
            )
        {
            CULogin = cuLogin;
            CUModificarContrasenia = cuModificarContrasenia;
            CUBuscarUsuarioPorEmail = cuBuscarUsuario;
        }

        /// <summary>
        /// Login de usuario
        /// </summary>
        /// <param name="dto">DTO que contiene email y contraseña</param>
        /// <returns>Objeto con email, rol y token, 401 Unauthorized</returns>
        [HttpPost]
        [ProducesResponseType(typeof(LoginResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        public IActionResult Login([FromBody] UsuarioLoginDTO dto)
        {
            try
            {
                dto.Rol = CULogin.VerificarCredenciales(dto).Rol;

                string token = JWTManager.GenerarToken(dto);
                return Ok(new LoginResponseDTO { Email = dto.Email, Rol = dto.Rol, Token = token });
            }
            catch (NoAutorizadoException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrio un problema, contacte al administrador");
            }

        }

        /// <summary>
        /// Modificar las contraseña del usuario
        /// </summary>
        /// <param name="dto">Contiene la contraseña actual y la nueva</param>
        /// <returns>El DTO del usuario, 400 BadRequest,403 Forbidden</returns>
        [HttpPut]
        [Authorize(Roles = "Cliente")]
        [ProducesResponseType(typeof(UsuarioDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult ModificarContrasenia([FromBody] ModificarContraseniaDTO dto)
        {
            string email = User.FindFirst(ClaimTypes.Email)?.Value;

            try
            {
                CUModificarContrasenia.Modificar(email, dto);

                UsuarioDTO aRetornar = CUBuscarUsuarioPorEmail.BuscarPorEmail(email);
                return Ok(aRetornar);
            }
            catch (NoAutorizadoException ex)
            {
                return StatusCode(403, ex.Message);
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
