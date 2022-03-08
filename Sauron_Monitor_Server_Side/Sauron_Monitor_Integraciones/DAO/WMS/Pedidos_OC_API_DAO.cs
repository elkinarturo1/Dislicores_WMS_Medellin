using Newtonsoft.Json;
using RestSharp;
using Sauron_Monitor_Integraciones.Shared;
using Sauron_Monitor_Integraciones.Shared.WMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sauron_Monitor_Integraciones.DAO.WMS
{
    public class Pedidos_OC_API_DAO
    {

        public ResultadoModel consultar_SitiData_Uno_a_Uno(Request_Pedidos_OC_Model peticion)
        {

            ResultadoModel respuesta = new ResultadoModel();

            try
            {

                string json = JsonConvert.SerializeObject(peticion);

                //string strJson = "{ \"address\" : \"cl 84 # 24 - 78\" , \"city\" : \"bogota\" }";

                string RequestRoute = "/api/consultar_Pedidos_OC/";            
                RestRequest request = new RestRequest(RequestRoute, Method.POST);
                //request.AddHeader("X-VTEX-API-AppToken", Properties.Settings.Default.AppToken);
                //request.AddHeader("Content-Type", "application/json;charset=utf8");
                //request.AddHeader("Accept", "application/json");
                //request.AddHeader("Authorization", "Token XVSMVUKEAZA8RBA57TX61LS29O00FF");
                request.AddHeader("Content-Type", "application/json;charset=utf8");
                request.AddParameter("application/json", json, ParameterType.RequestBody);

                RestClient client = new RestClient("https://localhost:44380");

                var response = client.Execute(request);
                string content;
                content = response.Content;

                if (content != "[]")
                {
                    respuesta = JsonConvert.DeserializeObject<ResultadoModel>(response.Content);
                    string prueba = "";
                    //if (respuesta.success == false)
                    //{
                    //    objLog.bitError = true;
                    //    objLog.resultadoSitiData = respuesta.message;
                    //}

                }
                else
                {
                    //objLog.bitError = true;
                    //objLog.resultadoSitiData = "La API no devolvio datos ";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return respuesta;

        }


    }
}
