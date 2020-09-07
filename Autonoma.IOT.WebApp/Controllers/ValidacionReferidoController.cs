using Autonoma.IOT.Common.Enumerations;
using Autonoma.IOT.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;
using Autonoma.IOT.Common.Constants;
using System.Web.Script.Serialization;
using System.Text;
using System.Net;
using System.Web.Caching;
using Autonoma.IOT.WebApp.Models.Entities;
using Autonoma.IOT.WebApp.Helpers;
using CacheManager.Core;
using System.Diagnostics;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Autonoma.IOT.Common.Extensions;
using System.Web;
using System.Configuration;
using Autonoma.IOT.WebApp.ServiceLayer;
using System.Threading.Tasks;
using Autonoma.IOT.Common.Entities;
using System.Linq;

namespace Autonoma.IOT.WebApp.Controllers
{
    public class ValidacionReferidoController : BaseController
    {
        //Objeto para manejo de cache
        public static ICacheManager<string> manager = CacheFactory.Build<string>(p => p.WithSystemRuntimeCacheHandle());
        
        private readonly ReferidoService _referidoService;


        public ValidacionReferidoController()
        {
            _referidoService = new ReferidoService();
        }


        ///// <summary>
        ///// Formulario de consulta de rechazos
        ///// </summary>
        ///// <returns>Vista</returns>
        //public ActionResult Index(string mensaje = "")
        //{
        //    ValidarReferidoModel model = new ValidarReferidoModel();

        //    try
        //    {
        //        if (!string.IsNullOrEmpty((string)Session["EstadoSesion"]))
        //        {
        //            if ((string)Session["EstadoSesion"] != "true")
        //            {
        //                return RedirectToLogin();
        //            }
        //        }
        //        else
        //        {
        //            return RedirectToLogin();

        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        throw;
        //    }

        //    if (!string.IsNullOrEmpty(mensaje))
        //    {
        //        if (mensaje.Contains("exito"))
        //        {
        //            ViewBag.MensajeSuccess = true;
        //        }
        //        else if (mensaje.Contains("falla"))
        //        {
        //            ViewBag.MensajeFail = true;
        //        }
        //    }

        //    ViewBag.Mensaje = mensaje;
          

        //    return View(model);
        //}

        //#region validar


        //[HttpPost]
        //public async Task<ActionResult> Validate(string min)
        //{
        //    ValidacionOperadorDonante Operator;
        //    Referente referente;
        //    Session["MIN_PADRE"] = min;
        //    Operator = await GetOperator(min);
        //    //Operator = GetOperatorMock();

        //    if (Operator.EsValido)
        //    {
        //        referente = await GetReferente(min);
        //        //referente = getReferenteMock();
        //        if (!referente.esHijo)
        //        {
        //            if (referente.tieneError)
        //            {
        //                return Json(new { Error = true, message = referente.mensajeError});
        //            }

        //            try
        //            {
        //                Session["ListaReferidos"] = referente.referidos;
        //                return Json(new { Error = false });
        //            }
        //            catch (Exception ex)
        //            {
        //                throw;
        //            }
                    
        //        }
        //        else
        //        {
        //            return Json(new { Error = true, message = "El usuario es un referido actualmente." });
        //        }
        //    }
        //    else
        //    {
        //        return Json(new { Error = true, message = "El numero no aplica para la campaña. " + Operator.MotivoNoValido + "."});
        //    }
        //}

        //[HttpPost]
        //public async Task<ActionResult> SaveReferidos(List<Referido> lista)
        //{
        //    string result;
        //    List<string> OldMines = new List<string>();
        //    List<string> ValidNewMines = new List<string>();
        //    List<string> NewMines = new List<string>();
            

        //    List<Referido> OldList = new List<Referido>();
        //    OldList = Session["ListaReferidos"] as List<Referido>;
        //    List<Referido> finalListAction = new List<Referido>();

        //    foreach (var item in OldList)
        //    {
        //        OldMines.Add(item.Min);
        //    }

        //    foreach (var item in lista)
        //    {
        //        NewMines.Add(item.Min);
        //        if (!string.IsNullOrEmpty(item.Min))
        //        {
        //            ValidNewMines.Add(item.Min);
        //        }
        //    }

        //    List<String> duplicates = ValidNewMines.GroupBy(x => x)
        //                     .Where(g => g.Count() > 1)
        //                     .Select(g => g.Key)
        //                     .ToList();

        //    if (!(duplicates.Count == 0))
        //    {
        //        return Json(new { Error = true, message = "No pueden haber numeros repetidos" });
        //    }


        //    for (int i = 0; i < OldList.Count; i++)
        //    { 
        //        if (OldList[i].Es_Modificable)
        //        {
        //            if (!String.IsNullOrEmpty(OldList[i].Min))
        //            {
        //                if (!(NewMines.Contains(OldList[i].Min)))
        //                {
        //                    finalListAction.Add(new Referido { Accion = 'B', Min = OldList[i].Min, Es_Modificable = true });
        //                }
        //            }
        //        }
        //    }

        //    for (int i = 0; i < lista.Count; i++)
        //    {
        //        if (lista[i].Es_Modificable)
        //        {
        //            if (!String.IsNullOrEmpty(lista[i].Min))
        //            {
        //                if (!(OldMines.Contains(lista[i].Min)))
        //                {
        //                    finalListAction.Add(new Referido { Accion = 'C', Min = lista[i].Min, Es_Modificable = true });
        //                }
        //            }

        //        }
        //    }

            

        //    if (finalListAction.Count == 0)
        //    {
        //        return Json(new { Error = false, message = "No hay cambios realizados." });
        //    }
        //    else
        //    {
        //        Referente refe = new Referente() {esHijo=false, referidos= finalListAction, minReferente= Session["MIN_PADRE"].ToString() };
        //        result = await _referidoService.saveChanges(refe);

        //        return Json(new { Error = false, message = result });
        //    }
        //}

        //[HttpGet]
        //public ActionResult getReferidos()
        //{

        //    List<Referido> lista = new List<Referido>();

        //    lista = Session["ListaReferidos"] as List<Referido>;

        //    return PartialView("~/Views/Referido/_grillaReferidos.cshtml", lista);

        //}

        //private async Task<ValidacionOperadorDonante> GetOperator(string min)
        //{
        //    ValidacionOperadorDonante result;

        //    result = await _referidoService.ValidateOperator(min);

        //    return result;
        //}

        //private async Task<Referente> GetReferente(string min)
        //{
        //    Referente result;

        //    result = await _referidoService.GetReferente(min);

        //    return result;
        //}

        //private Referente getReferenteMock()
        //{
        //    Referente rf = new Referente();
        //    rf.esHijo = false;
        //    rf.tieneError = false;
        //    rf.referidos = new List<Referido>();
        //    rf.referidos.Add(new Referido { Es_Modificable = true, Min="3153038576"  });
        //    rf.referidos.Add(new Referido { Es_Modificable = false, Min="3153038575"  });
        //    rf.referidos.Add(new Referido { Es_Modificable = true, Min="3153038574"  });
        //    rf.referidos.Add(new Referido { Es_Modificable = true, Min="315303853"  });
        //    rf.referidos.Add(new Referido { Es_Modificable = true, Min="315303852"  });

        //    return rf;
        //}

        //private ValidacionOperadorDonante GetOperatorMock()
        //{
        //    ValidacionOperadorDonante vd = new ValidacionOperadorDonante();
        //    vd.EsValido = true;
        //    return vd;
        //}

        //#endregion
    }
}