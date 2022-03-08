using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sauron_Monitor_Integraciones.Helpers
{
    public static class EventosJS
    {
        public enum TipoMensaje { question, warning, error, success, info }

        public static async Task<bool> confirmarEliminacion(this IJSRuntime js, string titulo)
        {
            return await js.InvokeAsync<bool>("mensajeEliminacion", "Realmente desea eliminar este dato ?", "Esta cambio no podra revertirse!");
        }

        public static async Task<bool> confirmarEliminacion(this IJSRuntime js)
        {
            return await js.InvokeAsync<bool>("mensajeEliminacion", "Realmente desea eliminar este dato ?", "Esta cambio no podra revertirse!");
        }


        public static async Task MensajeProcesoOK(this IJSRuntime js)
        {
            await js.InvokeAsync<object>("Swal.fire", "OK", "Se termino el proceso correctamente", TipoMensaje.success.ToString());
        }


        public static async Task MensajeProcesoError(this IJSRuntime js, string mensaje)
        {
            mensaje = "Lo sentimos se presento un error : " + mensaje;
            await js.InvokeAsync<object>("Swal.fire", "Error", mensaje, TipoMensaje.error.ToString());
        }




        public static async Task guardarComo(this IJSRuntime js, string nombreArcvhivo, byte[] arrayExcel)
        {
            await js.InvokeAsync<object>("guardarArchivo", nombreArcvhivo, Convert.ToBase64String(arrayExcel));
        }






        //public static async Task descargarArchivosString(this IJSRuntime js, byte[] arrayExcel)
        //{
        //    try
        //    {
        //        await js.InvokeAsync<object>("SaveAsFile", "archivoDescargado.xls", arrayExcel);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        //public static async Task guardarComoArchivo(this IJSRuntime js)
        //{

        //    byte[] arrayExcel;

        //    try
        //    {

        //        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        //        using (var package = new ExcelPackage())
        //        {

        //            var worksheet = package.Workbook.Worksheets.Add("sheet1");
        //            worksheet.Cells[1, 1].Value = "Esto es una prueba";
        //            worksheet.Cells[1, 1].Style.Font.Size = 24;
        //            worksheet.Cells[1, 1].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Hair;

        //            arrayExcel = package.GetAsByteArray();

        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }


        //    try
        //    {

        //        string strBase64 = Convert.ToBase64String(arrayExcel);

        //        if (strBase64.IndexOf("data:image/jpeg;base64,") == 0)
        //        {
        //            strBase64 = strBase64.Replace("data:image/jpeg;base64,", "");
        //        }

        //        //byte[] arrayExcel = ExcelService.GenerateExcelWorkbook();
        //        //await js.InvokeAsync<object>("SalvarArchivo", "archivoDescargado.xlsx", arrayExcel);
        //        await js.InvokeAsync<object>("SaveAsFile", "archivoDescargado.xlsx", strBase64);
        //    }
        //    catch (Exception ex)
        //    {
        //        await js.InvokeAsync<object>("Swal.fire", "Error", ex.Message, TipoMensaje.error.ToString());
        //    }
        //}


        public static async Task guardarArchivoString(this IJSRuntime js, byte[] arrayExcel)
        {
            try
            {
                await js.InvokeAsync<object>("SaveAsFile", "archivoDescargado.xlsx", Convert.ToBase64String(arrayExcel));
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //public static async Task generarExcel(this IJSRuntime js)
        //{

        //    byte[] arrayExcel;

        //    try
        //    {

        //        await js.InvokeAsync<object>("confirm");
        //        //await js.InvokeAsync<object>("alerta");

        //        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        //        using (var package = new ExcelPackage())
        //        {

        //            var worksheet = package.Workbook.Worksheets.Add("sheet1");
        //            worksheet.Cells[1, 1].Value = "Esto es una prueba";
        //            worksheet.Cells[1, 1].Style.Font.Size = 24;
        //            worksheet.Cells[1, 1].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Hair;

        //            arrayExcel = package.GetAsByteArray();

        //        }

        //        await js.InvokeAsync<object>("guardarArchivoBase64", "archivo.xls", Convert.ToBase64String(arrayExcel));

        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }


        //    //return arrayExcel;

        //}


    }
}
