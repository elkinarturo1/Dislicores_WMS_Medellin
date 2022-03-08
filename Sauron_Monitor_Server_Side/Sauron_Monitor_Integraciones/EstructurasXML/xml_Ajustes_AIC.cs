using Sauron_Monitor_Integraciones.Shared.WMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sauron_Monitor_Integraciones.EstructurasXML
{
    public class xml_Ajustes_AIC
    {

        public static string generarEstructura(List<Estructura_Consulta_Ajustes_WMS_Siesa_Model> listadoDatos)
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


                strXML += "<Documentos>";
                strXML += "<F_CIA>2</F_CIA>";
                strXML += "<f350_id_co>001</f350_id_co>";
                strXML += "<f350_id_tipo_docto>AIC</f350_id_tipo_docto>";
                strXML += "<f350_consec_docto>" + numeroControl + "</f350_consec_docto>";
                strXML += "<f350_fecha>" + fechaDoc + "</f350_fecha>";
                //strXML += "<f350_id_tercero>" + registro.Item("f350_id_tercero").ToString + "</f350_id_tercero>"
                //strXML += "<f350_id_clase_docto>" + registro.Item("f350_id_clase_docto").ToString + "</f350_id_clase_docto>"
                //strXML += "<f350_ind_estado>" + registro.Item("f350_ind_estado").ToString + "</f350_ind_estado>"
                strXML += "<f350_notas>Ajuste</f350_notas>";
                strXML += "<f450_id_concepto>07</f450_id_concepto>";
                strXML += "<f450_docto_alterno>" + numeroControl + "</f450_docto_alterno>";

                strXML += "</Documentos>";

                int contador = 1;
                foreach (Estructura_Consulta_Ajustes_WMS_Siesa_Model registro in listadoDatos)
                {

                    int cantidad = int.Parse(registro.diferencia);
                    cantidad = (cantidad < 0) ? (cantidad * -1) : cantidad;


                    strXML += "<Movimientos>";
                    strXML += "<F_CIA>2</F_CIA>";
                    strXML += "<f470_id_co>001</f470_id_co>";
                    strXML += "<f470_id_tipo_docto>AIC</f470_id_tipo_docto>";
                    strXML += "<f470_consec_docto>" + numeroControl + "</f470_consec_docto>";
                    strXML += "<f470_nro_registro>" + registro.numregistro + "</f470_nro_registro>";
                    strXML += "<f470_id_concepto>07</f470_id_concepto>";
                    strXML += "<f470_id_motivo>07</f470_id_motivo>";
                    strXML += "<f470_id_co_movto>001</f470_id_co_movto>";
                    strXML += "<f470_id_unidad_medida>UND</f470_id_unidad_medida>";
                    strXML += "<f470_cant_base>" + cantidad + "</f470_cant_base>";
                    //strXML += "<f470_costo_prom_uni>" + registro["f470_costo_prom_uni").ToString + "</f470_costo_prom_uni>";
                    strXML += "<f470_notas>Ajuste</f470_notas>";
                    strXML += "<f470_id_ccosto_movto></f470_id_ccosto_movto>";
                    strXML += "<f470_id_ubicación_aux></f470_id_ubicación_aux>";
                    strXML += "<f470_id_ubicación_aux_ent></f470_id_ubicación_aux_ent>";
                    strXML += "<f470_referencia_item>" + registro.SKU + "</f470_referencia_item>";
                    //strXML += "<f470_id_un_movto>" + registro["f470_id_un_movto").ToString + "</f470_id_un_movto>";
                    strXML += "<f470_id_bodega>" + registro.Bodega + "</f470_id_bodega>";
                    strXML += "</Movimientos>";
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
