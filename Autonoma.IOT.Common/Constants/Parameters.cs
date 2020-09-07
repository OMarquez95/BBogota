namespace Autonoma.IOT.Common.Constants
{
    /// <summary>
    /// Esta clase contiene las constantes adicionales del aplicativo
    /// </summary>
    public class Parameters
    {
        #region Tramites
        /// <summary>
        /// Constante tramite ACTIVACION
        /// </summary>
        public const string ACTIVACION = "ACTIVACION";

        /// <summary>
        /// Constante tramite ACTIVACIONPRE
        /// </summary>
        public const string ACTIVACIONPRE = "ACTIVACIONPRE";

        /// <summary>
        /// Constante tramite ACTINCLUSIONON
        /// </summary>
        public const string ACTINCLUSION = "ACTINCLUSION";

        /// <summary>
        /// Constante tramite MIGRACION
        /// </summary>
        public const string MIGRACION = "MIGRACION";

        #endregion

        /// <summary>
        /// Mensaje de validacion para numeros decimales
        /// </summary>
        public const string SOLO_DECIMALES = "Solo se permiten números decimales";

        /// <summary>
        /// Mensaje de validacion para numeros enteros
        /// </summary>
        public const string SOLO_ENTEROS = "Solo se permiten números enteros";

        /// <summary>
        /// Constante con el nombre del appSettings para consultar la url del api
        /// </summary>
        public const string URL_API_REST = "urlApiRest";

        /// <summary>
        /// Constante de la ruta url para consultar tipos de documentos en el api
        /// </summary>
        public const string URL_TIPO_DOCUMENTOS = "/tipodocumento/getTipoDocumentos";

        /// <summary>
        /// Constante de la ruta url para consultar tipos de documentos en el api
        /// </summary>
        public const string URL_LLAVE_DISPATCHERS = "/parametro/getParametro";

        /// <summary>
        /// Constante de la ruta url para consultar rechazos de Activacion Pospago
        /// </summary>
        public const string URL_FILTRO_ACTIVACION_POSPAGO = "/activacion/getActivaciondg";
        /// <summary>
        /// Constante de la ruta url para consultar rechazos de Activacion Pospago por CODMIN y FECREGIS
        /// </summary>
        public const string URL_FILTRO_ACTIVACION_POSPAGO_X_ID = "/activacion/getActivacion";
        /// <summary>
        /// Constante de la ruta url para consultar rechazos de Activacion Pospago por CODMIN y FECREGIS
        /// </summary>
        public const string URL_POST_FILTRO_ACTIVACION_POSPAGO = "/activacion/editActivacion";
        /// <summary>
        /// Constante de la ruta url para consultar rechazos de Activacion Prepago
        /// </summary>
        public const string URL_FILTRO_ACTIVACION_PREPAGO = "/activacionpre/getActivacionpredg";

        /// <summary>
        /// Constante de la ruta url para consultar rechazos de Activacion Cadenas
        /// </summary>
        public const string URL_FILTRO_ACTIVACION_CADENAS = "/actinclusion/getActinclusiondg";
        /// <summary>
        /// Constante de la ruta url para consultar rechazos de Activacion Migracion
        /// </summary>
        public const string URL_POST_FILTRO_ACTIVACION_MIGRACION = "/migracion/editMigracion";
        /// <summary>
        /// Constante de la ruta url para consultar rechazos de Activacion Migracion
        /// </summary>
        public const string URL_FILTRO_ACTIVACION_MIGRACION = "/migracion/getMigraciondg";
        /// <summary>
        /// Constante de la ruta url para consultar rechazos de Activacion Migracion
        /// </summary>
        public const string URL_GET_FILTRO_ACTIVACION_MIGRACION = "/migracion/getMigracion";
        /// <summary>
        /// Constante de la ruta url para consultar rechazos de Activacion cadenas
        /// </summary>
        public const string URL_GET_ACTIVACION_CADENAS = "/actinclusion/getActinclusion";

        /// <summary>
        /// Constante de la ruta url para consultar rechazos de Activacion prepago GET
        /// </summary>
        public const string URL_GET_ACTIVACION_PREPAGO = "/activacionpre/getActivacionpre";

        /// <summary>
        /// Constante de la ruta url para consultar rechazos de Activacion prepago POST
        /// </summary>
        public const string URL_POST_ACTIVACION_CADENAS = "/actinclusion/editActinclusion";

        /// <summary>
        /// Constante de la ruta url para consultar rechazos de Activacion prepago POST
        /// </summary>
        public const string URL_POST_ACTIVACION_PREPAGO = "/activacionpre/editActivacionpre";

        /// <summary>
        /// Constante de la ruta url para guardar auditoria rechazos prepago POST
        /// </summary>
        public const string URL_POST_AUDITORIA = "/auditRecazos/setAuditRechazos";

        /// <summary>
        /// Constante de la ruta url para login en poliedro
        /// </summary>
        public const string URL_LOGIN_POLIEDRO = "urlLoginPoliedro";

        /// <summary>
        /// Constante de la ruta url para login en poliedro
        /// </summary>
        public const string URL_RETURN_POLIEDRO = "urlReturnPoliedro";

        /// <summary>
        /// Constante para realizar la consulta de las llaves del dispatcher
        /// </summary>
        public const string LLAVE_DISPATCHERS = "llaveDispatchers";

        /// <summary>
        /// Constante para realizar la consulta de cache de Activacion
        /// </summary>
        public const string LLAVE_CACHE_ACTIVCION = "LLAVE_ACTIVCION";

        /// <summary>
        /// Constante para realizar la consulta de cache de Activacionpre
        /// </summary>
        public const string LLAVE_CACHE_ACTIVCIONPRE = "LLAVE_ACTIVCIONPRE";

        /// <summary>
        /// Constante para realizar la consulta de cache de Actinclusion
        /// </summary>
        public const string LLAVE_CACHE_ACTINCLUSION = "LLAVE_ACTINCLUSION";

        /// <summary>
        /// Constante para obtener el valor del host en el web config del servidor que contiene los motivos de rechazos en los logs
        /// </summary>
        public const string SERVIDOR_DESTINO_LOGS_MOTIVORECHAZO = "hostValidaMotivo";

        /// <summary>
        /// Constante para obtener el valor del usuario en el web config del servidor que contiene los motivos de rechazos en los logs
        /// </summary>
        public const string SERVIDOR_DESTINO_LOGS_MOTIVORECHAZO_USER = "loginUHostValidaMotivo";

        /// <summary>
        /// Constante para obtener el password del host en el web config del servidor que contiene los motivos de rechazos en los logs
        /// </summary>
        public const string SERVIDOR_DESTINO_LOGS_MOTIVORECHAZO_PASSWORD = "loginPHostValidaMotivo";


        /// <summary>
        /// Constante para obtener el password del host en el web config del servidor que contiene los motivos de rechazos en los logs
        /// </summary>
        public const string MOTIVOS_RECHAZOS_MIGRACIONES = "MotivosMigracion";

        /// <summary>
        /// Constante para realizar la consulta de cache de Migracion
        /// </summary>
        public const string LLAVE_CACHE_MIGRACION = "LLAVE_MIGRACION";

        /// <summary>
        /// Constante de cadena de conexión de base de datos ACTIVA
        /// </summary>
        public const string CONNECTION_STRING_NAME = "ActivaConnection";


        /// <summary>
        /// Constante de cadena de conexión de base de datos BSCS
        /// </summary>
        public const string CONNECTION_STRING_NAME_BSCS = "BSCSConnection";


        /// <summary>
        /// Constante de cadena de conexión de base de datos COMCORP
        /// </summary>
        public const string CONNECTION_STRING_NAME_COMPCORP = "COMPCORPConnection";
        

        /// <summary>
        /// Constante para el tamaño del pool de conexión a la base de datos
        /// </summary>
        public const int POOL_DB_SIZE = 30;
        /// <summary>
        /// Constante para el tamaño del mensaje de respuesta de los procedimientos de consulta de registros
        /// </summary>
        public const int SP_RETURN_MESSAGE_SIZE = 200;

        #region Nombres procedimientos de consulta a base de datos
        public const string SP_CONSULTA_TIPO_DOCUMENTO = "SP_CONSULTA_TIPOSDOCUMENTO";
        public const string SP_CONSULTA_ACTIVACION = "SP_CONSULTA_ACTIVACION";
        public const string SP_CONSULTA_ACTIVACIONPRE = "SP_CONSULTA_ACTIVACIONPRE";
        public const string SP_CONSULTA_ACTINCLUSION = "SP_CONSULTA_ACTINCLUSION";
        public const string SP_CONSULTA_MIGRACION = "SP_CONSULTA_MIGRACION";
        #endregion

        #region Nombres procedimientos de actualización a base de datos
        public const string SP_UPDATEMIGRACION = "EXTRANET.UPDATEMIGRACION";
        public const string SP_UPDATEACTIVACION = "EXTRANET.UPDATEACTIVACION";
        public const string SP_UPDATEACTINCLUSION = "EXTRANET.UPDATEACTINCLUSION";
        #endregion

        #region Constantes Auditoria RecuperacionClientes
        public const string URL_GET_FILTRO_AUDITORIA_RECHAZO = "/auditRecazos/getAuditRechazos";
        #endregion

    }
}
