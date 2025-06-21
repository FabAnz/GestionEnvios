using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebCliente.DTOs;
using WebCliente.Filters;
using WebCliente.Models;

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

                string body = AuxClienteHttp.ObtenerBody("get", $"{URLApi}{nTracking}", null, null, out exito);

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
        public IActionResult Index(DateTime? fInicio, DateTime? fFin, string? estado, string? comentario)
        {
            EnviosViewModel vm = new EnviosViewModel()
            {
                FInicio = fInicio,
                FFin = fFin,
                Estado = estado,
                Comentario = comentario
            };

            try
            {
                bool exito = false;
                string body = AuxClienteHttp.ObtenerBody("get", UrlConFiltros(vm), null, TokenActivo(), out exito);

                if (exito)
                {
                    vm.Envios = JsonConvert.DeserializeObject<List<EnvioDTO>>(body);
                    return View(vm);
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

        [HttpPost]
        [RolClienteFilter]
        public IActionResult BuscarEnvios(EnviosViewModel vm)
        {
            return RedirectToAction("Index", new
            {
                fInicio = vm.FInicio?.ToString("yyyy-MM-dd"),
                fFin = vm.FFin?.ToString("yyyy-MM-dd"),
                estado = vm.Estado,
                comentario = vm.Comentario
            });
        }

        private string UrlConFiltros(EnviosViewModel vm)
        {
            string filtros = "";
            if (vm.FInicio != null)
                filtros += "fInicio=" + vm.FInicio?.ToString("yyyy/MM/dd");
            if (vm.FFin != null)
                filtros += (string.IsNullOrEmpty(filtros) ? "" : "&") + "fFin=" + vm.FFin?.ToString("yyyy/MM/dd");
            if (!string.IsNullOrEmpty(vm.Estado))
                filtros += (string.IsNullOrEmpty(filtros) ? "" : "&") + "estado=" + vm.Estado;
            if (!string.IsNullOrEmpty(vm.Comentario))
                filtros += (string.IsNullOrEmpty(filtros) ? "" : "&") + "comentario=" + vm.Comentario;

            string url = URLApi + (!string.IsNullOrEmpty(filtros) ? "?" + filtros : "");

            return url;
        }

        [HttpGet]
        [RolClienteFilter]
        public IActionResult Detalle(int nTracking, DateTime? fInicio, DateTime? fFin, string? estado, string? comentario)
        {
            ViewBag.FInicio = fInicio;
            ViewBag.FFin = fFin;
            ViewBag.Estado = estado;
            ViewBag.Comentario = comentario;

            try
            {
                bool exito = false;
                string body = AuxClienteHttp.ObtenerBody("get", URLApi + "detalle/" + nTracking, null, TokenActivo(), out exito);

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
