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
        public IActionResult BuescarEnvio()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BuescarEnvio(int nTracking)
        {
            HttpClient cliente = new HttpClient();

            try
            {
                Task<HttpResponseMessage> response = cliente.GetAsync(URLApi + nTracking);
                response.Wait();

                if (response.Result.IsSuccessStatusCode)
                {
                    Task<string> body = response.Result.Content.ReadAsStringAsync();
                    body.Wait();

                    EnvioDTO dto = JsonConvert.DeserializeObject<EnvioDTO>(body.Result);
                    return View(dto);
                }
                else
                {
                    ViewBag.Error = "El envio buscado no existe";
                }
            }catch(Exception ex)
            {
                ViewBag.Error = "Ocurrio un problema inesperado, contacte con el administrador";
            }


            return View();
        }
    }
}
