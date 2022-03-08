using Sauron_Monitor_Integraciones.DAO;
using Sauron_Monitor_Integraciones.DAO.Commercial_Effectiveness;
using Sauron_Monitor_Integraciones.Helpers;
using Sauron_Monitor_Integraciones.Models;
using Sauron_Monitor_Integraciones.Models.Commercial_Effectiveness;
using Sauron_Monitor_Integraciones.Shared;
using Sauron_Monitor_Integraciones.Shared.Commercial_Effectiveness;
using System.Data;
using System.Xml;

namespace Sauron_Monitor_Integraciones.Bussines.Commercial_Effectiveness
{
    public class ActualizacionUN_Bl
    {

        RespuestaJson respuestaJson = new RespuestaJson();
        string strConexion = "";


        public RespuestaJson consultarEquivalenciasUN()
        {

            List<T_Equivalencias_Criterios_UN> listado_Equiv_UN = new List<T_Equivalencias_Criterios_UN>();
            List<T_Equivalencias_Criterio_Nielse_D> listado_NielsenD = new List<T_Equivalencias_Criterio_Nielse_D>();
            List<T_Equivalencias_NoTocar> listado_NoTocar = new List<T_Equivalencias_NoTocar>();
            UN_Update_Model listadoDatos = new UN_Update_Model();
            DataSet ds = new DataSet();


            try
            {

                ds = ActualizacionUN_DAO.consultar_Equivalencias_UN();
                respuestaJson.resultado = ds.GetXml();

                //respuestaJson.ds = ds;
            }
            catch (Exception ex)
            {
                respuestaJson.bitError = true;
                respuestaJson.resultado = ex.Message;
            }



            try
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow registro in ds.Tables[0].Rows)
                        {
                            List<T_Equivalencias_Criterios_UN> listado = new List<T_Equivalencias_Criterios_UN>();
                            T_Equivalencias_Criterios_UN objDatos = new T_Equivalencias_Criterios_UN();

                            objDatos.id = registro["id"].ToString();
                            objDatos.idPlan_Canal = registro["idPlan_Canal"].ToString();
                            objDatos.descPlan_Canal = registro["descPlan_Canal"].ToString();
                            objDatos.idCriterio_Canal = registro["idCriterio_Canal"].ToString();
                            objDatos.descCriterio_Canal = registro["descCriterio_Canal"].ToString();
                            objDatos.idPlan_SubCanal = registro["idPlan_SubCanal"].ToString();
                            objDatos.descPlan_SubCanal = registro["descPlan_SubCanal"].ToString();
                            objDatos.idCriterio_SubCanal = registro["idCriterio_SubCanal"].ToString();
                            objDatos.descCriterio_SubCanal = registro["descCriterio_SubCanal"].ToString();
                            objDatos.idPlan_Segmento = registro["idPlan_Segmento"].ToString();
                            objDatos.descPlan_Segmento = registro["descPlan_Segmento"].ToString();
                            objDatos.idCriterio_Segmento = registro["idCriterio_Segmento"].ToString();
                            objDatos.descCriterio_Segmento = registro["descCriterio_Segmento"].ToString();
                            objDatos.idPlan_SubSegmento = registro["idPlan_SubSegmento"].ToString();
                            objDatos.descPlan_SubSegmento = registro["descPlan_SubSegmento"].ToString();
                            objDatos.idCriterio_SubSegmento = registro["idCriterio_SubSegmento"].ToString();
                            objDatos.descCriterio_SubSegmento = registro["descCriterio_SubSegmento"].ToString();
                            objDatos.idPlan_Canal_Diageo = registro["idPlan_Canal_Diageo"].ToString();
                            objDatos.descPlan_Canal_Diageo = registro["descPlan_Canal_Diageo"].ToString();
                            objDatos.idCriterio_Canal_Diageo = registro["idCriterio_Canal_Diageo"].ToString();
                            objDatos.descCriterio_Canal_Diageo = registro["descCriterio_Canal_Diageo"].ToString();
                            objDatos.idPlan_SubCanal_Diageo = registro["idPlan_SubCanal_Diageo"].ToString();
                            objDatos.descPlan_SubCanal_Diageo = registro["descPlan_SubCanal_Diageo"].ToString();
                            objDatos.idCriterio_SubCanal_Diageo = registro["idCriterio_SubCanal_Diageo"].ToString();
                            objDatos.descCriterio_SubCanal_Diageo = registro["descCriterio_SubCanal_Diageo"].ToString();
                            objDatos.idPlan_Segmento_Diageo = registro["idPlan_Segmento_Diageo"].ToString();
                            objDatos.descPlan_Segmento_Diageo = registro["descPlan_Segmento_Diageo"].ToString();
                            objDatos.idCriterio_Segmento_Diageo = registro["idCriterio_Segmento_Diageo"].ToString();
                            objDatos.descCriterio_Segmento_Diageo = registro["descCriterio_Segmento_Diageo"].ToString();
                            objDatos.idPlan_SubSegmento_Diageo = registro["idPlan_SubSegmento_Diageo"].ToString();
                            objDatos.descPlan_SubSegmento_Diageo = registro["descPlan_SubSegmento_Diageo"].ToString();
                            objDatos.idCriterio_SubSegmento_Diageo = registro["idCriterio_SubSegmento_Diageo"].ToString();
                            objDatos.descCriterio_SubSegmento_Diageo = registro["descCriterio_SubSegmento_Diageo"].ToString();
                            objDatos.codUN = registro["codUN"].ToString();
                            objDatos.UN = registro["UN"].ToString();
                            objDatos.codCanalCliente = registro["codCanalCliente"].ToString();
                            objDatos.canalCliente = registro["canalCliente"].ToString();

                            listado_Equiv_UN.Add(objDatos);

                        }


