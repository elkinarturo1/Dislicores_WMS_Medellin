using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sauron_Monitor_Integraciones.Shared.Commercial_Effectiveness
{
    public class ClientesGeolocalizados_Model
    {
        public string id { get; set; }
        public string ts { get; set; }
        public string fechaPeticion { get; set; }
        public string idTercero { get; set; }
        public string idSucursal { get; set; }
        public string f015_rowid { get; set; }
        public string direccion { get; set; }
        public string codigoPostal { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        public string estrato { get; set; }
        public string barrio { get; set; }
        public string comunaLocalidad { get; set; }
        public string zonaLogistica { get; set; }
        public string diasEntrega { get; set; }
        public string Zona1 { get; set; }
        public string Zona2 { get; set; }
        public string Zona3 { get; set; }
        public string Zona4 { get; set; }
        public string bitError { get; set; }
        public string resultadoSitiData { get; set; }
        public string detalle { get; set; }
    }
}
