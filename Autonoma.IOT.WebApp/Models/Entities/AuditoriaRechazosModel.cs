using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autonoma.IOT.WebApp.Models.Entities
{
    public class AuditoriaRechazosModel
    {
        public decimal ID_AUDITORIA { get; set; }
        public Nullable<System.DateTime> FECREGIS { get; set; }
        public string USUARIOMOD { get; set; }
        public string TABLATRAMITE { get; set; }
        public Nullable<decimal> CO_ID { get; set; }
        public string CODMIN { get; set; }
        public string CODMINEXT { get; set; }
        public string REG_ANTERIOR { get; set; }
        public string REG_ACTUAL { get; set; }
        public string ROWIDMOD { get; set; }
    }
}