using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Autonoma.IOT.WebApp.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            if (!string.IsNullOrEmpty((string)Session["sesion"]))
            {
                if ((string)Session["sesion"] != "true")
                {
                    RedirectToLogin();
                }
            }
            return View();
        }

        public ActionResult Ejemplos()
        {

            return View();
        }
    }
}