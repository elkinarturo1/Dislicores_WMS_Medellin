using OfficeOpenXml;
using Sauron_Monitor_Integraciones.Helpers;
using Sauron_Monitor_Integraciones.Shared;
using System.Data;

namespace Sauron_Monitor_Integraciones.Bussines.Utiles
{
    public class ArchivosBL
    {

        RespuestaJson respuestaJson = new RespuestaJson();
        //LoginSQL objSQL = new LoginSQL();
        string strConexion = "";


        public ArchivosBL()
        {
            strConexion = Leer_JSON.leerJson_strConexion_WMS();
        }


        public RespuestaJson SubirArchivo(ArchivoCargadoModel archivo)
        {

            string rutaPlantillas = "";
            string rutaArchivo = "";


            //=================================================================================================
            //Validacion en base 64 del archivo          
            try
            {
                if (archivo.archivoBase64.IndexOf("data:image/jpeg;base64,") == 0)
                {
                    archivo.archivoBase64 = archivo.archivoBase64.Replace("data:image/jpeg;base64,", "");
                }
            }
            catch (Exception ex)
            {
                respuestaJson.bitError = true;
                respuestaJson.resultado = "Error subiendo el archivo al validarlo en base 64 " + ex.Message;
            }
            //=================================================================================================



            //=================================================================================================
            //Guarda en Disco
            if (respuestaJson.bitError == false)
            {
                try
                {

                    rutaPlantillas = Leer_JSON.leerJson_rutaPlantillasExcel();

                    //asignacion de nombre               
                    rutaArchivo = $"{rutaPlantillas}\\PlantilaUN.xlsx";

                    //Convierte a Bites
                    var bytesss = Convert.FromBase64String(archivo.archivoBase64);

                    //Guarda en Disco
                    using (var imageFile = new FileStream(rutaArchivo, FileMode.Create))
                    {
                        imageFile.Write(bytesss, 0, bytesss.Length);
                        imageFile.Flush();
                    }

                }
                catch (Exception ex)
                {
                    respuestaJson.bitError = true;
                    respuestaJson.resultado = "Error subiendo el archivo guardando plantilla en disco " + ex.Message;
                }
            }
            //=================================================================================================


            //=================================================================================================
            //Actualizar BD
            if (respuestaJson.bitError == false)
            {
                try
                {
                    ManipulacionArchivos objArchivos = new ManipulacionArchivos();
                    bool bitError = false;
                    respuestaJson.resultado = objArchivos.leerPlantilla_a_Importar(rutaArchivo, ref bitError);
                    respuestaJson.bitError = bitError;
                }
                catch (Exception ex)
                {
                    respuestaJson.bitError = true;
                    respuestaJson.resultado = "Error subiendo el archivo guardando plantilla en disco " + ex.Message;
                }
            }
            //=================================================================================================


            return respuestaJson;

        }

        public string generarExcel(DataSet ds)
        {

            string strNombreArchivo = "";

            try
            {

                string rutaPlantillas = Leer_JSON.leerJson_rutaPlantillasExcel();

                strNombreArchivo = $"Plantilla_{DateTime.Now.ToString("yyyyMMddmmssff")}.xlsx";
                string directorio = $"{rutaPlantillas}\\{strNombreArchivo}";
                FileInfo file = new FileInfo(directorio);

                //FileInfo file = new FileInfo(Path.Combine(strDirectorio, strnombreArchivo));

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                //ExcelPackage.LicenseContext = LicenseContext.Commercial;
                string documentacionLicencia = "https://www.epplussoftware.com/Developers/LicenseException;";


                ExcelPackage libro = new ExcelPackage(file);
                using (libro)
                {

                    libro.Workbook.Properties.Author = "Dislicores";
                    libro.Workbook.Properties.Company = "Dislicores Software";
                    libro.Workbook.Properties.Keywords = "Excel,Epplus";

                    //Asigna nombre a la Hoja
                    string strHoja = "NombreHoja";
                    ExcelWorksheet hoja = libro.Workbook.Worksheets.Add(strHoja);


                    //Se crean las columnas del encabezado
                    int numColumna = 1;
                    foreach (DataColumn columna in ds.Tables[0].Columns)
                    {                            
                        hoja.Cells[1, numColumna].Value = columna.ColumnName;                        
                        numColumna++;
                    }


                    //Por cada Seccion
                    int fila = 2;
                    numColumna = 1;
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        //Llenado de celdas en excel
                        hoja.Cells[fila, 1].Value = item["id"].ToString();
                        hoja.Cells[fila, 2].Value = item["ts"].ToString();
                        hoja.Cells[fila, 3].Value = item["fechaPeticion"].ToString();
                        hoja.Cells[fila, 4].Value = item["idTercero"].ToString();
                        hoja.Cells[fila, 5].Value = item["idSucursal"].ToString();
                        hoja.Cells[fila, 6].Value = item["f015_rowid"].ToString();
                        hoja.Cells[fila, 7].Value = item["direccion"].ToString();
                        hoja.Cells[fila, 8].Value = item["codigoPostal"].ToString();
                        hoja.Cells[fila, 9].Value = item["latitud"].ToString();
                        hoja.Cells[fila, 10].Value = item["longitud"].ToString();
                        hoja.Cells[fila, 11].Value = item["estrato"].ToString();
                        hoja.Cells[fila, 12].Value = item["barrio"].ToString();
                        hoja.Cells[fila, 13].Value = item["comunaLocalidad"].ToString();
                        hoja.Cells[fila, 14].Value = item["zonaLogistica"].ToString();
                        hoja.Cells[fila, 15].Value = item["diasEntrega"].ToString();
                        hoja.Cells[fila, 16].Value = item["Zona1"].ToString();
                        hoja.Cells[fila, 17].Value = item["Zona2"].ToString();
                        hoja.Cells[fila, 18].Value = item["Zona3"].ToString();
                        hoja.Cells[fila, 19].Value = item["Zona4"].ToString();
                        hoja.Cells[fila, 20].Value = item["bitError"].ToString();
                        hoja.Cells[fila, 21].Value = item["resultadoSitiData"].ToString();
                        hoja.Cells[fila, 22].Value = item["detalle"].ToString();

                        fila++;
                    }

                    libro.Save(); //Save the workbook.

                    respuestaJson.resultado = strNombreArchivo;

                }

                //return File(libro.GetAsByteArray(), excelContentType, "Productos.xlsx");
            }
            catch (Exception ex)
            {
                respuestaJson.bitError = true;
                respuestaJson.resultado = "Error paso 3 generar plantilla : " + ex.Message;
            }

            return respuestaJson.resultado;

        }

    }

}

