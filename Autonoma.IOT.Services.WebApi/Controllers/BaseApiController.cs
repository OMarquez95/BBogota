
using Autonoma.IOT.Business.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Autonoma.IOT.Services.WebApi.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        #region Instancias a capa de negocio

        /// <summary>
        /// Instancia de Acceso a capa de negocio
        /// </summary>
        public AutonomaIOT_BL AutonomaIotBL = new AutonomaIOT_BL();   
        #endregion

    }
}
