using Autonoma.IOT.Common.Entities;
using Autonoma.IOT.Common.Interfaces.Behavior;
using Autonoma.IOT.DataAccess.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Security.Cryptography;
using System.Text;


namespace Autonoma.IOT.Business.BL
{
    public class AutonomaIOT_BL : I_IOT_ClienteBehavior
    {
        #region Atributos

        /// <summary>
        /// Instancia de Acceso a capa datos
        /// </summary>
        private IOT_DAL recuperaConnectionIOT = IOT_DAL.GetInstance(ConfigurationManager.ConnectionStrings["IOTConnection"].ToString());

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public AutonomaIOT_BL()
        {
        }

        #endregion

        #region metodos

        public ResultadoPeticion ActualizarConfiguracion(ConfiguracionHorario configuracionHorario)
        {
            try
            {
                ResultadoPeticion resultadoPeticion = new ResultadoPeticion() { CodigoResultado = 999, DescripcionResultado = "Error ejecutando actualización" };
                if (configuracionHorario.HoraConfiguradas.Count < 1)
                {
                    resultadoPeticion.CodigoResultado = 0;
                    resultadoPeticion.DescripcionResultado = "No se realizaron modificaciones sobre la configuración actual.";
                    return resultadoPeticion;
                }
                if (!ValidarToken(configuracionHorario.Token, configuracionHorario.CodigoPrototipo))
                {
                    resultadoPeticion.CodigoResultado = 998;
                    resultadoPeticion.DescripcionResultado = "Token Inválido, inicie sesión de nuevo";
                    return resultadoPeticion;
                }
                resultadoPeticion.CodigoResultado = 0;
                resultadoPeticion.DescripcionResultado = "";
                foreach (HoraConfigurada horaConfigurada in configuracionHorario.HoraConfiguradas)
                {
                    string sql = "";
                    switch (horaConfigurada.Accion)
                    {
                        case 'C':
                            sql = "INSERT INTO DOGCHEF.CONFIGURACION_PROTOTIPO(HORA_SUMINISTRO, PROTOTIPO_ID_PROTOTIPO) VALUES ('" + horaConfigurada.Hora +":"+horaConfigurada.Minuto+":"+horaConfigurada.Segundo+"'," + configuracionHorario.CodigoPrototipo + ");";                            
                            break;
                        case 'B':
                            sql = "DELETE FROM DOGCHEF.CONFIGURACION_PROTOTIPO WHERE ID_CONFIGURACION_PROTOTIPO ="+horaConfigurada.IdConfiguracion+";";
                            break;
                        case 'M':
                            sql = "UPDATE DOGCHEF.CONFIGURACION_PROTOTIPO SET HORA_SUMINISTRO='"+ horaConfigurada.Hora + ":" + horaConfigurada.Minuto + ":" + horaConfigurada.Segundo + "' WHERE ID_CONFIGURACION_PROTOTIPO="+horaConfigurada.IdConfiguracion+";";
                            break;
                        default:
                            break;
                    }
                    if (recuperaConnectionIOT.ExecuteNonQuery(sql))
                    {
                        switch (horaConfigurada.Accion)
                        {
                            case 'C':
                                resultadoPeticion.DescripcionResultado = "Adición de hora de suministro correcta:  " + horaConfigurada.Hora + ":" + horaConfigurada.Minuto + ":" + horaConfigurada.Segundo + ".";
                                break;
                            case 'B':
                                resultadoPeticion.DescripcionResultado = "Borrado de hora de suministro correcta:  " + horaConfigurada.Hora + ":" + horaConfigurada.Minuto + ":" + horaConfigurada.Segundo + ".";
                                break;
                            case 'M':
                                resultadoPeticion.DescripcionResultado = "Modificación de hora de suministro correcta:  " + horaConfigurada.Hora + ":" + horaConfigurada.Minuto + ":" + horaConfigurada.Segundo + ".";
                                break;
                        }
                    }
                    else
                    {
                        resultadoPeticion.CodigoResultado = 997;
                        resultadoPeticion.DescripcionResultado = "Modificación de hora de suministro erronea: " + horaConfigurada.Hora + ":" + horaConfigurada.Minuto + ":" + horaConfigurada.Segundo + ".";
                    }
                    InsertarMensajePrototipo insertarMensajePrototipo = new InsertarMensajePrototipo() { CodigoPrototipo = configuracionHorario.CodigoPrototipo, Mensaje = resultadoPeticion.DescripcionResultado };
                    InsertarNotificaciones(insertarMensajePrototipo);
                }
                if (resultadoPeticion.CodigoResultado != 0)
                {
                    resultadoPeticion.DescripcionResultado = "Configuracion realizada con errores, verifique las notificaciones";
                }
                else
                {
                    resultadoPeticion.DescripcionResultado = "Configuración realizada exitosamente";
                }
                return resultadoPeticion;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        
        public bool ValidarToken(string token, int codigoPrototipo)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = "SELECT * FROM DOGCHEF.USUARIO WHERE PROTOTIPO_ID_PROTOTIPO='" + codigoPrototipo + "' AND TOKEN='" + token + "';";
                dt = recuperaConnectionIOT.ExecuteQuery(query);
                if (dt.Rows.Count > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public ResultadoPeticion ActualizarEstadoPrototipo(EstadoPrototipo estadoPrototipo)
        {            
            try
            {
                ResultadoPeticion resultadoPeticion = new ResultadoPeticion() { CodigoResultado = 999, DescripcionResultado = "Token Invalido, inicie sesión de nuevo" };
                if (!ValidarToken(estadoPrototipo.Token, estadoPrototipo.CodigoPrototipo))
                {
                    return resultadoPeticion;
                }
                int estado = (estadoPrototipo.Estado == true) ? 1 : 0;
                string sql = "UPDATE DOGCHEF.PROTOTIPO SET ESTADO = " + estado + " WHERE ID_PROTOTIPO = '" + estadoPrototipo.CodigoPrototipo + "';";
                if (!recuperaConnectionIOT.ExecuteNonQuery(sql))
                {
                    resultadoPeticion.DescripcionResultado = "Ha ocurrido un error actualizando el estado, intente nuevamente";
                    resultadoPeticion.CodigoResultado = 998;
                }
                resultadoPeticion.CodigoResultado = 0;
                resultadoPeticion.DescripcionResultado = "Se ha actualizado correctamente el estado del prototipo";
                InsertarMensajePrototipo insertarMensajePrototipo = new InsertarMensajePrototipo() { CodigoPrototipo=estadoPrototipo.CodigoPrototipo, Mensaje= "Se ha actualizado correctamente el estado del prototipo - Servidor" };
                InsertarNotificaciones(insertarMensajePrototipo);
                return resultadoPeticion;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public EstadoPrototipo ConsultarEstadoPrototipo(int prototipo)
        {
            try
            {
                EstadoPrototipo estadoPrototipo = new EstadoPrototipo() { CodigoPrototipo = prototipo, Estado = false };
                DataTable dt = new DataTable();
                string query = "SELECT * FROM DOGCHEF.PROTOTIPO WHERE ID_PROTOTIPO=" + prototipo + ";";
                dt = recuperaConnectionIOT.ExecuteQuery(query);
                if (dt.Rows.Count > 0)
                {
                    if (Int16.Parse(dt.Rows[0]["ESTADO"].ToString())==1)
                    {
                        estadoPrototipo.Estado = true;
                    }
                }
                    return estadoPrototipo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public ConfiguracionHorario ObtenerConfiguracion(int prototipo)
        {
            try
            {
                ConfiguracionHorario configuracionHorario = new ConfiguracionHorario() { CodigoPrototipo=prototipo};
                DataTable dt = new DataTable();
                string query = "SELECT * FROM DOGCHEF.CONFIGURACION_PROTOTIPO WHERE PROTOTIPO_ID_PROTOTIPO =" + prototipo+ ";";
                dt = recuperaConnectionIOT.ExecuteQuery(query);
                foreach (DataRow dr in dt.Rows)
                {
                    HoraConfigurada horaConfigurada = new HoraConfigurada();
                    horaConfigurada.Accion = null;
                    var time = dr["HORA_SUMINISTRO"].ToString().Split(':');
                    horaConfigurada.Hora = Int32.Parse(time[0]); 
                    horaConfigurada.Minuto = Int32.Parse(time[1]);
                    horaConfigurada.Segundo = Int32.Parse(time[2]);
                    horaConfigurada.IdConfiguracion = Int32.Parse(dr["ID_CONFIGURACION_PROTOTIPO"].ToString());
                    configuracionHorario.HoraConfiguradas.Add(horaConfigurada);
                }
                return configuracionHorario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public Autenticar ValidarCredenciales(Usuario usuario)
        {
            try
            {
                Autenticar autenticar = new Autenticar() { Validacion = false };
                DataTable dt = new DataTable();
                string query = "SELECT * FROM DOGCHEF.USUARIO WHERE COD_USUARIO='" + usuario.CodigoUsuario + "' AND CONTRASENA=MD5('" + usuario.Contrasena + "');";
                dt =recuperaConnectionIOT.ExecuteQuery(query);
                if (dt.Rows.Count > 0)
                {
                    autenticar.CodigoPrototipo = Convert.ToInt32(dt.Rows[0]["PROTOTIPO_ID_PROTOTIPO"]);                  
                    autenticar.Validacion = true;
                    Random rnd = new Random();
                    Byte[] b = new Byte[20];
                    rnd.NextBytes(b);
                    autenticar.Token = Convert.ToBase64String(b);
                    autenticar.Token=EncMD5(autenticar.Token);
                    autenticar.Token = autenticar.Token.Substring(0, 20);
                    //convert to bytes array byte[] bytes = Encoding.ASCII.GetBytes(someString);
                    string sql = "UPDATE DOGCHEF.USUARIO SET TOKEN = '"+ autenticar.Token + "' WHERE COD_USUARIO='" + usuario.CodigoUsuario + "';";
                    if (!recuperaConnectionIOT.ExecuteNonQuery(sql))
                    {
                        throw new Exception("Ha ocurrido un error generando el token de autenticación, intente nuevamente");
                    }                    
                }
                return autenticar;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message,ex.InnerException);
            }
        }

        public ResultadoPeticion InsertarNotificaciones(InsertarMensajePrototipo insertarMensajePrototipo)
        {
            try
            {
                ResultadoPeticion rp = new ResultadoPeticion() { CodigoResultado=999, DescripcionResultado="Error realizando la inserción"};
                string query = "INSERT INTO DOGCHEF.MENSAJE_PROTOTIPO(MENSAJE, FECHA_HORA, PROTOTIPO_ID_PROTOTIPO) VALUES('" + insertarMensajePrototipo.Mensaje+ "',SYSDATE(), "+insertarMensajePrototipo.CodigoPrototipo+");";
                if (recuperaConnectionIOT.ExecuteNonQuery(query))
                {
                    rp.CodigoResultado = 0;
                    rp.DescripcionResultado = "Mensaje insertado exitosamente";
                }
                return rp;               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public static string EncMD5(string password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            UTF8Encoding encoder = new UTF8Encoding();
            Byte[] originalBytes = encoder.GetBytes(password);
            Byte[] encodedBytes = md5.ComputeHash(originalBytes);
            password = BitConverter.ToString(encodedBytes).Replace("-", "");
            var result = password.ToLower();
            return result;
        }

        public MensajesConfiguracion ConsultarNotificaciones(int prototipo)
        {
            try
            {
                MensajesConfiguracion mensajesConfiguracion = new MensajesConfiguracion() { mensaje = new List<string>() };
                DataTable dt = new DataTable();
                string query = "SELECT * FROM DOGCHEF.MENSAJE_PROTOTIPO WHERE PROTOTIPO_ID_PROTOTIPO=" + prototipo + " ORDER BY FECHA_HORA DESC;";
                dt = recuperaConnectionIOT.ExecuteQuery(query);
                int limite=20;
                if (dt.Rows.Count<20)
                {
                    limite = dt.Rows.Count;
                }
                for (int i = 0; i < limite; i++)
                {
                    mensajesConfiguracion.mensaje.Add(dt.Rows[i]["MENSAJE"].ToString() + ". Fecha y hora de la modificación: " + dt.Rows[i]["FECHA_HORA"].ToString()+".");
                }
                return mensajesConfiguracion;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        #endregion

    }
}
