using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebCliente.Filters
{
    public class RolClienteFilter:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string rol = context.HttpContext.Session.GetString("rol");

            if (rol != "Cliente")
            {
                context.Result = new RedirectToActionResult("Logout", "Usuarios", new { error = "No tiene permiso para acceder a la sección" });
            }
            base.OnActionExecuting(context);
        }
    }
}
