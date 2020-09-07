using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autonoma.IOT.Common.Entities
{
    public class ConfiguracionHorario        
    {
        public ConfiguracionHorario()
        {
            this.HoraConfiguradas = new List<HoraConfigurada>();
        }
        //lista con las horas a configurar o ya configuradas
        public List<HoraConfigurada> HoraConfiguradas { get; set; }

        //codigo del prorotipo
        public int CodigoPrototipo { get; set; }

        //Token para validar
        public string Token{ get; set; }
    }
}
