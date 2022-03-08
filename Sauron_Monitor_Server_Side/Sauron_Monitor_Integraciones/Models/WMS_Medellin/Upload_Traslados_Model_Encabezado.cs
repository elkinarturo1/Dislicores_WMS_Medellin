using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sauron_Monitor_Integraciones.Shared.WMS_Medellin
{
    public class Upload_Traslados_Model_Encabezado
    {
       public string CONTROLKEY { get; set; }
       public string F_CIA { get; set; }
       public string f350_id_co { get; set; }
       public string f350_id_tipo_docto { get; set; }
       public string f350_consec_docto { get; set; }
       public string f350_fecha { get; set; }
       public string f350_notas { get; set; }
       public string f450_id_bodega_salida { get; set; }
       public string f450_id_bodega_entrada { get; set; }
        public bool bitVerDetalle { get; set; } = false;
    }
}