                        foreach (DataRow registro in ds.Tables[1].Rows)
                        {
                            List<T_Equivalencias_Criterio_Nielse_D> listado = new List<T_Equivalencias_Criterio_Nielse_D>();
                            T_Equivalencias_Criterio_Nielse_D objDatos = new T_Equivalencias_Criterio_Nielse_D();

                            objDatos.id = int.Parse(registro["id"].ToString());
                            objDatos.CODIGO_VENDEDOR = registro["CODIGO_VENDEDOR"].ToString();
                            objDatos.DESCRIPCION_VENDEDOR = registro["DESCRIPCION_VENDEDOR"].ToString();
                            objDatos.CODIGO_PLAN = registro["CODIGO_PLAN"].ToString();
                            objDatos.DESCRIPCION_PLAN = registro["DESCRIPCION_PLAN"].ToString();
                            objDatos.CODIGO_CRITERIO = registro["CODIGO_CRITERIO"].ToString();
                            objDatos.DESC_CRITERIO = registro["DESC_CRITERIO"].ToString();

                            listado_NielsenD.Add(objDatos);

                        }


                        foreach (DataRow registro in ds.Tables[2].Rows)
                        {

                            T_Equivalencias_NoTocar objDatos = new T_Equivalencias_NoTocar();

                            objDatos.id = int.Parse(registro["id"].ToString());
                            objDatos.CODIGO_VENDEDOR = registro["CODIGO_VENDEDOR"].ToString();
                            objDatos.DESCRIPCION_VENDEDOR = registro["DESCRIPCION_VENDEDOR"].ToString();
                            objDatos.CODIGO_PLAN = registro["CODIGO_PLAN"].ToString();
                            objDatos.DESCRIPCION_PLAN = registro["DESCRIPCION_PLAN"].ToString();
                            objDatos.CODIGO_CRITERIO = registro["CODIGO_CRITERIO"].ToString();
                            objDatos.DESC_CRITERIO = registro["DESC_CRITERIO"].ToString();

                            listado_NoTocar.Add(objDatos);

                        }


                    }
                }


                listadoDatos.listado_Equiv_UN = listado_Equiv_UN;
                listadoDatos.listado_Equiv_NielsenD = listado_NielsenD;
                listadoDatos.listado_Equiv_NoTocar = listado_NoTocar;
                respuestaJson.datos = listadoDatos;


                //respuestaJson.ds = ds;
            }
            catch (Exception ex)
            {
                respuestaJson.bitError = true;
                respuestaJson.resultado = ex.Message;
            }

            return respuestaJson;

        }


        public RespuestaJson consultar_Terceros_x_Vendedor(string idCriterio_VEN)
        {
            List<Criterio_Cliente_Model> listadoDatos = new List<Criterio_Cliente_Model>();
            DataSet ds = new DataSet();
            bool bitError = false;


            try
            {

                ds = ActualizacionUN_DAO.sp_Proceso_2_Criterios_Vendedores_Select(idCriterio_VEN);
                respuestaJson.resultado = ds.GetXml();

            }
            catch (Exception ex)
            {
                respuestaJson.bitError = true;
                respuestaJson.resultado = ex.Message;
            }



            try
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow registro in ds.Tables[0].Rows)
                        {
                            Criterio_Cliente_Model objDatos = new Criterio_Cliente_Model();

                            objDatos.F206_ID_CIA = registro["F206_ID_CIA"].ToString();
                            objDatos.F200_ID = registro["F200_ID"].ToString();
                            objDatos.F200_NIT = registro["F200_NIT"].ToString();
                            objDatos.F207_ROWID_TERCERO = registro["F207_ROWID_TERCERO"].ToString();
                            objDatos.F207_ID_SUCURSAL = registro["F207_ID_SUCURSAL"].ToString();
                            objDatos.F207_ID_PLAN_CRITERIOS = registro["F207_ID_PLAN_CRITERIOS"].ToString();
                            objDatos.F206_ID_PLAN = registro["F206_ID_PLAN"].ToString();
                            objDatos.F206_ID = registro["F206_ID"].ToString();
                            objDatos.F206_DESCRIPCION = registro["F206_DESCRIPCION"].ToString();
                            objDatos.F206_NIVEL = registro["F206_NIVEL"].ToString();
                            objDatos.Nuevo_NielsenD = registro["Nuevo_NielsenD"].ToString();

                            listadoDatos.Add(objDatos);

                        }

                    }
                }

                respuestaJson.datos = listadoDatos;
                //respuestaJson.ds = ds;
            }
            catch (Exception ex)
            {
                respuestaJson.bitError = true;
                respuestaJson.resultado = ex.Message;
            }

            return respuestaJson;
        }



        public async Task<RespuestaJson> acutalizar_NielsenD_x_Vendedor(List<Criterio_Cliente_Model> listadoDatos)
        {

            string strXMLGT = "";


            try
            {

                strXMLGT += "<MyDataSet>" + Environment.NewLine;

                foreach (Criterio_Cliente_Model registro in listadoDatos)
                {

                    //Criterio Nilsen D
                    strXMLGT += "<Criterio>" + Environment.NewLine;
                    strXMLGT += "<F207_ID_PLAN_CRITERIOS>TI4</F207_ID_PLAN_CRITERIOS>" + Environment.NewLine;
                    strXMLGT += "<F207_ID_TERCERO>" + registro.F200_ID + "</F207_ID_TERCERO>" + Environment.NewLine;
                    strXMLGT += "<F207_ID_SUCURSAL>" + registro.F207_ID_SUCURSAL + "</F207_ID_SUCURSAL>" + Environment.NewLine;
                    strXMLGT += "<F207_ID_CRITERIO_MAYOR>" + registro.Nuevo_NielsenD + "</F207_ID_CRITERIO_MAYOR>" + Environment.NewLine;
                    strXMLGT += "</Criterio>" + Environment.NewLine;
                
                }

                strXMLGT += "</MyDataSet>" + Environment.NewLine;


                string rutaPlanos = @"E:\PlanosGT\";
                string strResultado = "";

                //Valida la estructura del XML convirtiendolo a DataSet
                DataSet dsDatos = new DataSet();
                TextReader txtReader1 = new StringReader(strXMLGT);
                XmlReader reader1 = new XmlTextReader(txtReader1);
                dsDatos.ReadXml(reader1);

                string plano = ModuloWS.generarPlano_ConsumoWSGT(119653, "Servi_Criterios_Clientes", dsDatos, ref strResultado);
                respuestaJson.resultado = await ModuloWS.importarDatosUNOEE(plano, "ce");
                
                if (respuestaJson.resultado != "Importacion Exitosa ")
                {
                    respuestaJson.bitError = true;
                }

            }
            catch (Exception ex)
            {
                respuestaJson.bitError = true;
                respuestaJson.resultado = ex.Message;
            }

            return respuestaJson;

        }

    }
}
