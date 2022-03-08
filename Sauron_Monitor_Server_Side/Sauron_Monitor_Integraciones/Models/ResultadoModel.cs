using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sauron_Monitor_Integraciones.Shared
{
    public class ResultadoModel
    {
        public bool bitError { get; set; }
        public string resultado { get; set; }
        public object datos { get; set; }
    }
}
