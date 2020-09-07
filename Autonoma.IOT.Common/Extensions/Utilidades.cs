using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Autonoma.IOT.Common.Extensions
{
    /// <summary>
    /// Utilidades, metodos staticos
    /// </summary>
    public static class Utilidades
    {
        /// <summary>
        /// Obtiener diferencias entre dos archivos JSON 
        /// </summary>
        /// <param name="jsonexisting"></param>
        /// <param name="jsonModified"></param>
        /// <returns></returns>
        public static bool GetJsonDiff(ref string jsonexisting, ref string jsonModified)
        {
            // convertir JSON a objecto
            JObject xptJson = JObject.Parse(jsonModified);
            JObject actualJson = JObject.Parse(jsonexisting);

            // leer propiedades
            var xptProps = xptJson.Properties().ToList();
            var actProps = actualJson.Properties().ToList();

            // Encontrar diferencia en propiedades
            var difMod = (from existingProp in actProps
                          from modifiedProp in xptProps
                          where modifiedProp.Path.Equals(existingProp.Path)
                          where !modifiedProp.Value.ToString().Equals(existingProp.Value.ToString())
                          select new KeyValuePair<string, string>
                          (
                             modifiedProp.Path, modifiedProp.Value.ToString()
                          )
                            ).ToList();

            var difExis = (from existingProp in actProps
                           from modifiedProp in xptProps
                           where modifiedProp.Path.Equals(existingProp.Path)
                           where !modifiedProp.Value.ToString().Equals(existingProp.Value.ToString())
                           select new KeyValuePair<string, string>
                           (
                              existingProp.Path, existingProp.Value.ToString()
                           )
                ).ToList();

            //Crear nuevos archivos JSON
            var entriesMod = difMod.Select(d => $"'{d.Key}':'{d.Value}'");
            var entriEsxis = difExis.Select(d => $"'{d.Key}':'{d.Value}'");

            jsonModified = "{" + string.Join(",", entriesMod) + "}";
            jsonexisting = "{" + string.Join(",", entriEsxis) + "}";

            return true;
        }

        
        /// <summary>
        /// Método para la conversión de una cadena a ASCII
        /// </summary>
        /// <param name="Cadena"></param>
        /// <returns>ASCII</returns>
        public static string ConvertirASCII(string Cadena)
        {
            string nuevaCadena = "";
            byte[] bytes = Encoding.ASCII.GetBytes(Cadena);
            int result = BitConverter.ToInt32(bytes, 0);
            for (int i = 0; i < bytes.Length; i++)
            {
                if (i == bytes.Length - 1)
                    nuevaCadena += bytes[i].ToString();
                else
                    nuevaCadena += bytes[i].ToString() + "|";
            }
            return nuevaCadena;
        }
        /// <summary>
        /// Método para la conversión de ASCII a String
        /// </summary>
        /// <param name="Ascii"></param>
        /// <returns>String</returns>
        public static string ConvertirString(string Ascii)
        {
            string result1 = "";
            var bytes1 = Ascii.Split('|');
            char character;
            for (int i = 0; i < bytes1.Length; i++)
            {
                character = (char)Convert.ToInt16(bytes1[i]);
                result1 += character.ToString();
            }
            return result1;
        }
    }
}
