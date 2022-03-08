using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sauron_Monitor_Integraciones.Shared.WMS
{
    public class OrderDetails_Model
    {

        public string STORERKEY { get; set; }
        public string EXTERNORDERKEY { get; set; }
        public string EXTERNLINENO { get; set; }
        public string SKU { get; set; }
        public string UOM { get; set; }
        public string OPENQTY { get; set; }
        public string ORIGINALQTY { get; set; }
        public string SUSR1 { get; set; }
        public string SUSR2 { get; set; }
        public string SUSR3 { get; set; }
        public string SUSR5 { get; set; }
        public string WHSEID { get; set; }
        public string Fecha_erp { get; set; }
        public string Fecha_ION { get; set; }
        public string ION_flag { get; set; }
        public string LOTATTRIBUTE06 { get; set; }

    }
}
