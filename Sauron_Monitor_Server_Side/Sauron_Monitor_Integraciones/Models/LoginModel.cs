using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sauron_Monitor_Integraciones.Shared
{
    public class LoginModel
    {
        public int id { get; set; } = 0;
        public string codigo { get; set; } = "";
        public string nombre { get; set; } = "";
        public string clave { get; set; } = "";
    }
}
