using CasosUso.DTOs;
using CasosUso.InterfacesCasosUso;
using ExcepcionesPropias.Excepciones;
using LogicaNegocio.EntidadesDominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentacion.Filters;

namespace Presentacion.Controllers
{
    public class UsuariosController : Controller
    {
        public ILogin CULogin { get; set; }
        public IListarUsuarios CUListarUsuarios { get; set; }
        public IAltaUsuario CUAltaUsuario { get; set; }
        public IListarRoles CUListarRoles { get; set; }
        public IBuscarRol CUBuscarRol { get; set; }

        public UsuariosController(
            ILogin cuLogin,
            IListarUsuarios cuListarUsuarios,
            IAltaUsuario cuAltaUsuario,
            IListarRoles cuListarRoles,
            IBuscarRol cuBuscarRol
            )
        {
            CULogin = cuLogin;
            CUListarUsuarios = cuListarUsuarios;
            CUAltaUsuario = cuAltaUsuario;
            CUListarRoles = cuListarRoles;
            CUBuscarRol = cuBuscarRol;
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
        [RolAdministradorFilter]
        public ActionResult Create()
        {
            UsuarioDTO dto = new UsuarioDTO();
            dto.Roles = CUListarRoles.Listar();
            return View(dto);
        }

        // POST: UsuariosController/Create
        [RolAdministradorFilter]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioDTO dto)
        {
            try
            {
                dto.Roles = CUListarRoles.Listar();
                dto.Rol.Nombre = CUBuscarRol.Buscar(dto.Rol.Id).Nombre;
                int idUsuarioActivo = int.Parse(HttpContext.Session.GetString("idUsuario"));
                CUAltaUsuario.EjecutarAlta(dto, idUsuarioActivo);
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
            return View(dto);

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
