using Autonoma.IOT.Common.Entities;
using Autonoma.IOT.Common.WebApiRespository;
using System;
using System.Threading.Tasks;

namespace Autonoma.IOT.Services.WebApp.ServiceAccess
{
    public class WebAppService: BaseService
    {

        public async Task<ConfiguracionHorario> GetConfiguracionHorario(int prototipo)
        {
            try
            {
                var url = urlApiRest + $"/api/AutonomaIOT/getConfiguracion?prototipo={prototipo}";
                var response = await WebApiServiceBase<ConfiguracionHorario>.WebApiGetCall(url, HttpClient);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

        }

        public async Task<ResultadoPeticion> setConfiguracionHorario(ConfiguracionHorario configuracionHorario)
        {
            try
            {
                var url = urlApiRest + $"/api/AutonomaIOT/setConfiguracionHorario";
                var response = await WebApiServiceBase<ResultadoPeticion>.WebApiPostCall(url, configuracionHorario, HttpClient);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

        }

        public async Task<MensajesConfiguracion> GetMensajesNotificacionPrototipo(int prototipo)
        {
            try
            {
                var url = urlApiRest + $"/api/AutonomaIOT/getMensajesNotificacionPrototipo?prototipo={prototipo}";
                var response = await WebApiServiceBase<MensajesConfiguracion>.WebApiGetCall(url, HttpClient);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

        }

        public async Task<bool> validarSesion(int prototipo, string token)
        {
            try
            {
                var url = urlApiRest + $"/api/AutonomaIOT/getValidarToken?prototipo={prototipo}&token={token}";
                var response = await WebApiServiceBase<bool>.WebApiGetCall(url, HttpClient);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

        }

        public async Task<EstadoPrototipo> getValidacionEstadoPrototipo(int prototipo)
        {
            try
            {
                var url = urlApiRest + $"/api/AutonomaIOT/getValidacionEstadoPrototipo?prototipo={prototipo}";
                var response = await WebApiServiceBase<EstadoPrototipo>.WebApiGetCall(url, HttpClient);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

        }

        public async Task<ResultadoPeticion> setEstadoPrototipo(EstadoPrototipo estadoPrototipo)
        {
            try
            {
                var url = urlApiRest + $"/api/AutonomaIOT/setEstadoPrototipo";
                var response = await WebApiServiceBase<ResultadoPeticion>.WebApiPostCall(url, estadoPrototipo, HttpClient);
                return response;                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

        }
    }
}