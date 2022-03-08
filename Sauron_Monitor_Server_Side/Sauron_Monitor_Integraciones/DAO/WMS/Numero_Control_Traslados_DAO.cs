using Sauron_Monitor_Integraciones.Helpers;
using Sauron_Monitor_Integraciones.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Sauron_Monitor_Integraciones.DAO.WMS
{
    public static class Numero_Control_Traslados_DAO
    {

        //RespuestaJson respuestaJson = new RespuestaJson();
        //LoginSQL objSQL = new LoginSQL();
        //string strConexion = "";


        //public Numero_Control_Traslados_DAO()
        //{
        //    strConexion = Leer_JSON.leerJson_strConexion_WMS();
        //}

        public static DataSet sp_WMS_UPLOAD_Numero_Control_Traslados(string strConexion,string transaccion)
        {
            SqlConnection conexionSQL = new SqlConnection(strConexion);
            SqlCommand comandoSQL = new SqlCommand();
            SqlDataAdapter adaptador = new SqlDataAdapter();
            DataSet ds = new DataSet();

            try
            {
                comandoSQL.Connection = conexionSQL;
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.CommandText = "sp_WMS_UPLOAD_Numero_Control_Traslados";

                comandoSQL.Parameters.AddWithValue("@transaccion", transaccion);
                //comandoSQL.Parameters.AddWithValue("@clave", login.clave);

                adaptador.SelectCommand = comandoSQL;
                adaptador.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ds;

        }

    }
}
