using Autonoma.IOT.Common.Constants;
using Autonoma.IOT.Common.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Autonoma.IOT.WebApp.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// Ruta url del Api Rest
        /// </summary>
        protected string urlApiRest;

        /// <summary>
        /// Instancia para DesSerealizar un objeto o lista
        /// </summary>
        protected JavaScriptSerializer jsonSerializer;
        /// <summary>
        /// Instancia para consumir el Api rest
        /// </summary>
        protected HttpClient httpClient;

        /// <summary>
        /// Constructor
        /// </summary>
        /// 

      

        //protected ReferidoInformation SessionReferido = new ReferidoInformation();


        public BaseController()
        {

            this.urlApiRest = ConfigurationManager.AppSettings[Parameters.URL_API_REST].ToString();
            this.jsonSerializer = new JavaScriptSerializer();
            this.httpClient = new HttpClient();
            //httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko)Chrome / 58.0.3029.110 Safari / 537.36");
        }



        public ActionResult RedirectToLogin()
        {
            return Redirect(ConfigurationManager.AppSettings[Parameters.URL_LOGIN_POLIEDRO].ToString());
        }

        /// <summary>
        /// Convertir una cadena Json a un Modelo<T>
        /// </summary>
        /// <typeparam name="T">Modelo</typeparam>
        /// <param name="response">Cadena Json</param>
        /// <returns>List<T></returns>
        protected List<T> ConvertirJsonAListaModelo<T>(string response)
        {
            List<T> lista = new List<T>();
            lista = this.jsonSerializer.Deserialize<List<T>>(response);
            return lista;
        }

        /// <summary>
        /// Convertir una cadena Json a un Modelo<T> - NewtonJson
        /// </summary>
        /// <typeparam name="T">Modelo</typeparam>
        /// <param name="response">Cadena Json</param>
        /// <returns>List<T></returns>
        protected List<T> ConvertirNewtonJsonAListaModelo<T>(string response, string dateTimeFormat = "dd/MM/yyyy")
        {
            List<T> lista = new List<T>();
            lista = JsonConvert.DeserializeObject<List<T>>(response, new IsoDateTimeConverter { DateTimeFormat = dateTimeFormat });
            return lista;
        }

        /// <summary>
        /// Convertir un objeto Json a un Modelo
        /// </summary>
        /// <typeparam name="T">Modelo</typeparam>
        /// <param name="response">Cadena Json</param>
        /// <returns>Objeto T</returns>
        protected T ConvertirJsonAObjetoModelo<T>(string response)
        {
            T objeto;
            objeto = this.jsonSerializer.Deserialize<T>(response);
            return objeto;
        }

        /// <summary>
        /// Convertir una objeto Json a un Modelo - NewtonJson
        /// </summary>
        /// <typeparam name="T">Modelo</typeparam>
        /// <param name="response">Cadena Json</param>
        /// <returns>Objeto T</returns>
        protected T ConvertirNewtonJsonAObjetoModelo<T>(string response, string dateTimeFormat = "dd/MM/yyyy")
        {
            T objeto;
            objeto = JsonConvert.DeserializeObject<T>(response, new IsoDateTimeConverter { DateTimeFormat = dateTimeFormat });
            return objeto;
        }


    }
}