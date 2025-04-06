using CasosUso.DTOs;
using CasosUso.InterfacesCasosUso;
using ExcepcionesPropias.Excepciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentacion.Filters;

namespace Presentacion.Controllers
{
    public class UsuariosController : Controller
    {
        public ILogin CULogin { get; set; }
        public IListarUsuarios CUListarUsuarios { get; set; }

        public UsuariosController(
            ILogin cuLogin,
            IListarUsuarios cUListarUsuarios
            )
        {
            CULogin = cuLogin;
            CUListarUsuarios = cUListarUsuarios;
        }

        //GET: UsuariosController/Login
        public ActionResult Login(string error)
        {
            HttpContext.Session.SetString("idUsuario", "");
            HttpContext.Session.SetString("rol", "");
            ViewBag.Error = error;
            return View();
        }

        //POST: UsuariosController/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UsuarioLoginDTO dto)
        {
            try
            {
                UsuarioLoginDTO usuario = CULogin.VerificarCredenciales(dto);
                HttpContext.Session.SetString("idUsuario", usuario.Id.ToString());
                HttpContext.Session.SetString("rol", usuario.Rol);
                if (usuario.Rol == "Administrador")
                    return RedirectToAction(nameof(Index));
                return View();
            }
            catch (DatosInvalidosException ex)
            {
                ViewBag.Error = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Ocurrio un problema, contacte al administrador";
            }
            return View(dto);
        }


        // GET: UsuariosController
        [RolAdministradorFilter]
        public ActionResult Index()
        {
            List<UsuarioDTO> dtos = CUListarUsuarios.Listar();
            return View(dtos);
        }

        // GET: UsuariosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsuariosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuariosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: UsuariosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsuariosController/Edit/5
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

        // GET: UsuariosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuariosController/Delete/5
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
