using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Sauron_Monitor_Integraciones.DAO.Commercial_Effectiveness
{
    public static class Georreferenciacion_DAO
    {

        public static DataSet consultar_Clientes_Georreferenciados(string strConexion)
        {
            SqlConnection conexionSQL = new SqlConnection(strConexion);
            SqlCommand comandoSQL = new SqlCommand();
            SqlDataAdapter adaptador = new SqlDataAdapter();
            DataSet ds = new DataSet();

            try
            {
                comandoSQL.Connection = conexionSQL;
                comandoSQL.CommandType = CommandType.Text;
                comandoSQL.CommandText = "SELECT * FROM [dbo].[InfoSitiData]";

                //comandoSQL.Parameters.AddWithValue("@transaccion", transaccion);
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


        //public static DataSet consultar_Equivalencias_UN(string strConexion)
        //{
        //    SqlConnection conexionSQL = new SqlConnection(strConexion);
        //    SqlCommand comandoSQL = new SqlCommand();
        //    SqlDataAdapter adaptador = new SqlDataAdapter();
        //    DataSet ds = new DataSet();

        //    try
        //    {
        //        comandoSQL.Connection = conexionSQL;
        //        comandoSQL.CommandType = CommandType.StoredProcedure;
        //        comandoSQL.CommandText = "sp_Unidades_Sucursales_Consultar_Equivalencias";

        //        //comandoSQL.Parameters.AddWithValue("@transaccion", transaccion);
        //        //comandoSQL.Parameters.AddWithValue("@clave", login.clave);

        //        adaptador.SelectCommand = comandoSQL;
        //        adaptador.Fill(ds);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //    return ds;

        //}

    }
}
