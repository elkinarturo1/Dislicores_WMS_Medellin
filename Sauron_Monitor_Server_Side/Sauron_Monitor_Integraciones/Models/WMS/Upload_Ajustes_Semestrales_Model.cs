using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sauron_Monitor_Integraciones.Shared.WMS
{
    public class Upload_Ajustes_Semestrales_Model
    {       
        public bool bitEnviar { get; set; } = false;
        public string f350_id_clase_docto { get; set; }
        public int f470_nro_registro { get; set; }
        public string f470_id_concepto { get; set; }
        public string f470_id_motivo { get; set; }
        public string f470_cant_base { get; set; }
        public string f470_costo_prom_uni { get; set; }
        public string f470_notas { get; set; }
        public string f470_id_ubicación_aux { get; set; }
        public string f470_id_ubicación_aux_ent { get; set; }
        public string f470_referencia_item { get; set; }
        public string f470_id_un_movto { get; set; }
        public string f470_id_bodega { get; set; }       

    }
}
