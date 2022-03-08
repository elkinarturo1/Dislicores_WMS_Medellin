using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sauron_Monitor_Integraciones.Shared.WMS_Medellin
{
    public class Upload_Ajustes_Detalle_Model
    {

        public string CONTROLKEY { get; set; }
        public string CIA { get; set; }
        public string Bodega { get; set; }
        public string SKU { get; set; }
        public string f120_referencia { get; set; }
        public string f120_descripcion { get; set; }
        public string f132_costo_prom_uni { get; set; }
        public string Cantidad_WMS { get; set; }
        public string Cantidad_Siesa { get; set; }
        public string diferencia { get; set; }

        public string paquete { get; set; }
        public string F_CIA { get; set; }
        public string f470_id_co { get; set; }
        public string f470_id_tipo_docto { get; set; }
        public string f470_consec_docto { get; set; }
        public string f470_nro_registro { get; set; }
        public string f470_id_bodega { get; set; }
        public string f470_id_motivo { get; set; }
        public string fecha { get; set; }
        public string f470_id_co_movto { get; set; }
        public string f470_id_unidad_medida { get; set; }
        public string f470_cant_base { get; set; }
        public string f470_notas { get; set; }
        public string f470_referencia_item { get; set; }
        public string f470_id_un_movto { get; set; }

    }
}
