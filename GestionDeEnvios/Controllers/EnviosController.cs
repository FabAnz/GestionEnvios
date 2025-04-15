using CasosUso.DTOs;
using CasosUso.InterfacesCasosUso;
using ExcepcionesPropias.Excepciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentacion.Filters;
using Presentacion.Models;

namespace Presentacion.Controllers
{
    public class EnviosController : Controller
    {
        public IListarEnvios CUListarEnvios { get; set; }
        public IListarAgencias CUListarAgencias { get; set; }
        public IListarVendedores CUListarVendedores { get; set; }
        public IAltaEnvio CUAltaEnvio { get; set; }
        public IBuscarUsuario CUBuscarUsuario { get; set; }
        public IBuscarAgencia CUBuscarAgencia { get; set; }

        public EnviosController(
            IListarEnvios cuListarEnvios,
            IListarAgencias cuListarAgencias,
            IListarVendedores cuListarVendedores,
            IAltaEnvio cuAltaEnvio,
            IBuscarUsuario cuBuscarUsuario,
            IBuscarAgencia cuBuscarAgencia
            )
        {
            CUListarEnvios = cuListarEnvios;
            CUListarAgencias = cuListarAgencias;
            CUListarVendedores = cuListarVendedores;
            CUAltaEnvio = cuAltaEnvio;
            CUBuscarUsuario = cuBuscarUsuario;
            CUBuscarAgencia = cuBuscarAgencia;
        }

        // GET: EnviosController
        [RolEmpleadoFilter]
        public ActionResult Index()
        {
            List<EnvioDTO> dtos = CUListarEnvios.Listar();
            return View(dtos);
        }

        // GET: EnviosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EnviosController/Create
        [RolEmpleadoFilter]
        public ActionResult Create()
        {
            EnviosComunesViewModel vm = new EnviosComunesViewModel();
            vm.Agencias = CUListarAgencias.Listar();

            return View(vm);
        }

        // POST: EnviosController/Create
        [RolEmpleadoFilter]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EnviosComunesViewModel vm)
        {
            try
            {
                vm.Agencias = CUListarAgencias.Listar();
                vm.Envio.Vendedor = CUBuscarUsuario.Buscar(int.Parse(HttpContext.Session.GetString("idUsuario")));
                vm.Envio.Agencia = CUBuscarAgencia.Buscar(vm.Envio.Agencia.Id);

                CUAltaEnvio.Ejecutar(vm.Envio);

                return RedirectToAction(nameof(Index));
            }
            catch (DatosInvalidosException ex)
            {
                ViewBag.Error = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Ocurrio un problema, contacte al administrador";
            }
            return View(vm);
        }

        // GET: EnviosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EnviosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EnviosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EnviosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
