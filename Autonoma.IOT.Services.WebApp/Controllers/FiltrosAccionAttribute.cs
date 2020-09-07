using System;
using System.Web;
using System.Web.Mvc;

namespace Autonoma.IOT.Services.WebApp.Controllers
{
    public class FiltrosAccionAttribute : ActionFilterAttribute
    {

        //filtro para cada metodo y validar token valido y prototipo
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {                
                if (HttpContext.Current.Session["prototipo"] == null || HttpContext.Current.Session["token"] == null)
                {
                    filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary {
                        {"Controller", "Home"},
                        {"Action", "SesionExpirada"}
                    });
                }
                base.OnActionExecuting(filterContext);
            }            
            catch (Exception ex)
            {
                throw new Exception(ex.Message+" Ocurrió un error, intente nuevamente");
            }
            // The action filter logic.
        }
    }
}