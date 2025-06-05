using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebCliente.DTOs;
using WebCliente.Filters;

namespace WebCliente.Controllers
{
    public class EnviosController : Controller
    {
        public string URLApi { get; set; }

        public EnviosController(IConfiguration config)
        {
            URLApi = config.GetValue<string>("URLApi") + "Envios/";
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
        public IActionResult BuscarEnvio()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BuscarEnvio(int nTracking)
        {
            try
            {
                bool exito = false;

                string body = AuxClienteHttp.ObtenerBody("get", URLApi + nTracking, null, null, out exito);

                if (exito)
                {
                    EnvioDTO dto = JsonConvert.DeserializeObject<EnvioDTO>(body);
                    return View(dto);
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


            return View();
        }

        [HttpGet]
        [RolClienteFilter]
        public IActionResult Index()
        {
            try
            {
                bool exito = false;
                string body = AuxClienteHttp.ObtenerBody("post", URLApi, EmailActivo(), TokenActivo(), out exito);

                if (exito)
                {
                    List<EnvioDTO> dto = JsonConvert.DeserializeObject<List<EnvioDTO>>(body);
                    return View(dto);
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
            return View();
        }
    }
}
