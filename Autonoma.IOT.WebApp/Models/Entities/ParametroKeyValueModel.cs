using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autonoma.IOT.WebApp.Models
{
    /// <summary>
    /// Clase generica para cargar valores tipo (key => value)
    /// </summary>
    public class ParametroKeyValueModel
    {
        /// <summary>
        /// Key de tipo entero
        /// </summary>
        public int keyInt { get; set; }

        /// <summary>
        /// Key de tipo string
        /// </summary>
        public string keyString { get; set; }

        /// <summary>
        /// Value de tipo entero
        /// </summary>
        public int valueInt { get; set; }

        /// <summary>
        /// Value de tipo String
        /// </summary>
        public string valueString { get; set; }
    }
}