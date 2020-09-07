using System;
using System.Reflection;

namespace Autonoma.IOT.Common.Extensions
{
    /// <summary>
    /// Extensiones sobre la clase object
    /// </summary>
    public static class ExtensionObject
    {

        #region CargarObjetoDesde

        /// <summary>
        /// Crea una nueva instancia de un Tipo en especifico con los valores 
        /// de las propiedades que se toman desde otro
        /// </summary>
        /// <typeparam name="T">Tipo de objeto a crear</typeparam>
        /// <param name="objetoBase">Objeto base del cual se tomaran los valores de las propiedades</param>
        /// <returns>Un nuevo objeto con los valores de las propiedades edl objetoBase</returns>
        public static T LoadObjectFrom<T>(this object objetoBase) where T : class, new()
        {

            T objetoResultado = new T();

            Type typeBase = objetoBase.GetType();
            PropertyInfo[] propiedadesResultado = objetoResultado.GetType().GetProperties();
            PropertyInfo propiedadBase;

            foreach (PropertyInfo propiedad in propiedadesResultado)
            {
                propiedadBase = typeBase.GetProperty(propiedad.Name);
                if (propiedadBase != null)
                {
                    propiedad.SetValue(objetoResultado, propiedadBase.GetValue(objetoBase, null), null);
                }
            }
            return objetoResultado;
        }

        /// <summary>
        /// Crea una nueva instancia de un Tipo en especifico con los valores 
        /// de las propiedades que se toman desde otro, si el objeto es null retorna null
        /// </summary>
        /// <typeparam name="T">Tipo de objeto a crear</typeparam>
        /// <param name="objetoBase">Objeto base del cual se tomaran los valores de las propiedades</param>
        /// <returns>Un nuevo objeto con los valores de las propiedades edl objetoBase</returns>
        public static T LoadObjectFromOrDefault<T>(this object objetoBase) where T : class, new()
        {
            if (objetoBase != null)
                return LoadObjectFromOrDefault<T>(objetoBase);
            return null;
        }
        /// <summary>
        /// Haces cast  de un objeto a otro
        /// </summary>
        /// <typeparam name="T">Tipo de objeto al que se le va a convertir</typeparam>
        /// <param name="objetoBase">Objeto base que se va a transformar</param>
        /// <returns>Null si no lo puede convertir, en caso contrario el objeto</returns>
        public static T Value<T>(this object objetoBase) where T : class
        {
            return objetoBase as T;
        }



        /// <summary>
        /// Establece un valor sobre una propiedad en especifico
        /// </summary>
        /// <param name="objetoBase">Objeto sobre el cual se va a hacer la acción</param>
        /// <param name="propiedad">Nombre de la propiedad a la que se le va a asignar el valor</param>
        /// <param name="value">Valor a establecer</param>
        /// <returns>Retorna el objeto modificado</returns>
        public static object SetValueToProperty(this object objetoBase, string propiedad, object value)
        {
            objetoBase.GetType().GetProperty(propiedad).SetValue(objetoBase, value, null);
            return objetoBase;
        }
        /// <summary>
        /// Obtiene el valor de una propiedad de un objeto
        /// </summary>
        /// <typeparam name="T">Tipo de dato que se va a obtener desde la propiedad</typeparam>
        /// <param name="objetoBase">Objeto sobre el cual se va a hacer la acción</param>
        /// <param name="propiedad">nombre de la propiedad a obtener</param>
        /// <returns>Valor de la propiedad o null en caso de no poder obtenerla</returns>
        public static T GetValueOfProperty<T>(this object objetoBase, string propiedad) where T : class
        {
            return objetoBase.GetType().GetProperty(propiedad).GetValue(objetoBase, null) as T;
        }
        /// <summary>
        /// Obtiene el valor de una propiedad de un objeto, como un object
        /// </summary>
        /// <param name="objetoBase">Objeto sobre el cual se va a hacer la acción</param>
        /// <param name="propiedad">nombre de la propiedad a obtener</param>
        /// <returns>Valor de la propiedad o null en caso de no poder obtenerla</returns>
        public static object GetValueFromProperty(this object objetoBase, string propiedad)
        {
            return objetoBase.GetType().GetProperty(propiedad).GetValue(objetoBase, null);
        }

        /// <summary>
        /// Metodo para copiar un lista de propiedades de un objeto a otro
        /// </summary>
        /// <param name="objetoBase">Objeto Base</param>
        /// <param name="objeto">Objeto Origen</param>
        /// <param name="propiedades">Lista de propiedades</param>
        public static void CopiarPropiedades(this object objetoBase, object objeto, string[] propiedades)
        {
            object valor;
            Type tipoDato = objetoBase.GetType();
            PropertyInfo propiedad;
            foreach (string nombrePropiedad in propiedades)
            {
                propiedad = tipoDato.GetProperty(nombrePropiedad);
                valor = propiedad.GetValue(objeto, null);
                propiedad.SetValue(objetoBase, valor, null);
            }
        }






        #endregion

    }
}
