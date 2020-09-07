using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autonoma.IOT.Common.Entities
{
    public class HoraConfigurada
    {
        public int Hora { get; set; }

        public int Minuto { get; set; }

        public int Segundo { get; set; }

        //C Crear B Borrar M Modificar
        public char? Accion { get; set; }

        public int IdConfiguracion { get; set; }
    }
}
