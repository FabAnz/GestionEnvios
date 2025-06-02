using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebCliente.DTOs;

namespace WebCliente.Controllers
{
    public class EnviosController : Controller
    {
        public string URLApi { get; set; }

        public EnviosController(IConfiguration config)
        {
            URLApi = config.GetValue<string>("URLApi") + "Envios/";
        }

        [HttpGet]
        public IActionResult BuscarEnvio()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BuscarEnvio(int nTracking)
        {
            HttpClient cliente = new HttpClient();

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
    }
}
