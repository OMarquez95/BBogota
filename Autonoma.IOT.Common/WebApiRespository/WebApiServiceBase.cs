namespace Autonoma.IOT.Common.WebApiRespository
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Script.Serialization;

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class WebApiServiceBase<T>
    {
        private const int RetryCount = 1;

        /// <summary>
        /// Webs the API post call.
        /// </summary>
        /// <typeparam name="G"></typeparam>
        /// <param name="uri">The URI.</param>
        /// <param name="entity">The entity.</param>
        /// <param name="client">The client.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<T> WebApiPostCall<G>(string uri, G entity, HttpClient client,
            CancellationToken cancellationToken)
        {
            var rta = await WebApiBasicPostCall(client, uri, new StringContent(new JavaScriptSerializer().Serialize(entity), Encoding.UTF8, "application/json"), cancellationToken);
            return ConvertResult(rta, uri);
        }

        public static async Task<T> WebApiPostCall<G>(string uri, G entity, HttpClient client)
        {
            return await WebApiPostCall(uri, entity, client, new CancellationToken());
        }

        public static async Task<T> WebApiGetPostCallMixMode(string uri, HttpClient client,
            CancellationToken cancellationToken, params object[] list)
        {
            JArray paramList = new JArray();
            foreach (object t in list)
                paramList.Add(t == null ? JsonConvert.SerializeObject(JValue.CreateNull()) : JsonConvert.SerializeObject(t));

            HttpResponseMessage rta = await WebApiBasicPostCall(client, uri, new StringContent(paramList.ToString(), Encoding.UTF8, "application/json"), cancellationToken);

            return ConvertResult(rta, uri);
        }

        public static async Task<T> WebApiGetPostCallMixMode(string uri, HttpClient client,
            params object[] list)
        {
            return await WebApiGetPostCallMixMode(uri, client, new CancellationToken(), list);
        }

        /// <summary>
        /// Webs the API get call.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <param name="client">The client.</param>
        /// <returns></returns
        public static async Task<T> WebApiGetCall(string uri, HttpClient client)
        {
            string trxId = client.DefaultRequestHeaders.Contains("trxId") ? client.DefaultRequestHeaders.GetValues("trxId").First() : "--";


            Trace.TraceInformation(string.Format("Traza {0} Solicitud API GET {1}", trxId, uri));
            var rta = await client.GetAsync(uri);
            if (rta.StatusCode == System.Net.HttpStatusCode.NotModified)
                Trace.TraceInformation(string.Format("Traza {0} Respuesta API GET {1} desde cache.", trxId, uri));
            else
                Trace.TraceInformation(string.Format("Traza {0} Respuesta {1} GET {2}.", trxId, (int)rta.StatusCode, uri));
            return ConvertResult(rta, uri);
        }


        /// <summary>
        /// Call a Web Api POST Verb with content
        /// </summary>
        /// <param name="client">The client.</param>
        /// <param name="uri">The URI.</param>
        /// <param name="content"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private static async Task<HttpResponseMessage> WebApiBasicPostCall(HttpClient client, string uri,
                                                       HttpContent content,
                                                       CancellationToken cancellationToken)
        {
            Trace.TraceInformation($"Solicitud API POST {uri}");
            HttpResponseMessage getAsyncTask;

            getAsyncTask = await Task<HttpResponseMessage>.Factory.StartNew(() =>
                                                        client.PostAsync(uri, content, cancellationToken).Result, cancellationToken);

            if (getAsyncTask.StatusCode == HttpStatusCode.RequestTimeout)
            {
                Trace.TraceInformation($"Reintento Solicitud API POST {uri}");
                return await WebApiBasicPostCall(client, uri, content, cancellationToken);
            }

            Trace.TraceInformation($"Respuesta {(int)getAsyncTask.StatusCode} POST {uri}.");
            return getAsyncTask;
        }

        /// <summary>
        /// Converts the result.
        /// </summary>
        /// <param name="rta">The rta.</param>
        /// <param name="url"></param>
        /// <returns></returns>
        private static T ConvertResult(HttpResponseMessage rta, string url)
        {
            try
            {
                ValidateWebapiResponse(rta);
                var stringResult = rta.Content.ReadAsStringAsync().Result;
                T result = JsonConvert.DeserializeObject<T>(stringResult);
                return result;
            }
            catch (Exception exception)
            {
                throw new Exception("Error :" + exception);
            }
        }

        private static void ValidateWebapiResponse(HttpResponseMessage rta)
        {
            switch (rta.StatusCode)
            {
                case HttpStatusCode.Continue:
                case HttpStatusCode.OK:
                    return;
                case HttpStatusCode.SwitchingProtocols:
                case HttpStatusCode.Created:
                case HttpStatusCode.Accepted:
                case HttpStatusCode.NonAuthoritativeInformation:
                case HttpStatusCode.NoContent:
                case HttpStatusCode.ResetContent:
                case HttpStatusCode.PartialContent:
                case HttpStatusCode.MultipleChoices:
                case HttpStatusCode.MovedPermanently:
                case HttpStatusCode.Found:
                case HttpStatusCode.SeeOther:
                case HttpStatusCode.NotModified:
                case HttpStatusCode.UseProxy:
                case HttpStatusCode.Unused:
                case HttpStatusCode.TemporaryRedirect:
                case HttpStatusCode.PaymentRequired:
                case HttpStatusCode.Forbidden:
                case HttpStatusCode.MethodNotAllowed:
                case HttpStatusCode.NotAcceptable:
                case HttpStatusCode.ProxyAuthenticationRequired:
                case HttpStatusCode.Conflict:
                case HttpStatusCode.Gone:
                case HttpStatusCode.LengthRequired:
                case HttpStatusCode.PreconditionFailed:
                case HttpStatusCode.RequestEntityTooLarge:
                case HttpStatusCode.RequestUriTooLong:
                case HttpStatusCode.UnsupportedMediaType:
                case HttpStatusCode.RequestedRangeNotSatisfiable:
                case HttpStatusCode.ExpectationFailed:
                case HttpStatusCode.UpgradeRequired:
                case HttpStatusCode.BadGateway:
                case HttpStatusCode.ServiceUnavailable:
                case HttpStatusCode.GatewayTimeout:
                case HttpStatusCode.HttpVersionNotSupported:
                    throw new ArgumentOutOfRangeException(nameof(rta), $"Unexpected status code ({rta.StatusCode})");
                case HttpStatusCode.BadRequest:
                    throw new WebException();
                case HttpStatusCode.Unauthorized:
                    throw new ArgumentOutOfRangeException(nameof(rta), $"Unexpected status code ({rta.StatusCode})");
                case HttpStatusCode.NotFound:
                    throw new ArgumentOutOfRangeException(nameof(rta), $"Unexpected status code ({rta.StatusCode})");
                case HttpStatusCode.RequestTimeout:
                    throw new TimeoutException();
                case HttpStatusCode.InternalServerError:
                    throw new ArgumentOutOfRangeException(nameof(rta), $"Unexpected status code ({rta.StatusCode})");
                case HttpStatusCode.NotImplemented:
                    throw new ArgumentOutOfRangeException(nameof(rta), $"Unexpected status code ({rta.StatusCode})");
                default:
                    throw new ArgumentOutOfRangeException(nameof(rta), $"Unexpected status code ({rta.StatusCode})");
            }
        }

    }
}
