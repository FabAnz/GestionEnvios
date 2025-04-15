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
        public IListarEnviosEnProceso CUListarEnviosEnProceso { get; set; }
        public IListarAgencias CUListarAgencias { get; set; }
        public IListarVendedores CUListarVendedores { get; set; }
        public IAltaEnvio CUAltaEnvio { get; set; }
        public IBuscarEnvio CUBuscarEnvio { get; set; }
        public IFinalizarEnvio CUFinalizarEnvio { get; set; }
        public IBuscarUsuario CUBuscarUsuario { get; set; }
        public IBuscarAgencia CUBuscarAgencia { get; set; }

        public EnviosController(
            IListarEnviosEnProceso cuListarEnviosEnProceso,
            IListarAgencias cuListarAgencias,
            IListarVendedores cuListarVendedores,
            IAltaEnvio cuAltaEnvio,
            IBuscarUsuario cuBuscarUsuario,
            IBuscarAgencia cuBuscarAgencia,
            IBuscarEnvio cuBuscarEnvio,
            IFinalizarEnvio cuFinalizarEnvio
            )
        {
            CUListarEnviosEnProceso = cuListarEnviosEnProceso;
            CUListarAgencias = cuListarAgencias;
            CUListarVendedores = cuListarVendedores;
            CUAltaEnvio = cuAltaEnvio;
            CUBuscarUsuario = cuBuscarUsuario;
            CUBuscarAgencia = cuBuscarAgencia;
            CUBuscarEnvio = cuBuscarEnvio;
            CUFinalizarEnvio = cuFinalizarEnvio;
        }

        // GET: EnviosController
        [RolEmpleadoFilter]
        public ActionResult Index()
        {
            List<EnvioDTO> dtos = CUListarEnviosEnProceso.Listar();
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
            EnviosViewModel vm = new EnviosViewModel();
            vm.Agencias = CUListarAgencias.Listar();

            return View(vm);
        }

        // POST: EnviosController/Create
        [RolEmpleadoFilter]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EnviosViewModel vm)
        {
            try
            {
                vm.Agencias = CUListarAgencias.Listar();
                vm.Envio.Vendedor = CUBuscarUsuario.Buscar(int.Parse(HttpContext.Session.GetString("idUsuario")));
                if (vm.Envio.Agencia.Id != 0)
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

        // GET: EnviosController/Delete/5
        [RolEmpleadoFilter]
        public ActionResult Finalizar(int id)
        {
            EnvioDTO dto = CUBuscarEnvio.Buscar(id);
            return View(dto);
        }

        // POST: EnviosController/Delete/5
        [RolEmpleadoFilter]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Finalizar(int id, IFormCollection collection)
        {
            try
            {
                CUFinalizarEnvio.Finalizar(id);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Error = "Ocurrio un problema, contacte al administrador";
                return View();
            }
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
