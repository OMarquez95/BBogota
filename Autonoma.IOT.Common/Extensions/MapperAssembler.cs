using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Autonoma.IOT.Common.Extensions
{
    /// <summary>
    /// Clase que posee los métodos para ensamblar objetos  
    /// </summary>
    /// <typeparam name="TS">Tipo de la entidad fuente donde se obtiene la información</typeparam>
    /// <typeparam name="TD">Tipo de la entidad destino donde se retorna la información</typeparam>
    public static class MapperAssembler<TS, TD> where TD : new()
    {
        #region Métodos públicos
        /// <summary>
        /// Permite ensamblar los objetos destino con base en la lista 
        /// </summary>
        /// <param name="sourceObjects">Los objetos fuentes que serán pasados a los objetos destino</param>
        /// <returns>Lista de objetos del tipo destino con la información de los objetos fuente</returns>
        public static List<TD> AssembleObjects(IList<TS> sourceObjects)
        {
            return AssembleObjects(sourceObjects, true, null, null);
        }

        /// <summary>
        /// Permite ensamblar los objetos destino con base en la lista 
        /// </summary>
        /// <param name="sourceObjects">Los objetos fuentes que serán pasados a los objetos destino</param>
        /// <param name="level">Define el nivel de profundidad al que debe llegar el ensamblamiento de objetos hijos</param>
        /// <returns>Lista de objetos del tipo destino con la información de los objetos fuente</returns>
        public static List<TD> AssembleObjects(IList<TS> sourceObjects, int level)
        {
            return AssembleObjects(sourceObjects, true, level, 0);
        }

        /// <summary>
        /// Permite ensamblar los objetos destino con base en la lista 
        /// </summary>
        /// <param name="sourceObjects">Los objetos fuentes que serán pasados a los objetos destino</param>
        /// <param name="enableAssembleChildObjects">Indica si se deben ensamblar o no los objetos hijos del objeto fuente</param>
        /// <returns>Lista de objetos del tipo destino con la información de los objetos fuente</returns>
        public static List<TD> AssembleObjects(IList<TS> sourceObjects, bool enableAssembleChildObjects)
        {
            return AssembleObjects(sourceObjects, enableAssembleChildObjects, null, null); ;
        }

        /// <summary>
        /// Ensambla el objeto destino acorde al objeto persistente
        /// </summary>
        /// <param name="sourceObject">Objeto fuente el cual será pasado al tipo de objeto destino</param>
        /// <returns>Objeto del tipo destino con la información del objeto fuente</returns>
        public static TD AssembleObject(TS sourceObject)
        {
            return AssembleObject(sourceObject, default(TD), true);
        }

        /// <summary>
        /// Ensambla el objeto destino acorde al objeto persistente
        /// </summary>
        /// <param name="sourceObject">Objeto fuente el cual será pasado al tipo de objeto destino</param>
        /// <param name="editObject">Objeto destino original para actualizar valores de propiedades. Parámetro util para la edición de objetos</param>
        /// <returns>Objeto del tipo destino con la información del objeto fuent</returns>
        public static TD AssembleObject(TS sourceObject, TD editObject)
        {
            return AssembleObject(sourceObject, editObject, true);
        }

        /// <summary>
        /// Ensambla el objeto destino acorde al objeto persistente
        /// </summary>
        /// <param name="sourceObject">Objeto fuente el cual será pasado al tipo de objeto destino</param>
        /// <param name="enableAssembleChildObjects">Indica si se deben ensamblar o no los objetos hijos del objeto fuente</param>
        /// <returns>Objeto del tipo destino con la información del objeto fuent</returns>
        public static TD AssembleObject(TS sourceObject, bool enableAssembleChildObjects)
        {
            return AssembleObject(sourceObject, default(TD), enableAssembleChildObjects);
        }

        /// <summary>
        /// Ensambla el objeto destino acorde al objeto persistente
        /// </summary>
        /// <param name="sourceObject">Objeto fuente el cual será pasado al tipo de objeto destino</param>
        /// <param name="editObject">Objeto destino original para actualizar valores de propiedades. Parámetro util para la edición de objetos</param>
        /// <param name="enableAssembleChildObjects">Indica si se deben ensamblar o no los objetos hijos del objeto fuente</param>
        /// <returns>Objeto del tipo destino con la información del objeto fuente</returns>
        public static TD AssembleObject(TS sourceObject, TD editObject, bool enableAssembleChildObjects)
        {
            return AssembleObject(sourceObject, editObject, enableAssembleChildObjects, null, null);
        }

        /// <summary>
        /// Permite ensamblar una lista de items con base en la lista origen
        /// </summary>
        /// <param name="sourceObjects">Los objetos fuentes que serán pasados a los objetos destino</param>
        /// <param name="displayPropertyName">Nombre de la propiedad que posee la descripción</param>
        /// <param name="valuePropertyName">Nombre de la propiedad que posee el valor</param>
        /// <returns>Lista con los objetos destino</returns>
        public static List<TD> AssembleListItems(IList<TS> sourceObjects, string displayPropertyName, string valuePropertyName)
        {
            List<TD> resultList = null;

            if (sourceObjects != null && displayPropertyName != null && valuePropertyName != null)
            {
                resultList = new List<TD>();

                foreach (TS item in sourceObjects)
                {
                    TD listItem = new TD();
                    listItem.SetValueToProperty(displayPropertyName, item.GetValueFromProperty(displayPropertyName));
                    listItem.SetValueToProperty(valuePropertyName, item.GetValueFromProperty(valuePropertyName));
                    resultList.Add(listItem);
                }
            }

            return resultList;
        }
        #endregion

        #region Métodos privados
        /// <summary>
        /// Permite ensamblar los objetos destino con base en la lista 
        /// </summary>
        /// <param name="sourceObjects">Los objetos fuentes que serán pasados a los objetos destino</param>
        /// <param name="level">Nivel de profundidad</param>
        /// <param name="currentLevel">Nivel de profundidad actual</param>
        /// <returns>Lista de objetos del tipo destino con la información de los objetos fuente</returns>
        private static List<TD> AssembleObjects(IList<TS> sourceObjects, int? level, int? currentLevel)
        {
            return AssembleObjects(sourceObjects, true, level, currentLevel);
        }

        /// <summary>
        /// Permite ensamblar los objetos destino con base en la lista 
        /// </summary>
        /// <param name="sourceObjects">Los objetos fuentes que serán pasados a los objetos destino</param>
        /// <param name="enableAssembleChildObjects">Indica si se deben ensamblar o no los objetos hijos del objeto fuente</param>
        /// <param name="level">Nivel de profundidad</param>
        /// <param name="currentLevel">Nivel de profundidad actual</param>
        /// <returns>Lista de objetos del tipo destino con la información de los objetos fuente</returns>
        private static List<TD> AssembleObjects(IList<TS> sourceObjects, bool enableAssembleChildObjects, int? level, int? currentLevel)
        {
            List<TD> resultList = new List<TD>();

            foreach (TS sourceObject in sourceObjects)
            {
                resultList.Add(AssembleObject(sourceObject, default(TD), enableAssembleChildObjects, level, currentLevel));
            }

            return resultList;
        }

        /// <summary>
        /// Ensambla el objeto destino acorde al objeto persistente
        /// </summary>
        /// <param name="sourceObject">Objeto fuente el cual será pasado al tipo de objeto destino</param>
        /// <param name="level">Nivel de profundidad</param>
        /// <param name="currentLevel">Nivel de profundidad actual</param>
        /// <returns>Objeto del tipo destino con la información del objeto fuente</returns>
        private static TD AssembleObject(TS sourceObject, int? level, int? currentLevel)
        {
            return AssembleObject(sourceObject, default(TD), true, level, currentLevel);
        }

        /// <summary>
        /// Ensambla el objeto destino acorde al objeto persistente
        /// </summary>
        /// <param name="sourceObject">Objeto fuente el cual será pasado al tipo de objeto destino</param>
        /// <param name="editObject">Objeto destino original para actualizar valores de propiedades. Parámetro util para la edición de objetos</param>
        /// <param name="enableAssembleChildObjects">Indica si se deben ensamblar o no los objetos hijos del objeto fuente</param>
        /// <param name="level">Nivel de profundidad</param>
        /// <param name="currentLevel">Nivel de profundidad actual</param>
        /// <returns>Objeto del tipo destino con la información del objeto fuente</returns>
        private static TD AssembleObject(TS sourceObject, TD editObject, bool enableAssembleChildObjects, int? level, int? currentLevel)
        {
            if (sourceObject == null)
                return default(TD);

            TD resultObject = (editObject != null) ? editObject : default(TD);

            //Se incrementa el nivel de profundidad
            if (currentLevel.HasValue)
                ++currentLevel;

            PropertyInfo[] sourceObjectProperties = typeof(TS).GetProperties();
            PropertyInfo[] resultObjectProperties = typeof(TD).GetProperties();

            if (sourceObjectProperties != null && resultObjectProperties != null)
            {
                if (editObject == null)
                {
                    resultObject = new TD();
                }

                for (int i = 0; i < sourceObjectProperties.Length; i++)
                {
                    PropertyInfo fromProperty = (PropertyInfo)sourceObjectProperties[i];

                    for (int j = 0; j < resultObjectProperties.Length; j++)
                    {
                        PropertyInfo toProperty = (PropertyInfo)resultObjectProperties[j];

                        if (fromProperty.Name == toProperty.Name)
                        {
                            //Se obtienen los tipos básicos del objeto
                            if (fromProperty.PropertyType.IsValueType ||
                                (fromProperty.PropertyType.IsArray && fromProperty.PropertyType.GetElementType().IsValueType) ||
                                fromProperty.PropertyType == typeof(System.String))
                            {
                                //Se establece el valor de la propiedad
                                if (toProperty.CanWrite && fromProperty.GetValue(sourceObject, null) != null)
                                {
                                    toProperty.SetValue(resultObject, fromProperty.GetValue(sourceObject, null), null);
                                }
                            }
                            else
                            {
                                if (enableAssembleChildObjects)
                                {
                                    //Validación del nivel de profundidad
                                    if (level.HasValue && currentLevel.HasValue && (currentLevel > level))
                                        continue;

                                    //Se obtiene el tipo del ensamblador
                                    Type mapperAssemblerType = typeof(MapperAssembler<,>);
                                    //Se definen los argumentos y se crea el tipo genérico dinamicamente
                                    Type[] typeArgs = { fromProperty.PropertyType, toProperty.PropertyType };
                                    Type resultTDype = mapperAssemblerType.MakeGenericType(typeArgs);
                                    //Se obtiene la lista de métodos del tipo
                                    MethodInfo[] methods = resultTDype.GetMethods(BindingFlags.NonPublic | BindingFlags.Static);
                                    string methodName = (fromProperty.PropertyType.IsArray) ? "AssembleObjects" : "AssembleObject";
                                    //Se obtiene el método estático específico a ejecutar
                                    MethodInfo method = (from m in methods
                                                         where m.Name == methodName && m.GetParameters().Length == 3
                                                         select m).First();
                                    //Se obtiene el valor desde la propiedad fuente
                                    object sourceValue = fromProperty.GetValue(sourceObject, null);
                                    //Se ejecuta el método
                                    object resultValue = (sourceValue != null) ? method.Invoke(null, new object[] { sourceValue, level, currentLevel }) : null;

                                    if (toProperty.CanWrite && resultValue != null)
                                    {
                                        //Se establece el valor de la propiedad  
                                        toProperty.SetValue(resultObject, resultValue, null);
                                    }
                                }
                            }

                            break;
                        }
                    }
                }
            }

            return resultObject;
        }
        #endregion
    }
}