using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sauron_Monitor_Integraciones.Shared.WMS_Medellin
{
    public class Upload_Ajustes_Model
    {
        public List<Upload_Ajustes_Encabezado_Model> listadoEncabezado { get; set; }

        public List<Upload_Ajustes_Detalle_Model> listadoDetalle { get; set; }
    }
}
