using Sauron_Monitor_Integraciones.Shared.WMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Sauron_Monitor_Integraciones.EstructurasXML
{
    public static class xml_Transferencias_TWA
    {

        public static string generarEstructura(List<Consulta_Inventario_WMS_Siesa_Model> listadoDatos)
        {

            string strXML = "";  

            try
            {

                string bodegaSalida = listadoDatos.FirstOrDefault().Bodega;
                string numeroControl = int.Parse(listadoDatos.FirstOrDefault().CONTROLKEY).ToString();

                strXML += "<MyDataSet>" + Environment.NewLine;

                strXML += "<Inicial>" + Environment.NewLine;
                strXML += "<F_CIA>2</F_CIA>" + Environment.NewLine;
                strXML += "</Inicial>" + Environment.NewLine;

                string fechaDoc = DateTime.Now.ToString("yyyyMMdd");


                strXML += "<Documentos>" + Environment.NewLine;
                strXML += "<F_CIA>2</F_CIA>" + Environment.NewLine;
                strXML += "<f350_id_co>001</f350_id_co>" + Environment.NewLine;
                strXML += "<f350_id_tipo_docto>TWA</f350_id_tipo_docto>" + Environment.NewLine;
                strXML += "<f350_consec_docto>" + numeroControl  + "</f350_consec_docto>" + Environment.NewLine;
                strXML += "<f350_fecha>" + fechaDoc + "</f350_fecha>" + Environment.NewLine;
                strXML += "<f350_notas>Transferencia</f350_notas>" + Environment.NewLine;
                strXML += "<f450_id_bodega_salida>" + bodegaSalida + "</f450_id_bodega_salida>" + Environment.NewLine;
                strXML += "<f450_id_bodega_entrada>01TCS</f450_id_bodega_entrada>" + Environment.NewLine;
                strXML += "</Documentos>" + Environment.NewLine;

                int contador = 1;
                foreach (Consulta_Inventario_WMS_Siesa_Model registro in listadoDatos)
                {

                    int cantidad = int.Parse(registro.diferencia);
                    cantidad = (cantidad < 0) ? (cantidad * -1) : cantidad;


                    strXML += "<Movimientos>" + Environment.NewLine;
                    strXML += "<F_CIA>2</F_CIA>" + Environment.NewLine;
                    strXML += "<f470_id_co>001</f470_id_co>" + Environment.NewLine;
                    strXML += "<f470_id_tipo_docto>TWA</f470_id_tipo_docto>" + Environment.NewLine;
                    strXML += "<f470_consec_docto>" + numeroControl + "</f470_consec_docto>" + Environment.NewLine;
                    strXML += "<f470_nro_registro>" + contador + "</f470_nro_registro>" + Environment.NewLine;
                    strXML += "<f470_id_bodega>" + registro.Bodega + "</f470_id_bodega>" + Environment.NewLine;
                    strXML += "<f470_id_motivo>06</f470_id_motivo>" + Environment.NewLine;
                    strXML += "<f470_id_co_movto>001</f470_id_co_movto>" + Environment.NewLine;
                    strXML += "<f470_id_unidad_medida>UND</f470_id_unidad_medida>" + Environment.NewLine;
                    strXML += "<f470_cant_base>" + cantidad + "</f470_cant_base>" + Environment.NewLine;
                    strXML += "<f470_notas>Prueba</f470_notas>" + Environment.NewLine;
                    strXML += "<f470_referencia_item>" + registro.SKU + "</f470_referencia_item>" + Environment.NewLine;
                    strXML += "<f470_id_un_movto>01</f470_id_un_movto>" + Environment.NewLine;
                    strXML += "</Movimientos>" + Environment.NewLine;

                    contador++;

                }                
              

                strXML += "<Final>" + Environment.NewLine;
                strXML += "<F_CIA>2</F_CIA>" + Environment.NewLine;
                strXML += "</Final>" + Environment.NewLine;

                strXML += "</MyDataSet>" + Environment.NewLine;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return strXML;

        }

    }
}
