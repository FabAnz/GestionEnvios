using AccesoDatos.Repositorios;
using CasosUso.DTOs;
using CasosUso.InterfacesCasosUso;
using ExcepcionesPropias.Excepciones;
using Humanizer;
using LogicaNegocio.EntidadesDominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using Presentacion.Filters;
using Presentacion.Models;

namespace Presentacion.Controllers
{
    public class UsuariosController : Controller
    {
        public ILogin CULogin { get; set; }
        public IListarUsuarios CUListarUsuarios { get; set; }
        public IAltaUsuario CUAltaUsuario { get; set; }
        public IListarRoles CUListarRoles { get; set; }
        public IBuscarRol CUBuscarRol { get; set; }
        public IBuscarUsuario CUBuscarUsuario { get; set; }
        public IModificarUsuario CUModificarUsuario { get; set; }
        public IBajaUsuario CUBajaUsuario { get; set; }

        public UsuariosController(
            ILogin cuLogin,
            IListarUsuarios cuListarUsuarios,
            IAltaUsuario cuAltaUsuario,
            IListarRoles cuListarRoles,
            IBuscarRol cuBuscarRol,
            IBuscarUsuario cuBuscarUsuario,
            IModificarUsuario cuModificarUsuario,
            IBajaUsuario cuBajaUsuario
            )
        {
            CULogin = cuLogin;
            CUListarUsuarios = cuListarUsuarios;
            CUAltaUsuario = cuAltaUsuario;
            CUListarRoles = cuListarRoles;
            CUBuscarRol = cuBuscarRol;
            CUBuscarUsuario = cuBuscarUsuario;
            CUModificarUsuario = cuModificarUsuario;
            CUBajaUsuario = cuBajaUsuario;
        }

        private UsuarioDTO UsuarioActivo()
        {
            int idUsuario = int.Parse(HttpContext.Session.GetString("idUsuario"));
            return CUBuscarUsuario.Buscar(idUsuario);
        }

        //GET: UsuariosController/Login
        public ActionResult Login(string mensaje)
        {
            HttpContext.Session.SetString("idUsuario", "");
            HttpContext.Session.SetString("rol", "");
            ViewBag.Mensaje = mensaje;
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
                ViewBag.Mensaje = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Ocurrio un problema, contacte al administrador";
            }
            return View(dto);
        }

        //GET: UsuariosController/Logout
        public ActionResult Logout()
        {
            return RedirectToAction(nameof(Login));
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
            UsuarioRolesViewModel vm = new UsuarioRolesViewModel();
            vm.Roles = CUListarRoles.Listar();
            return View(vm);
        }

        // POST: UsuariosController/Create
        [RolAdministradorFilter]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioRolesViewModel vm)
        {
            try
            {
                vm.Roles = CUListarRoles.Listar();
                vm.Usuario.Rol.Nombre = CUBuscarRol.Buscar(vm.Usuario.Rol.Id).Nombre;
                CUAltaUsuario.EjecutarAlta(vm.Usuario, UsuarioActivo());
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

        // GET: UsuariosController/Edit/5
        [RolAdministradorFilter]
        public ActionResult Edit(int id)
        {
            UsuarioRolesViewModel vm = new UsuarioRolesViewModel();
            vm.Usuario = CUBuscarUsuario.Buscar(id);
            vm.Roles = CUListarRoles.Listar();
            return View(vm);
        }

        // POST: UsuariosController/Edit/5
        [RolAdministradorFilter]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuarioRolesViewModel vm)
        {
            try
            {
                vm.Roles = CUListarRoles.Listar();
                vm.Usuario.Rol.Nombre = CUBuscarRol.Buscar(vm.Usuario.Rol.Id).Nombre;
                CUModificarUsuario.Modificar(vm.Usuario, UsuarioActivo());
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

        // GET: UsuariosController/Delete/5
        [RolAdministradorFilter]
        public ActionResult Delete(int id)
        {
            UsuarioDTO dto = CUBuscarUsuario.Buscar(id);
            if (dto == null)
                throw new DatosInvalidosException("El usuario no existe");

            return View(dto);
        }

        // POST: UsuariosController/Delete/5
        [RolAdministradorFilter]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                int idUsuarioActivo = UsuarioActivo().Id;
                CUBajaUsuario.EjecutarBaja(id, UsuarioActivo());
                if (id == idUsuarioActivo)
                    return RedirectToAction(nameof(Login), new { mensaje = "Elimino su usuario con éxito" });
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Ocurrio un problema, contacte al administrador";
                return View();
            }
        }
    }
}
