using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebCliente.DTOs;

namespace WebCliente.Controllers
{
    public class UsuariosController : Controller
    {
        public string URLApi { get; set; }

        public UsuariosController(IConfiguration config)
        {
            URLApi = config.GetValue<string>("URLApi") + "Usuarios/";
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UsuarioDTO usuario)
        {
            try
            {
                bool exito = false;
                string body = AuxClienteHttp.ObtenerBody("post", URLApi, usuario, null, out exito);

                if (exito)
                {
                    RespuestaLogin respuesta = JsonConvert.DeserializeObject<RespuestaLogin>(body);
                    HttpContext.Session.SetString("email", respuesta.Email);
                    HttpContext.Session.SetString("rol", respuesta.Rol);
                    HttpContext.Session.SetString("token", respuesta.Token);
                    return RedirectToAction("BuscarEnvio", "Envios");
                }
                else
                {
                    ViewBag.Error = body;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "El servidor no responde, contacte con el administrador";
            }

            return View(usuario);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.SetString("email", "");
            HttpContext.Session.SetString("rol", "");
            HttpContext.Session.SetString("token", "");
            return RedirectToAction("BuscarEnvio", "Envios");
        }
    }
}
