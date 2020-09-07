using Autonoma.IOT.Common.Constants;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Autonoma.IOT.WebApp.ServiceLayer
{
    public abstract class BaseService// : IDisposable
    {
        protected static readonly HttpClient HttpClient;
        private static object syncRoot = new Object();
        protected static string urlApiRest;

        static BaseService()
        {
            urlApiRest = ConfigurationManager.AppSettings[Parameters.URL_API_REST].ToString();

            if (HttpClient == null)
            {
                lock (syncRoot)
                {
                    if (HttpClient == null)
                    {
                        HttpClient = new HttpClient();
                        HttpClient.BaseAddress = new Uri(ConfigurationManager.AppSettings[Parameters.URL_API_REST]);
                        HttpClient.DefaultRequestHeaders.Accept.Clear();
                        HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        HttpClient.Timeout = new TimeSpan(0, 30, 0);
                        //if (Session["SesssionGuid"] != null)
                        HttpClient.DefaultRequestHeaders.Add("trxId", Guid.NewGuid().ToString());
                    }
                }
            }
            //HttpClient.Dispose();
        }

    }
}