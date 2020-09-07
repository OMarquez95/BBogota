using Autonoma.IOT.Common.Entities;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Autonoma.IOT.Services.WebApi.Controllers
{
    public class AutonomaIotController : BaseApiController
    {
        #region Atributos

        #endregion

        #region Metodos Publicos

        
        [Route("api/AutonomaIOT/getValidarToken")]
        public HttpResponseMessage getValidarToken([FromUri]int prototipo, [FromUri]string token)
        {
            try
            {
                var BObject = AutonomaIotBL.ValidarToken(token,prototipo);
                return Request.CreateResponse(HttpStatusCode.OK, BObject);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        [Route("api/AutonomaIOT/getValidacionCredenciales")]
        public HttpResponseMessage getValidaSesion([FromUri]Usuario usuario)
        {
            try
            {
                var BObject = AutonomaIotBL.ValidarCredenciales(usuario);
                return Request.CreateResponse(HttpStatusCode.OK, BObject);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        [Route("api/AutonomaIOT/getValidacionEstadoPrototipo")]
        public HttpResponseMessage getValidaEstadoPrototipo([FromUri]int prototipo)
        {
            try
            {
                var BObject = AutonomaIotBL.ConsultarEstadoPrototipo(prototipo);
                return Request.CreateResponse(HttpStatusCode.OK, BObject);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        [Route("api/AutonomaIOT/getConfiguracion")]
        public HttpResponseMessage getConfiguracion([FromUri]int prototipo)
        {
            try
            {
                var BObject = AutonomaIotBL.ObtenerConfiguracion(prototipo);
                return Request.CreateResponse(HttpStatusCode.OK, BObject);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        [Route("api/AutonomaIOT/getMensajesNotificacionPrototipo")]
        public HttpResponseMessage getMensajesNotificacionPrototipo([FromUri]int prototipo)
        {
            try
            {
                var BObject = AutonomaIotBL.ConsultarNotificaciones(prototipo);
                return Request.CreateResponse(HttpStatusCode.OK, BObject);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        [Route("api/AutonomaIOT/setEstadoPrototipo")]
        [HttpPost]
        public HttpResponseMessage setEstadoPrototipo([FromBody]EstadoPrototipo estadoPototipo)
        {
            try
            {
                var obj = AutonomaIotBL.ActualizarEstadoPrototipo(estadoPototipo);
                return Request.CreateResponse(HttpStatusCode.OK, obj);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        [Route("api/AutonomaIOT/setConfiguracionHorario")]
        [HttpPost]
        public HttpResponseMessage setConfiguracionHorario([FromBody]ConfiguracionHorario configuracionHorario)
        {
            try
            {
                var obj = AutonomaIotBL.ActualizarConfiguracion(configuracionHorario);
                return Request.CreateResponse(HttpStatusCode.OK, obj);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

        }        

        [Route("api/AutonomaIOT/setMensajePrototipo")]
        [HttpPost]
        public HttpResponseMessage setMensajePrototipo([FromBody]InsertarMensajePrototipo InsertarMensajePrototipo)
        {
            try
            {                
                var obj = AutonomaIotBL.InsertarNotificaciones(InsertarMensajePrototipo);
                return Request.CreateResponse(HttpStatusCode.OK, obj);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

        }        
        #endregion
    }
}
