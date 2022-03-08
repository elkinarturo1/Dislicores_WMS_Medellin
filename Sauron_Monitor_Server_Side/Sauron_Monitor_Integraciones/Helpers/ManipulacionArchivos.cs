using OfficeOpenXml;
using System.Data;
using System.Xml;

namespace Sauron_Monitor_Integraciones.Helpers
{
    public class ManipulacionArchivos
    {

        public string leerPlantilla_a_Importar(string rutaArchivo, ref bool bitError)
        {

            //PlantillasSQL objSQL = new PlantillasSQL();
            DataSet ds = new DataSet();
          
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///Leer Excel
            try
            {

                //string filePath = "D:\\Repositorios\\GestorModular\\Presentacion\\wwwroot\\Excel\\Plantillas\\demo3_xlsx.xlsx";

                string strXML = "";
                strXML = "<MyDataSet>";

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (var excelPack = new ExcelPackage())
                {

                    //Load excel stream
                    using (var stream = File.OpenRead(rutaArchivo))
                    {
                        excelPack.Load(stream);
                    }


                    //Recorrido por pagina
                    //Lets Deal with first worksheet.(You may iterate here if dealing with multiple sheets)           
                    for (int i = 0; i < excelPack.Workbook.Worksheets.Count; i++)
                    {

                        //string nombreHoja = "hoja";

                        //ws.Dimension.Columns
                        //ws.Dimension.End.Column
                        //ws.Dimension.End.Row
                        //item.Address
                        //item.Rows
                        //item.value
                        //item.Text

                        var ws = excelPack.Workbook.Worksheets[i];
                        string nombreHoja = ws.Name;
                        nombreHoja = nombreHoja.Replace(" ", "_");

                        try
                        {

                            //Valido que las celdas tengan datos
                            if (ws.Cells.Worksheet.Dimension != null)
                            {

                                //Recorido Primera Hoja
                                if (i == 0)
                                {

                                    //ws.Cells[1, 2].Value.ToString() = 1: Fila - 2: Columna

                                    //Recorrido filas                                   
                                    for (int fila = 2; fila <= ws.Dimension.End.Row; fila++)
                                    {

                                        strXML += "<T_Equivalencias_Criterios_UN>" + Environment.NewLine;
                                        strXML += "<id>" + ws.Cells[fila, 1].Value.ToString() + "</id>" + Environment.NewLine;
                                        strXML += "<idPlan_Canal>" + ws.Cells[fila, 2].Value.ToString() + "</idPlan_Canal>" + Environment.NewLine;
                                        strXML += "<descPlan_Canal>" + ws.Cells[fila, 3].Value.ToString() + "</descPlan_Canal>" + Environment.NewLine;
                                        strXML += "<idCriterio_Canal>" + ws.Cells[fila, 4].Value.ToString() + "</idCriterio_Canal>" + Environment.NewLine;
                                        strXML += "<descCriterio_Canal>" + ws.Cells[fila, 5].Value.ToString() + "</descCriterio_Canal>" + Environment.NewLine;
                                        strXML += "<idPlan_SubCanal>" + ws.Cells[fila, 6].Value.ToString() + "</idPlan_SubCanal>" + Environment.NewLine;
                                        strXML += "<descPlan_SubCanal>" + ws.Cells[fila, 7].Value.ToString() + "</descPlan_SubCanal>" + Environment.NewLine;
                                        strXML += "<idCriterio_SubCanal>" + ws.Cells[fila, 8].Value.ToString() + "</idCriterio_SubCanal>" + Environment.NewLine;
                                        strXML += "<descCriterio_SubCanal>" + ws.Cells[fila, 9].Value.ToString() + "</descCriterio_SubCanal>" + Environment.NewLine;
                                        strXML += "<idPlan_Segmento>" + ws.Cells[fila, 10].Value.ToString() + "</idPlan_Segmento>" + Environment.NewLine;
                                        strXML += "<descPlan_Segmento>" + ws.Cells[fila, 11].Value.ToString() + "</descPlan_Segmento>" + Environment.NewLine;
                                        strXML += "<idCriterio_Segmento>" + ws.Cells[fila, 12].Value.ToString() + "</idCriterio_Segmento>" + Environment.NewLine;
                                        strXML += "<descCriterio_Segmento>" + ws.Cells[fila, 13].Value.ToString() + "</descCriterio_Segmento>" + Environment.NewLine;
                                        strXML += "<idPlan_SubSegmento>" + ws.Cells[fila, 14].Value.ToString() + "</idPlan_SubSegmento>" + Environment.NewLine;
                                        strXML += "<descPlan_SubSegmento>" + ws.Cells[fila, 15].Value.ToString() + "</descPlan_SubSegmento>" + Environment.NewLine;
                                        strXML += "<idCriterio_SubSegmento>" + ws.Cells[fila, 16].Value.ToString() + "</idCriterio_SubSegmento>" + Environment.NewLine;
                                        strXML += "<descCriterio_SubSegmento>" + ws.Cells[fila, 17].Value.ToString() + "</descCriterio_SubSegmento>" + Environment.NewLine;
                                        strXML += "<idPlan_Canal_Diageo>" + ws.Cells[fila, 18].Value.ToString() + "</idPlan_Canal_Diageo>" + Environment.NewLine;
                                        strXML += "<descPlan_Canal_Diageo>" + ws.Cells[fila, 19].Value.ToString() + "</descPlan_Canal_Diageo>" + Environment.NewLine;
                                        strXML += "<idCriterio_Canal_Diageo>" + ws.Cells[fila, 20].Value.ToString() + "</idCriterio_Canal_Diageo>" + Environment.NewLine;
                                        strXML += "<descCriterio_Canal_Diageo>" + ws.Cells[fila, 21].Value.ToString() + "</descCriterio_Canal_Diageo>" + Environment.NewLine;
                                        strXML += "<idPlan_SubCanal_Diageo>" + ws.Cells[fila, 22].Value.ToString() + "</idPlan_SubCanal_Diageo>" + Environment.NewLine;
                                        strXML += "<descPlan_SubCanal_Diageo>" + ws.Cells[fila, 23].Value.ToString() + "</descPlan_SubCanal_Diageo>" + Environment.NewLine;
                                        strXML += "<idCriterio_SubCanal_Diageo>" + ws.Cells[fila, 24].Value.ToString() + "</idCriterio_SubCanal_Diageo>" + Environment.NewLine;
                                        strXML += "<descCriterio_SubCanal_Diageo>" + ws.Cells[fila, 25].Value.ToString() + "</descCriterio_SubCanal_Diageo>" + Environment.NewLine;
                                        strXML += "<idPlan_Segmento_Diageo>" + ws.Cells[fila, 26].Value.ToString() + "</idPlan_Segmento_Diageo>" + Environment.NewLine;
                                        strXML += "<descPlan_Segmento_Diageo>" + ws.Cells[fila, 27].Value.ToString() + "</descPlan_Segmento_Diageo>" + Environment.NewLine;
                                        strXML += "<idCriterio_Segmento_Diageo>" + ws.Cells[fila, 28].Value.ToString() + "</idCriterio_Segmento_Diageo>" + Environment.NewLine;
                                        strXML += "<descCriterio_Segmento_Diageo>" + ws.Cells[fila, 29].Value.ToString() + "</descCriterio_Segmento_Diageo>" + Environment.NewLine;
                                        strXML += "<idPlan_SubSegmento_Diageo>" + ws.Cells[fila, 30].Value.ToString() + "</idPlan_SubSegmento_Diageo>" + Environment.NewLine;
                                        strXML += "<descPlan_SubSegmento_Diageo>" + ws.Cells[fila, 31].Value.ToString() + "</descPlan_SubSegmento_Diageo>" + Environment.NewLine;
                                        strXML += "<idCriterio_SubSegmento_Diageo>" + ws.Cells[fila, 32].Value.ToString() + "</idCriterio_SubSegmento_Diageo>" + Environment.NewLine;
                                        strXML += "<descCriterio_SubSegmento_Diageo>" + ws.Cells[fila, 33].Value.ToString() + "</descCriterio_SubSegmento_Diageo>" + Environment.NewLine;
                                        strXML += "<codUN>" + ws.Cells[fila, 34].Value.ToString() + "</codUN>" + Environment.NewLine;
                                        strXML += "<UN>" + ws.Cells[fila, 35].Value.ToString() + "</UN>" + Environment.NewLine;
                                        strXML += "<codCanalCliente>" + ws.Cells[fila, 36].Value.ToString() + "</codCanalCliente>" + Environment.NewLine;
                                        strXML += "<canalCliente>" + ws.Cells[fila, 37].Value.ToString() + "</canalCliente>" + Environment.NewLine;
                                        strXML += "</T_Equivalencias_Criterios_UN>" + Environment.NewLine;

                                        fila++;

                                    }

                                }




                                //Recorido Segunda Hoja
                                if (i == 1)
                                {
                                    for (int fila = 2; fila <= ws.Dimension.End.Row; fila++)
                                    {

                                        strXML += "<T_Equivalencias_Criterio_Nielse_D>" + Environment.NewLine;
                                        strXML += "<id>" + ws.Cells[fila, 1].Value.ToString() + "</id>" + Environment.NewLine;
                                        strXML += "<CODIGO_VENDEDOR>" + ws.Cells[fila, 2].Value.ToString() + "</CODIGO_VENDEDOR>" + Environment.NewLine;
                                        strXML += "<DESCRIPCION_VENDEDOR>" + ws.Cells[fila, 3].Value.ToString() + "</DESCRIPCION_VENDEDOR>" + Environment.NewLine;
                                        strXML += "<CODIGO_PLAN>" + ws.Cells[fila, 4].Value.ToString() + "</CODIGO_PLAN>" + Environment.NewLine;
                                        strXML += "<DESCRIPCION_PLAN>" + ws.Cells[fila, 5].Value.ToString() + "</DESCRIPCION_PLAN>" + Environment.NewLine;
                                        strXML += "<CODIGO_CRITERIO>" + ws.Cells[fila, 6].Value.ToString() + "</CODIGO_CRITERIO>" + Environment.NewLine;
                                        strXML += "<DESC_CRITERIO>" + ws.Cells[fila, 7].Value.ToString() + "</DESC_CRITERIO>" + Environment.NewLine;
                                        strXML += "</T_Equivalencias_Criterio_Nielse_D>" + Environment.NewLine;

                                    }
                                }


                                //Recorido Tercera Hoja
                                if (i == 2)
                                {
                                   
                                    for (int fila = 2; fila <= ws.Dimension.End.Row; fila++)
                                    {

                                        strXML += "<T_Equivalencias_NoTocar>" + Environment.NewLine;
                                        strXML += "<id>" + ws.Cells[fila, 1].Value.ToString() + "</id>" + Environment.NewLine;
                                        strXML += "<CODIGO_VENDEDOR>" + ws.Cells[fila, 2].Value.ToString() + "</CODIGO_VENDEDOR>" + Environment.NewLine;
                                        strXML += "<DESCRIPCION_VENDEDOR>" + ws.Cells[fila, 3].Value.ToString() + "</DESCRIPCION_VENDEDOR>" + Environment.NewLine;
                                        strXML += "<CODIGO_PLAN>" + ws.Cells[fila, 4].Value.ToString() + "</CODIGO_PLAN>" + Environment.NewLine;
                                        strXML += "<DESCRIPCION_PLAN>" + ws.Cells[fila, 5].Value.ToString() + "</DESCRIPCION_PLAN>" + Environment.NewLine;
                                        strXML += "<CODIGO_CRITERIO>" + ws.Cells[fila, 6].Value.ToString() + "</CODIGO_CRITERIO>" + Environment.NewLine;
                                        strXML += "<DESC_CRITERIO>" + ws.Cells[fila, 7].Value.ToString() + "</DESC_CRITERIO>" + Environment.NewLine;
                                        strXML += "</T_Equivalencias_NoTocar>" + Environment.NewLine;

                                    }

                                }



                                ////Recorrido Columnas
                                //for (int columna = 1; columna <= listado_Encabezados.Count; columna++)
                                //{                                           

                                //    //string valor = ws.Cells[fila, columna, fila, columna].Value.ToString(); //Sirve para reaqlizar recorridos ForEach desde hasta
                                //    if (ws.Cells[fila, columna].Value != null)
                                //    {
                                //        valor = ws.Cells[fila, columna].Value.ToString();
                                //    }
                                //    else
                                //    {
                                //        valor = "";
                                //    }                                           

                                //}

                            }

                        }
                        catch (Exception ex)
                        {
                            bitError = true;
                            return "Ha ocurrido un error al leer el excel " + ex.Message;                            
                        }

                    }

                }

                strXML += "</MyDataSet>";

                strXML = strXML.Replace("&", "y");

                TextReader txtReader1 = new StringReader(strXML);
                XmlReader reader1 = new XmlTextReader(txtReader1);
                ds.ReadXml(reader1);

                if (ds.Tables.Count > 0)
                {

                    foreach (DataTable dt in ds.Tables)
                    {
                        try
                        {

                            string strConexion = Leer_JSON.strConexion_Commercial_Effectiveness();

                            ModuloSQL.limpiarTabla(strConexion, dt.TableName);
                            ModuloSQL.Guardar_en_BD_x_BulkCopy(strConexion, dt, dt.TableName);


                            //objSQL.Guardar_en_BD_x_BulkCopy(dt, dt.TableName);

                            //ultimaPlantilla = objSQL.sp_Max_Id_Plantilla();

                            //listaResultado.Add(dt.TableName + " Importada Correctamente.");

                        }
                        catch (Exception ex)
                        {
                            bitError = true;
                            return "Ha ocurrido un error al guardar en base de datos " + ex.Message;                            
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                bitError = true;
                return "Ha ocurrido un error general en el metodo leerPlantilla_a_Importar " + ex.Message;                
            }

            return "Proceso Terminado Correctamente";

        }

    }
}
