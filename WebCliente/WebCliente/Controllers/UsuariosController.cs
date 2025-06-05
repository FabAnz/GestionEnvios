using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebCliente.DTOs;
using WebCliente.Filters;
using WebCliente.Models;

namespace WebCliente.Controllers
{
    public class UsuariosController : Controller
    {
        public string URLApi { get; set; }

        public UsuariosController(IConfiguration config)
        {
            URLApi = config.GetValue<string>("URLApi") + "Usuarios/";
        }

        private string EmailActivo()
        {
            return HttpContext.Session.GetString("email");
        }

        private string TokenActivo()
        {
            return HttpContext.Session.GetString("token");
        }

        [HttpGet]
        public IActionResult Login(String error)
        {
            ViewBag.Error = error;
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
                    return RedirectToAction("Index", "Envios");
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
        public IActionResult Logout(string error)
        {
            HttpContext.Session.SetString("email", "");
            HttpContext.Session.SetString("rol", "");
            HttpContext.Session.SetString("token", "");
            return RedirectToAction("Login", new { error = error });
        }

        [HttpGet]
        [RolClienteFilter]
        public IActionResult CambiarContrasenia()
        {
            return View();
        }

        [HttpPost]
        [RolClienteFilter]
        public IActionResult CambiarContrasenia(CambiarContraseniaViewModel vm)
        {
            try
            {
                object obj = new { Email = EmailActivo(), Actual = vm.Actual, Nueva = vm.Nueva };
                bool exito = false;

                string body = AuxClienteHttp.ObtenerBody("put", URLApi, obj, TokenActivo(), out exito);

                if (exito)
                {
                    ViewBag.Exito = "Contraseña modificada con exito";
                    ModelState.Clear();
                    return View();
                }
                else
                {
                    if (body.Contains("actual", StringComparison.OrdinalIgnoreCase))
                    {
                        ModelState.AddModelError("Actual", body);
                    }
                    else if (body.Contains("debe", StringComparison.OrdinalIgnoreCase) ||
                        body.Contains("no", StringComparison.OrdinalIgnoreCase))
                    {
                        ModelState.AddModelError("Nueva", body);
                    }
                    else
                    {
                        ViewBag.Error = body;
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "El servidor no responde, contacte con el administrador";
            }
            return View(vm);
        }

    }
}
