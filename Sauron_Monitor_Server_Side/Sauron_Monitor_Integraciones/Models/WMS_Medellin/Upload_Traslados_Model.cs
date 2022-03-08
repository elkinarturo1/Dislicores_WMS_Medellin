using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sauron_Monitor_Integraciones.Shared.WMS_Medellin
{
    public class Upload_Traslados_Model
    {
        public List<Upload_Traslados_Model_Encabezado> listadoEncabezado { get; set; }

        public List<Upload_Traslados_Model_Detalle> listadoDetalle { get; set; }

        public List<Upload_Ajustes_Encabezado_Model> listadoAjustesEncabezado { get; set; }

        public List<Upload_Ajustes_Detalle_Model> listadoAjustesDetalle { get; set; }
    }
}
