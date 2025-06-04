using CasosUso.DTOs;
using CasosUso.InterfacesCasosUso;
using ExcepcionesPropias.Excepciones;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        public ILogin CULogin { get; set; }
        public IModificarUsuario CUModificarUsuario { get; set; }
        public IBuscarUsuario CUBuscarUsuario { get; set; }

        public UsuariosController(
            ILogin cuLogin,
            IModificarUsuario cuModificarUsuario,
            IBuscarUsuario cuBuscarUsuario
            )
        {
            CULogin = cuLogin;
            CUModificarUsuario = cuModificarUsuario;
            CUBuscarUsuario = cuBuscarUsuario;
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
            try
            {
                CUModificarUsuario.ModificarContrasenia(dto);

                UsuarioDTO aRetornar = CUBuscarUsuario.BuscarPorEmail(dto.Email);
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
