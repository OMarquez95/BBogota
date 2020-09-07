using Autonoma.IOT.Common.Entities;
using Autonoma.IOT.Services.WebApp.ServiceAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Autonoma.IOT.Services.WebApp.Controllers
{
    [FiltrosAccion]
    public class TheDogChefController: Controller                               
    {
        private readonly WebAppService _serviceAccess;

        public TheDogChefController()
        {
            _serviceAccess = new WebAppService();
        }

        public async Task<EstadoPrototipo> GetValidacionEstadoPrototipo(int prototipo)
        {
            EstadoPrototipo result;
            result = await _serviceAccess.getValidacionEstadoPrototipo(prototipo);
            return result;
        }

        public async Task<ActionResult> VerificarMensajes()
        {
            MensajesConfiguracion model = new MensajesConfiguracion();
            model = await _serviceAccess.GetMensajesNotificacionPrototipo((int)Session["prototipo"]);
            return View(model);
        }

        public async Task<ActionResult> CambiarHorario()
        {
            ConfiguracionHorario model = new ConfiguracionHorario();
            model = await _serviceAccess.GetConfiguracionHorario((int)Session["prototipo"]);
            return View(model);
        }

        public async Task<ActionResult> CambiarEstado()
        {
            EstadoPrototipo model = new EstadoPrototipo();
            model = await _serviceAccess.getValidacionEstadoPrototipo((int)Session["prototipo"]);
            model.CodigoPrototipo = (int)Session["prototipo"];
            model.Token = (string)Session["token"];
            return View(model);
        }

        public async Task<ActionResult> setEstado(EstadoPrototipo estadoPrototipo)
        {
            try
            {
                estadoPrototipo.CodigoPrototipo = (int)Session["prototipo"];
                estadoPrototipo.Token = (string)Session["token"];
                var x = await _serviceAccess.setEstadoPrototipo(estadoPrototipo);
                bool Error = x.CodigoResultado == 0 ? false : true;
                return Json(new { Error , message = x.DescripcionResultado});
            }
            catch (Exception ex)
            {
                return Json(new { Error = true, message = "Ha ocurrido un error, intente nuevamente..." });
            }           
        }

        public async Task<ActionResult> addHorario(HoraConfigurada horaConfig)
        {
            try
            {
                ConfiguracionHorario configuracionHorario = new ConfiguracionHorario()
                {
                    CodigoPrototipo = (int)Session["prototipo"],
                    Token = (string)Session["token"],
                    HoraConfiguradas = new List<HoraConfigurada>() { new HoraConfigurada() {
                        Accion='C',
                        Hora=horaConfig.Hora,
                        Minuto=horaConfig.Minuto,
                        Segundo=0                        
                    }
                    }
                };
                bool Error = true;
                ConfiguracionHorario configuracionHorarioComparar = new ConfiguracionHorario();
                //antes de guardar, se verifica que no exista una hora y minuto igual al configurado
                configuracionHorarioComparar= await _serviceAccess.GetConfiguracionHorario((int)Session["prototipo"]);                
                foreach (var item in configuracionHorarioComparar.HoraConfiguradas)
                {
                    if (item.Hora== horaConfig.Hora && item.Minuto== horaConfig.Minuto)
                    {
                        return Json(new { Error=true, message = "No se puede configurar una hora y minuto ya guardada. Cambie la hora y/o el minuto" });
                    }
                }
                var x = await _serviceAccess.setConfiguracionHorario(configuracionHorario);
                Error = x.CodigoResultado == 0 ? false : true;
                if (!Error)
                {
                    configuracionHorarioComparar = await _serviceAccess.GetConfiguracionHorario((int)Session["prototipo"]);
                }               
                if (!Error)
                {
                    int max = 0;
                    foreach (var item in configuracionHorarioComparar.HoraConfiguradas)
                    {
                        if (item.IdConfiguracion > max)
                        {
                            max = item.IdConfiguracion;
                        }
                    }
                    return Json(new { Error, message = x.DescripcionResultado, hora = horaConfig.Hora, minuto = horaConfig.Minuto, idConfiguracion=max });
                }
                return Json(new { Error, message = x.DescripcionResultado });
            }
            catch (Exception ex)
            {
                return Json(new { Error = true, message = "Ha ocurrido un error, intente nuevamente..." });
            }
        }

        public async Task<ActionResult> modHorario(HoraConfigurada horaConfig)
        {
            try
            {
                ConfiguracionHorario configuracionHorario = new ConfiguracionHorario()
                {
                    CodigoPrototipo = (int)Session["prototipo"],
                    Token = (string)Session["token"],
                    HoraConfiguradas = new List<HoraConfigurada>() { new HoraConfigurada() {
                        Accion='M',
                        Hora=horaConfig.Hora,
                        Minuto=horaConfig.Minuto,
                        Segundo=0,
                        IdConfiguracion=horaConfig.IdConfiguracion
                    }
                    }
                };
                bool Error = true;
                ConfiguracionHorario configuracionHorarioComparar = new ConfiguracionHorario();
                //antes de guardar, se verifica que no exista una hora y minuto igual al configurado
                configuracionHorarioComparar = await _serviceAccess.GetConfiguracionHorario((int)Session["prototipo"]);
                foreach (var item in configuracionHorarioComparar.HoraConfiguradas)
                {
                    if (item.Hora == horaConfig.Hora && item.Minuto == horaConfig.Minuto)
                    {
                        return Json(new { Error = true, message = "No se puede configurar una hora y minuto ya guardada. Cambie la hora y/o el minuto" });
                    }
                }
                var x = await _serviceAccess.setConfiguracionHorario(configuracionHorario);
                Error = x.CodigoResultado == 0 ? false : true;
                return Json(new { Error, message = x.DescripcionResultado});
            }
            catch (Exception ex)
            {
                return Json(new { Error = true, message = "Ha ocurrido un error, intente nuevamente..." });
            }
        }

        public async Task<ActionResult> delHorario(HoraConfigurada horaConfig)
        {
            try
            {
                ConfiguracionHorario configuracionHorario = new ConfiguracionHorario()
                {
                    CodigoPrototipo = (int)Session["prototipo"],
                    Token = (string)Session["token"],
                    HoraConfiguradas = new List<HoraConfigurada>() { new HoraConfigurada() {
                        Accion='B',
                        Hora=0,
                        Minuto=0,
                        Segundo=0,
                        IdConfiguracion= horaConfig.IdConfiguracion
                    }
                    }
                };
                bool Error = true;
                var x = await _serviceAccess.setConfiguracionHorario(configuracionHorario);
                Error = x.CodigoResultado == 0 ? false : true;
                return Json(new { Error, message = x.DescripcionResultado, idConfiguracion = horaConfig.IdConfiguracion });
            }
            catch (Exception ex)
            {
                return Json(new { Error = true, message = "Ha ocurrido un error, intente nuevamente..." });
            }
        }
    }
}