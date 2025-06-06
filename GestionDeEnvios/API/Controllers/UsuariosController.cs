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

        [HttpPost]
        public IActionResult Login([FromBody] UsuarioLoginDTO dto)
        {
            try
            {
                dto.Rol = CULogin.VerificarCredenciales(dto).Rol;

                string token = JWTManager.GenerarToken(dto);
                return Ok(new { Email = dto.Email, Rol = dto.Rol, Token = token });
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

        [HttpPut]
        [Authorize(Roles = "Cliente")]
        public IActionResult ModificarContrasenia([FromBody] ModificarContraseniaDTO dto)
        {
            string email = User.FindFirst(ClaimTypes.Email)?.Value;
            if (email == null) return Unauthorized("No hay usuario logueado");

            try
            {
                CUModificarContrasenia.Modificar(email, dto);

                UsuarioDTO aRetornar = CUBuscarUsuarioPorEmail.BuscarPorEmail(email);
                return Ok(aRetornar);
            }
            catch (NoAutorizadoException ex)
            {
                return Unauthorized(ex.Message);
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
