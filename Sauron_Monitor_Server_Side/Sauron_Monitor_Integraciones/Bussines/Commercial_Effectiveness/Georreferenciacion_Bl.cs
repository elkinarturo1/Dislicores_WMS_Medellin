using Sauron_Monitor_Integraciones.Bussines.Utiles;
using Sauron_Monitor_Integraciones.DAO.Commercial_Effectiveness;
using Sauron_Monitor_Integraciones.Helpers;
using Sauron_Monitor_Integraciones.Shared;
using Sauron_Monitor_Integraciones.Shared.Commercial_Effectiveness;
using System.Data;

namespace Sauron_Monitor_Integraciones.Bussines.Commercial_Effectiveness
{
    public class Georreferenciacion_Bl
    {


        RespuestaJson respuestaJson = new RespuestaJson();
        string strConexion = "";


        public Georreferenciacion_Bl()
        {
            strConexion = Leer_JSON.strConexion_Commercial_Effectiveness();
        }


        public RespuestaJson consultarClientes()
        {

            List<ClientesGeolocalizados_Model> listadoDatos = new List<ClientesGeolocalizados_Model>();
            DataSet ds = new DataSet();

            try
            {
                ds = Georreferenciacion_DAO.consultar_Clientes_Georreferenciados(strConexion);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        foreach (DataRow registro in ds.Tables[0].Rows)
                        {

                            ClientesGeolocalizados_Model objDatos = new ClientesGeolocalizados_Model();

                            objDatos.id = registro["id"].ToString();
                            objDatos.ts = registro["ts"].ToString();
                            objDatos.fechaPeticion = registro["fechaPeticion"].ToString();
                            objDatos.idTercero = registro["idTercero"].ToString();
                            objDatos.idSucursal = registro["idSucursal"].ToString();
                            objDatos.f015_rowid = registro["f015_rowid"].ToString();
                            objDatos.direccion = registro["direccion"].ToString();
                            objDatos.codigoPostal = registro["codigoPostal"].ToString();
                            objDatos.latitud = registro["latitud"].ToString();
                            objDatos.longitud = registro["longitud"].ToString();
                            objDatos.estrato = registro["estrato"].ToString();
                            objDatos.barrio = registro["barrio"].ToString();
                            objDatos.comunaLocalidad = registro["comunaLocalidad"].ToString();
                            objDatos.zonaLogistica = registro["zonaLogistica"].ToString();
                            objDatos.diasEntrega = registro["diasEntrega"].ToString();
                            objDatos.Zona1 = registro["Zona1"].ToString();
                            objDatos.Zona2 = registro["Zona2"].ToString();
                            objDatos.Zona3 = registro["Zona3"].ToString();
                            objDatos.Zona4 = registro["Zona4"].ToString();
                            objDatos.bitError = registro["bitError"].ToString();
                            objDatos.resultadoSitiData = registro["resultadoSitiData"].ToString();
                            objDatos.detalle = registro["detalle"].ToString();

                            listadoDatos.Add(objDatos);

                        }

                    }
                }

            }
            catch (Exception ex)
            {
                respuestaJson.bitError = true;
                respuestaJson.resultado = "Error al ejecutar la sentencia SQL : " + ex.Message;
            }

            respuestaJson.datos = listadoDatos;
            return respuestaJson;
        }




        public RespuestaJson generarExcelClientes()
        {
            DataSet ds = new DataSet();

            try
            {
                ds = Georreferenciacion_DAO.consultar_Clientes_Georreferenciados(strConexion);

                ArchivosBL archivosBL = new ArchivosBL();
                respuestaJson.resultado = archivosBL.generarExcel(ds);

            }
            catch (Exception ex)
            {
                respuestaJson.bitError = true;
                respuestaJson.resultado = "Error al ejecutar la sentencia SQL : " + ex.Message;
            }

            return respuestaJson;
        }


    }
}
