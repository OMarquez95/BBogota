#region Derechos Reservados
// ===================================================
// Desarrollado Por             :   José Fabián Cataño Sánchez. 
// Fecha de Creación            :   2018/05/05
// Empresa                      :   Tatic
// Fecha de Modificación        :   2018/05/05
// ===================================================
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Autonoma.IOT.WebApp.Models;
using System.Linq;
using System.Web;

namespace Autonoma.IOT.WebApp.Helpers
{
    /// <summary>
    /// Validaciones y anotaciones perzonalizadas
    /// </summary>
    public class CustomValidators : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var validrech = (ValidarReferidoModel)validationContext.ObjectInstance;
               
            return ValidationResult.Success;
        }
    }
        
}