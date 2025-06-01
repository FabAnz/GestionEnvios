using CasosUso.DTOs;
using CasosUso.InterfacesCasosUso;
using ExcepcionesPropias.Excepciones;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        public ILogin CULogin { get; set; }

        public UsuariosController(ILogin cuLogin)
        {
            CULogin = cuLogin;
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
            catch (DatosInvalidosException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrio un problema, contacte al administrador");
            }

        }
    }
}
