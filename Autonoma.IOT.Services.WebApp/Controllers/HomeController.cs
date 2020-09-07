using Autonoma.IOT.Services.WebApp.ServiceAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Autonoma.IOT.Services.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly WebAppService _webAppService;

        public HomeController()
        {
            _webAppService = new WebAppService();
        }

        // agregar en los demás metodos  [FiltrosAccion]
        public async Task<ActionResult> Index(int? prototipo, string token)
        {
            bool sesion = false;
            if (prototipo == null || token == null)
            {
                if (Session["prototipo"] == null || Session["token"] == null)
                {
                    return RedirectToAction("SesionExpirada");
                }
                else
                {
                     sesion = await validaSesion((int)Session["prototipo"],(string)Session["token"]);
                    if (!sesion)
                    {
                        return RedirectToAction("SesionExpirada");
                    }
                    else
                    {
                        return View();
                    }
                }
            }
            else
            {
                sesion = await validaSesion((int)prototipo, token);
                if (!sesion)
                {
                    return RedirectToAction("SesionExpirada");
                }
                else
                {
                    Session["prototipo"] = prototipo;
                    Session["token"] = token;
                    return View();

                }
            }
        } 

        [FiltrosAccion]
        public ActionResult RedireccionMenu(string opcionMenu)
        {
            switch (opcionMenu)
            {
                case "ActionOne":
                    return RedirectToAction("CambiarHorario","TheDogChef");
                case "ActionTwo":
                    return RedirectToAction("CambiarEstado", "TheDogChef");
                case "ActionThree":
                    return RedirectToAction("VerificarMensajes", "TheDogChef");                    
                default:
                    return null;
            }

        }

        public ActionResult SesionExpirada()
        {
            return View();
        }        

        private async Task<bool> validaSesion(int prototipo, string token)
        {
            try
            {
                return true;
                return await _webAppService.validarSesion(prototipo, token);               
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}