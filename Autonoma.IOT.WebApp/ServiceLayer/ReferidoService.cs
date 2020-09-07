using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Autonoma.IOT.Common.Constants;
using Autonoma.IOT.Common.Entities;
using Autonoma.IOT.Common.WebApiRespository;
using Autonoma.IOT.WebApp.Models.Entities;

namespace Autonoma.IOT.WebApp.ServiceLayer
{
    public class ReferidoService : BaseService
    {
        //public async Task<ValidacionOperadorDonante> ValidateOperator(string min)
        //{
        //    var url = ConfigurationManager.AppSettings["urlApiRest"] +$"/api/recuperacion/getValidacionOperadorDonante?min={min}";
        //    var response = await WebApiServiceBase<ValidacionOperadorDonante>.WebApiGetCall(url, HttpClient);
        //    return response;
        //}

        //public async Task<Referente> GetReferente(string min)
        //{
        //    var url = ConfigurationManager.AppSettings["urlApiRest"] + $"/api/recuperacion/getReferidos?min={min}";
        //    var response = await WebApiServiceBase<Referente>.WebApiGetCall(url, HttpClient);
        //    return response;
        //}

        //public async Task<string> saveChanges(Referente referente)
        //{
        //    var url = ConfigurationManager.AppSettings["urlApiRest"] + $"/api/recuperacion/setReferidos";
        //    var response = await WebApiServiceBase<string>.WebApiPostCall(url, referente, HttpClient);
        //    return response;
        //}


    }
}