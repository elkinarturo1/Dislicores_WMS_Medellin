using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Sauron_Monitor_Integraciones.Helpers
{
    public static class ModuloConversiones
    {

        public static string truncarCampo(string campo,int cantidadCaracteres)
        {

            string resultado = "";

            if (campo != null)
            {
                if (campo.Length > cantidadCaracteres)
                {
                    campo = campo.Substring(0,cantidadCaracteres);
                }         
            }

            return campo;

        }


        public static DataSet xml_to_DataSet(string strXML)
        {

            DataSet dsDatos = new DataSet();

            try
            {
                TextReader txtReader1 = new StringReader(strXML);
                XmlReader reader1 = new XmlTextReader(txtReader1);
                dsDatos.ReadXml(reader1);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dsDatos;

        }


        public static string formatoNumeros(string campo)
        {

            string resultado = "";

            if (campo.Contains("."))
            {
                string[] temporal = campo.Split(".");
                resultado = temporal[0];
            }
            else
            {
                resultado = campo;
            }

            return resultado;

        }



    }
}
