using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Presentacion.Filters
{
    public class RolEmpleadoFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string rol = context.HttpContext.Session.GetString("rol");

            if (rol != "Administrador" && rol != "Funcionario")
            {
                context.Result = new RedirectToActionResult("Login", "Usuarios", new { mensaje = "No tiene permiso para acceder a la sección" });
            }
            base.OnActionExecuting(context);
        }
    }
}
