using Autonoma.IOT.WebApp.Controllers;
using Autonoma.IOT.WebApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Autonoma.IOT.WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //llamar a consulta de BD para obtener el valor de la llave de dispatchers
            //Application["LLAVE_DISPATCHERS"]= ",Dispatcher!Test$Key)2017.";
            try {
                DispatcherController dc = new DispatcherController();
                //string var = dc.generaLlave();
                string var = ",Dispatcher!Test$Key)2017.";
                if (var != "")
                {
                    Application["LLAVE_DISPATCHERS"] = var;
                }
                else
                {
                    throw new HttpException(
                "Error obteniendo llave de desencripción para los dispatchers");
                }
            } catch (Exception ex)
            {
                throw; 
                    }
           

            //aqui termina consulta del valor de la llavedis
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(ValidInteger), typeof(ValidIntegerValidator));
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(ValidDecimal), typeof(ValidDecimalValidator));
        }
    }
}
