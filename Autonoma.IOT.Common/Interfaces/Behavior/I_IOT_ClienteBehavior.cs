#region Derechos Reservados
// ===================================================
// Desarrollado Por             :   José Fabián Cataño Sánchez. 
// Fecha de Creación            :   2018/04/25
// Empresa                      :   Tatic
// Fecha de Modificación        :   2018/04/26
// ===================================================
#endregion
using System.Collections.Generic;
using System;
using Autonoma.IOT.Common.Entities;
using System.Data;
using Autonoma.IOT.Common.Entities;

namespace Autonoma.IOT.Common.Interfaces.Behavior
{
    public interface I_IOT_ClienteBehavior
    {
        /// <summary>
        /// Consulta los ultimos 5 mensajes del servidor
        /// </summary>
        /// <param name="prototipo">id del prototipo</param>
        /// <returns>Objeto MensajesConfiguracion con los ultimos mensajes del servidor</returns>
        MensajesConfiguracion ConsultarNotificaciones(int prototipo);

        /// <summary>
        /// Inserta notificaciones en la tabla 
        /// </summary>
        /// <param name="insertarMensajePrototipo">objeto con el mensaje y id de prototipo</param>        
        /// <returns>Objeto MensajesConfiguracion con los ultimos mensajes del servidor</returns>
        ResultadoPeticion InsertarNotificaciones(InsertarMensajePrototipo insertarMensajePrototipo);


        /// <summary>
        /// Consulta el estado del prototipo
        /// </summary>
        /// <param name="prototipo">id del prototipo</param>
        /// <returns>Objeto EstadoPrototipo con el resultado del estado del ptototipo </returns>
        EstadoPrototipo ConsultarEstadoPrototipo(int prototipo);

        /// <summary>
        /// Valida el Token     
        /// </summary>
        /// <param name="token">string del token</param>
        /// <param name="codigoPrototipo">codigo del prototipo</param>
        /// <returns>true si es valido, false sino lo es </returns>
        bool ValidarToken(string token, int codigoPrototipo);

        /// <summary>
        /// Actualiza el estado del prototipo
        /// </summary>
        /// <param name="estadoPrototipo"> recibe el objeto estado prototipo que contiene el nuevo estado y el codigo del prototipo</param>
        /// <returns>Resultado de la peticion, codigo de respuesta y descripcion</returns>
        ResultadoPeticion ActualizarEstadoPrototipo(EstadoPrototipo estadoPrototipo);


        /// <summary>
        /// Valida las credneciales
        /// </summary>
        /// <param name="usuario">Contiene codigoPrototipo y contraseña ingresada</param>
        /// <returns>Devuelve el token actual y el estado de la validacion</returns>
        Autenticar ValidarCredenciales(Usuario usuario);


        /// <summary>
        /// Obtiene la lista de horas configuradas por el prototipo dado
        /// </summary>
        /// <param name="prototipo"> codigo del prototipo al que se requiere saber la configuracion</param>
        /// <returns>Configuracion del horario</returns>
        ConfiguracionHorario ObtenerConfiguracion(int prototipo);

        /// <summary>
        /// Actualiza la configuracion de suministro del prototipo
        /// </summary>
        /// <param name="configuracionHorario">Objeto que contiene las configuraciones a realizar</param>
        /// <returns>Resultado de la transacción</returns>
        ResultadoPeticion ActualizarConfiguracion(ConfiguracionHorario configuracionHorario);

    }
}
