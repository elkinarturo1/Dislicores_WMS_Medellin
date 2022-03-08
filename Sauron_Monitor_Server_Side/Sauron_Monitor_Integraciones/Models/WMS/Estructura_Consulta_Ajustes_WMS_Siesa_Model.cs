using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sauron_Monitor_Integraciones.Shared.WMS
{
    public class Estructura_Consulta_Ajustes_WMS_Siesa_Model
    {
        public bool bitEnviar { get; set; }
        public int numregistro { get; set; }
        public string STORERKEY { get; set; }
        public string Bodega { get; set; }
        public string SKU { get; set; }
        public string f120_referencia { get; set; }
        public string f120_descripcion { get; set; }
        public string CONTROLKEY { get; set; }
        public string INITIAL_QTY { get; set; }
        public string A_COUNT_QTY { get; set; }
        public string A_COUNT_UOMQTY { get; set; }
        public string B_COUNT_QTY { get; set; }
        public string B_COUNT_UOMQTY { get; set; }
        public string C_COUNT_QTY { get; set; }
        public string C_COUNT_UOMQTY { get; set; }
        public string Cantidad_Siesa { get; set; }
        public string diferencia { get; set; }
    }
}
