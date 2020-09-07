using Autonoma.IOT.Common.Constants;
using Autonoma.IOT.WebApp.Models;
using Autonoma.IOT.WebApp.Models.ValidacionRechazo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Configuration;

namespace Autonoma.IOT.WebApp.Controllers
{
    public class DispatcherController : BaseController
    {
        /// <summary>
        /// Metodo Dummy para inicios de sesion
        /// </summary>
        /// <returns></returns>
        
            
        public ActionResult Index()
        {
            Session["dummy"] = "TRUE";
            return View();
        }
        

        /// <summary>
        /// Formulario de Activacion Pospago
        /// </summary>
        [HttpGet]
        public string generaLlave() {
            LlaveDispatchersModel model;
            string response;

            model = new LlaveDispatchersModel();

            try
            {
                using (this.httpClient)
                {
                    Uri uri = new Uri(this.urlApiRest + Parameters.URL_LLAVE_DISPATCHERS + "?nombre=" + ConfigurationManager.AppSettings[Parameters.LLAVE_DISPATCHERS].ToString());
                    response = httpClient.GetStringAsync(uri).Result;
                    model = this.ConvertirJsonAObjetoModelo<LlaveDispatchersModel>(response);
                }
                if (string.IsNullOrEmpty(model.VALOR))
                {
                    return "";
                }
                else {
                    return model.VALOR;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        //DispatcherEntrada
        public ActionResult ValidaSesion() {
            try
            {
                if (Request.Form["varSession"] != null)
                {
                    Session["sesion"] = Request.Form["varSession"];
                }
                else
                {
                    return Redirect(ConfigurationManager.AppSettings[Parameters.URL_LOGIN_POLIEDRO].ToString());
                }
                if (Request.Form["varServidor"]!=null)
                    Session["servidor"] = Request.Form["varServidor"];
                Session["EstadoSesion"] = "false";
                //DECODIFICAR LA SESION
                String info = (String)Session["sesion"]; // Server.HtmlDecode(Request.Form.Get(SessionKey.VarSession));
                info = Server.HtmlDecode(info);                                         //String sessionVars = Server.HtmlDecode(Request.Form.Get(SessionKey.VarSession));
                string llave = HttpContext.Application["LLAVE_DISPATCHERS"] as string;
                DecodeSessionVar(info);
                if((string)Session["EstadoSesion"]=="true")
                return RedirectToAction("Index", "Home");
                return Redirect(ConfigurationManager.AppSettings[Parameters.URL_LOGIN_POLIEDRO].ToString());
            }
            catch (Exception ex) {
                return Redirect(ConfigurationManager.AppSettings[Parameters.URL_LOGIN_POLIEDRO].ToString());
            }
        }

        //DispatcherSalida
        public ActionResult SalirRechazos()
        {
            try
            {
                if (Session["sesion"] != null)
                {
                    DispatcherModel dm =new DispatcherModel();
                    dm.sesion = (string)Session["sesion"];
                    if (Session["servidor"] != null)
                    {
                        //falta saber el servicio, debe cambiarse DispatcherSalida por el pertinente
                        dm.urlReturn = string.Format("{0}/"+ ConfigurationManager.AppSettings[Parameters.URL_RETURN_POLIEDRO].ToString(), (string)Session["servidor"]);
                    }
                    else {
                        dm.urlReturn = ConfigurationManager.AppSettings[Parameters.URL_LOGIN_POLIEDRO].ToString();
                    }
                    Session.Clear();
                    Session.Abandon();
                    return View(dm);
                }
                else
                {
                    return Redirect(ConfigurationManager.AppSettings[Parameters.URL_LOGIN_POLIEDRO].ToString());
                }
               
            }
            catch (Exception ex)
            {
                return Redirect(ConfigurationManager.AppSettings[Parameters.URL_LOGIN_POLIEDRO].ToString());
            }
        }


        public void DecodeSessionVar(String sessionString)
        {
            Dictionary<String, String> sessionVars = new Dictionary<string, string>();
            try
            {
                String decrypt = DecryptSessionVar(sessionString);
                sessionVars = SplitDecodedSessionIntoDictionary(decrypt);

                //debe cambiarse por con (!ValidTimeStamp(sessionVars["TimeStamp"])) para no usar dummys
                if((string)Session["dummy"] != "TRUE")
                {
                    if (!ValidTimeStamp(sessionVars["TimeStamp"]))
                    {
                        Session["EstadoSesion"] = "false";
                        return;
                    }
                }
                
                AsignarVariables(sessionVars, decrypt);
            }
            catch (Exception e)
            {

            }

        }


        public void AsignarVariables(Dictionary<String, String> vars, String sessionVars)
        {
            Session["VarSession"] = sessionVars;
            foreach (String key in vars.Keys)
            {
                switch (key)
                {
                    case "usuario": Session["VarUsuario"] = vars[key]; break;
                    case "grp_priv": Session["VarPrivilegios"] = vars[key]; break;
                    case "codigo_distribuidor":
                        Session["VarCodigoDistribuidor"] = vars[key];
                        Session["VarCodigo_distribuidor"] = vars[key];
                        break;
                    case "nombresAESP": Session["VarNombresAESP"] = vars[key]; break;
                    case "nombresGPRS": Session["VarNombresGPRS"] = vars[key]; break;
                    case "nombresSNGIA": Session["VarNombresSNGIA"] = vars[key]; break;
                    case "numero_documentoGPRS": Session["VarNumeroDocumentoGPRS"] = vars[key]; break;
                    case "numero_documentoAESP": Session["VarNumeroDocumentoAESP"] = vars[key]; break;
                    case "numero_documentoSNGIA": Session["VarNumeroDocumentoSNGIA"] = vars[key]; break;
                    case "numero_documentoSinergia": Session["VarNumeroDocumentoSinergia"] = vars[key]; break;
                    case "UsuMod": Session["VarUsuMod"] = vars[key]; break;
                    case "NumeroMinActivacion": Session["VarNumeroMinActivacion"] = vars[key]; break;
                    case "numero_documentoActivacion": Session["VarNumeroDocumentoActivacion"] = vars[key]; break;
                    case "ApellidoActivacion": Session["VarApellidoActivacion"] = vars[key]; break;
                    case "NumeroMinSinergia": Session["VarNumeroMinSinergia"] = vars[key]; break;
                    //case "": Session["VarFlagPiloto"] = vars[key]; break; //No se encuentra
                    case "sitio": Session["IdSitio"] = vars[key]; break; //No se encuentra
                    case "Servidor": HttpContext.Application["VarServidor"] = vars[key]; break; //No se encuentra

                }
            }
            if (string.IsNullOrEmpty((string)Session["VarUsuario"]) | string.IsNullOrEmpty((string)Session["VarCodigoDistribuidor"]))
            {
                Session["EstadoSesion"] = "false";
            }else
            {
                Session["EstadoSesion"] = "true";
            }
        }

        public Dictionary<String, String> SplitDecodedSessionIntoDictionary(String decodedSessionString)
        {
            Dictionary<String, String> retVal = new Dictionary<String, String>();
            String[] piezas = decodedSessionString.Split(new string[] { "|||" }, StringSplitOptions.None);
            for (int i = 0; i < piezas.Length; i++)
            {
                try
                {
                    String nombrePar = piezas[i].Substring(0, piezas[i].IndexOf("==="));
                    String valor = piezas[i].Substring(piezas[i].IndexOf("===") + 3);
                    retVal.Add(nombrePar, valor);
                }
                catch (Exception e)
                {

                }
            }
            return retVal;
        }
        public String DecryptSessionVar(String sessionVar)
        {
            //Claro.Cryptography.CryptographyWrapper cw = new CryptographyWrapper();
            ////DemographicsFacade df = new DemographicsFacade();
            //// String key = DevolverParametro("LLAVE_DISPATCHERS");
            //String key = HttpContext.Application["LLAVE_DISPATCHERS"] as string;
            //return cw.DecryptPassAES(sessionVar, key);


            return "";
        }
        public DateTime TimeStampToDate(String timeStamp)
        {
            DateTime dt = new DateTime(int.Parse(timeStamp.Substring(0, 4)),
                int.Parse(timeStamp.Substring(4, 2)), int.Parse(timeStamp.Substring(6, 2)),
                int.Parse(timeStamp.Substring(8, 2)), int.Parse(timeStamp.Substring(10, 2)),
                int.Parse(timeStamp.Substring(10, 2)));
            return dt;
        }
        public bool ValidTimeStamp(String timeStamp)
        {
            DateTime ts = TimeStampToDate(timeStamp);
            if (ts < DateTime.Now) return false;
            return true;
        }


        /*
        private String DevolverParametro(String parametro)
        {
            String retVal = Application["LLAVE_DISPATCHERS"];//(String)Application[parametro];
            if (retVal == null || retVal == "")
            {
                using (DemographicsFacade df = new DemographicsFacade())
                    retVal = df.GetBasicType(
                        Comcel.Pol.Presentacion.GuiProcessComponent.DemographicsProxy.BasicTypeEnum.GlobalParameters).
                        Find(p => p.TypeId == parametro).TypeName;
                Application["LLAVE_DISPATCHERS"] = retVal;

#if DEBUG
                using (StreamWriter writer = new StreamWriter(@"d:\ArchivosCache\LOG_DISPATCHER.txt", true))
                    writer.WriteLine("[" + DateTime.Now.ToString() + "] Cargado de BD " + parametro + ": " + retVal);
#endif
    }
            return retVal;
        }
    */
    }
}