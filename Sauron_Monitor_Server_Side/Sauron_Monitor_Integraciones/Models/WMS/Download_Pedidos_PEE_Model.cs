using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sauron_Monitor_Integraciones.Shared.WMS
{
    public class Download_Pedidos_PEE_Model
    {
        public string STORERKEY_id_cia { get; set; }
        public string TYPE_tip_doc { get; set; }
        public string f430_consec_docto { get; set; }
        public string EXTERNORDERKEY_key_doc { get; set; }
        public string nit { get; set; }
        public string razon_social { get; set; }
        public DataSet dsDatos { get; set; }

        public DataTable dtEncabezado { get; set; }

        public DataTable dtMovimiento { get; set; }

    }
}
