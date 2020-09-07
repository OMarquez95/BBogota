using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claro.Rechazo.Common.Interfaces.DTO
{
    /// <summary>
    /// <descripcion>Interface que expone las propiedades de la entidad Usuario</descripcion>
    /// <creacion>
    /// <fecha>13-Abril-2018</fecha>
    /// <autor>Juan Manuel Gomez</autor>
    /// </creacion>
    /// </summary>
    public interface IUsuarioDTO
    {
        #region Atributos

        /// <summary>
        /// Identificador de usuario
        /// </summary>
        int id { get; set; }

        /// <summary>
        /// Nombre del usuario
        /// </summary>
        string nombre { get; set; }

        #endregion
    }
}
