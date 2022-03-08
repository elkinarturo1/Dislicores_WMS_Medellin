﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Sauron_Monitor_Integraciones.DAO.WMS_Medellin
{
    public static class Upload_Averias_DAO
    {

        public static DataSet sp_WMS_UPLOAD_Ajustes_Inventario_Salidas_Siesa(string strConexion, string numControl)
        {
            SqlConnection conexionSQL = new SqlConnection(strConexion);
            SqlCommand comandoSQL = new SqlCommand();
            SqlDataAdapter adaptador = new SqlDataAdapter();
            DataSet ds = new DataSet();

            try
            {
                comandoSQL.CommandTimeout = 0;
                comandoSQL.Connection = conexionSQL;
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.CommandText = "sp_WMS_UPLOAD_Ajustes_Inventario_Salidas_Siesa";

                comandoSQL.Parameters.AddWithValue("@numControl", numControl);
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