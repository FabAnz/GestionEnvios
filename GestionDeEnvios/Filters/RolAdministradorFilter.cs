using CasosUso.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Presentacion.Filters
{
    public class RolAdministradorFilter : ActionFilterAttribute
    {
        public int MyProperty { get; set; }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string rol = context.HttpContext.Session.GetString("rol");

            if (rol != "Administrador")
            {
                context.Result = new RedirectToActionResult("Login", "Usuarios", new { mensaje = "No tiene permiso para acceder a la sección" });
            }
            base.OnActionExecuting(context);
        }
    }
}

