using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sauron_Monitor_Integraciones.Shared.WMS
{
    public class Request_Pedidos_OC_Model
    {
        public string p_co { get; set; }
        public string p_TipoDoc { get; set; }
        public string p_NumDoc_Ini { get; set; }
        public string p_NumDoc_Fin { get; set; }
        public int p_fechaIni { get; set; }
        public int p_fechaFin { get; set; }
        public string p_ocini { get; set; }
        public string p_ocfin { get; set; }
    }
}
