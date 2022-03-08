using Sauron_Monitor_Integraciones.DAO.Commercial_Effectiveness;
using Sauron_Monitor_Integraciones.Models;
using Sauron_Monitor_Integraciones.Models.Commercial_Effectiveness;
using Sauron_Monitor_Integraciones.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Sauron_Monitor_Integraciones.Helpers
{
    public static class ModuloWS
    {

        public static string generarPlano_ConsumoWSGT(int idDocumento, string strNombreDocumento, DataSet ds, ref string resultado)
        {

            string rutaPlano = @"C:\inetpub\wwwroot\GTIntegrationWMS\Planos\";
            string plano = "";

            try
            {


                //List<string> strDetailIDList = new List<string>();
                //foreach (DataRow row in ds.Tables[0].Rows)
                //{
                //    strDetailIDList.Add(row["Ad_detailsID"].ToString());
                //}
                //string[] strDetailID = strDetailIDList.ToArray();

                WSGT.GenerarPlanoXMLRequest obPeticion = new WSGT.GenerarPlanoXMLRequest();
                obPeticion.idDocumento = idDocumento;
                obPeticion.strNombreDocumento = strNombreDocumento;
                obPeticion.idCompania = 2;
                obPeticion.strCompania = "2";
                obPeticion.strUsuario = "gt";
                obPeticion.strClave = "gt";
                obPeticion.dsFuenteDatos = ds;
                obPeticion.Path = rutaPlano;
                obPeticion.strResultado = resultado;

                WSGT.wsGenerarPlanoSoapClient client1 = new WSGT.wsGenerarPlanoSoapClient(WSGT.wsGenerarPlanoSoapClient.EndpointConfiguration.wsGenerarPlanoSoap);
                var response = client1.GenerarPlanoXML(obPeticion);
                plano = response.GenerarPlanoXMLResult;
                rutaPlano = response.Path;
                resultado = response.strResultado;

            }
            catch (Exception ex)
            {
                string res = ex.Message;
            }

            return plano;

        }

        public static async Task<string> importarDatosUNOEE(string plano, string proceso)
        {

            LogModel_ActualizarNielsenD objLog = new LogModel_ActualizarNielsenD(); ;
            string resultado = "";
            string strXMLUNOEE = "";
            UNOEE_Peticion_Model modeloUNOEE = new UNOEE_Peticion_Model();

            try
            {

                switch (proceso)
                {
                    case "ce":
                        modeloUNOEE = Leer_JSON.leerJson_configUNOEE_CE();
                        break;
                    default:
                        break;
                }


                strXMLUNOEE += "<Importar>" + Environment.NewLine;
                //strXMLUNOEE += "<NombreConexion>SIESA_ATENEA</NombreConexion>" + Environment.NewLine;
                strXMLUNOEE += "<NombreConexion>" + modeloUNOEE.NombreConexion + "</NombreConexion>" + Environment.NewLine;
                strXMLUNOEE += "<IdCia>" + modeloUNOEE.IdCia + "</IdCia>" + Environment.NewLine;
                strXMLUNOEE += "<Usuario>" + modeloUNOEE.Usuario + "</Usuario>" + Environment.NewLine;
                strXMLUNOEE += "<Clave>" + modeloUNOEE.Clave + "</Clave>" + Environment.NewLine;
                strXMLUNOEE += plano;
                strXMLUNOEE += "</Importar>" + Environment.NewLine;


                WSUNOEE.ImportarXMLRequest obPeticion = new WSUNOEE.ImportarXMLRequest();
                //obPeticion.pvstrDatos = "<Importar><NombreConexion>WSREAL</NombreConexion><IdCia>2</IdCia><Usuario>elkin.munoz</Usuario><Clave>Dislicores2020*.</Clave><Datos><Linea>000000100000001002</Linea><Linea>000000202000008002166666         666666                      N2Prueba                                                                                                                                                                                                                                                  100000homero                                            av siempre viva                                                                                                         16905001                                        2222222                                           prueba@gmail.com                                                                                                                                                                                                                                               19900101001011311222333                                         </Linea><Linea>000000399990001002</Linea></Datos></Importar>";
                obPeticion.pvstrDatos = strXMLUNOEE;
                obPeticion.printTipoError = 999;

                WSUNOEE.WSUNOEESoapClient client1 = new WSUNOEE.WSUNOEESoapClient(WSUNOEE.WSUNOEESoapClient.EndpointConfiguration.WSUNOEESoap);

                client1.InnerChannel.OperationTimeout = new TimeSpan(0, 10, 0);

                var response = await client1.ImportarXMLAsync(obPeticion);

                //var resultSiesa = int.Parse(response.ToString());
                int resultSiesa = int.Parse(response.printTipoError.ToString());
                objLog.resultado_UNOEE = short.Parse(resultSiesa.ToString());

                switch (resultSiesa)
                {
                    case 0:
                        resultado = "Importacion Exitosa ";
                        break;
                    case 1:
                        resultado = "Error : 1 - al importar a Siesa Resultado : " + response.ImportarXMLResult.Nodes[1].ToString() + " < br /> Datos enviados: < br /> " + strXMLUNOEE;
                        break;
                    case 2:
                        resultado = "Error : 2 - El impodatos no envio algun parametro " + strXMLUNOEE;
                        break;
                    case 3:
                        resultado = "Error : 3 - El usuario o la contraseña que ingreso no son validos " + strXMLUNOEE;
                        break;
                    case 4:
                        resultado = "Error : 4 - La version del impodatos no se corresponde con la version del ERP o el impodatos esta en una maquina que no tiene cliente Siesa " + strXMLUNOEE;
                        break;
                    case 5:
                        resultado = "Error : 5 - La base de datos no existe o están ingresándole un parámetro erróneo a la hora de especificar la conexión. " + strXMLUNOEE;
                        break;
                    case 6:
                        resultado = "Error : 6 - El archivo que se está especificando en la ruta de los parámetros del .BAT no existe " + strXMLUNOEE;
                        break;
                    case 7:
                        resultado = "Error : 7 - El archivo que se está especificando en la ruta de los parámetros del .BAT no es valido " + strXMLUNOEE;
                        break;
                    case 8:
                        resultado = "Error : 8 - Hay un problema con la tabla en la base de datos donde se ingresaran los archivos " + strXMLUNOEE;
                        break;
                    case 9:
                        resultado = "Error : 9 - La compañía que se ingresó en los parámetros del .BAT no es valida " + strXMLUNOEE;
                        break;
                    case 10:
                        resultado = "Error : 10 - Error desconocido " + strXMLUNOEE;
                        break;
                    case 99:
                        resultado = "Error : 99 - Error de tipo diferente a los anteriores, normalmente de permisos a nivel del ERP " + strXMLUNOEE;
                        break;
                }              

            }
            catch (Exception ex)
            {
                resultado = "Error al consumir el servicio de Siesa: " + ex.Message;
            }

            return resultado;

        }


        public static string generar_XMLUNOEE(DataSet ds)
        {

            string rutaPlano = @"C:\inetpub\wwwroot\GTIntegrationWMS\Planos\";
            string plano = "";
            string resultado = "";

            try
            {


                //List<string> strDetailIDList = new List<string>();
                //foreach (DataRow row in ds.Tables[0].Rows)
                //{
                //    strDetailIDList.Add(row["Ad_detailsID"].ToString());
                //}
                //string[] strDetailID = strDetailIDList.ToArray();

                WSGT.GenerarPlanoXMLRequest obPeticion = new WSGT.GenerarPlanoXMLRequest();
                obPeticion.idDocumento = 80691;
                obPeticion.strNombreDocumento = "WMS_AJUSTES_ENTRADAS_SALIDAS_AIC";
                obPeticion.idCompania = 2;
                obPeticion.strCompania = "2";
                obPeticion.strUsuario = "gt";
                obPeticion.strClave = "gt";
                obPeticion.dsFuenteDatos = ds;
                obPeticion.Path = rutaPlano;
                obPeticion.strResultado = resultado;

                WSGT.wsGenerarPlanoSoapClient client1 = new WSGT.wsGenerarPlanoSoapClient(WSGT.wsGenerarPlanoSoapClient.EndpointConfiguration.wsGenerarPlanoSoap);
                var response = client1.GenerarPlanoXML(obPeticion);
                plano = response.GenerarPlanoXMLResult;
                rutaPlano = response.Path;
                resultado = response.strResultado;

            }
            catch (Exception ex)
            {
                string res = ex.Message;
            }

            return plano;

        }



    }
}
