using Sauron_Monitor_Integraciones.Helpers;
using Sauron_Monitor_Integraciones.Models.Commercial_Effectiveness;
using System.Data;
using System.Data.SqlClient;

namespace Sauron_Monitor_Integraciones.DAO.Commercial_Effectiveness
{
    public static class ActualizacionUN_DAO
    {

        public static DataSet consultar_Equivalencias_UN()
        {
            string strConexion = Leer_JSON.strConexion_Commercial_Effectiveness();
            SqlConnection conexionSQL = new SqlConnection(strConexion);
            SqlCommand comandoSQL = new SqlCommand();
            SqlDataAdapter adaptador = new SqlDataAdapter();
            DataSet ds = new DataSet();

            try
            {
                comandoSQL.Connection = conexionSQL;
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.CommandText = "sp_Unidades_Sucursales_Consultar_Equivalencias";

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


        public static DataSet sp_Unidades_Sucursales_Nielsen_D_Select(string f200_id, string F201_ID_SUCURSAL)
        {

            string strConexion = Leer_JSON.strConexion_Commercial_Effectiveness();
            SqlConnection conexionSQL = new SqlConnection(strConexion);
            SqlCommand comandoSQL = new SqlCommand();
            SqlDataAdapter adaptadorSQL = new SqlDataAdapter();
            DataSet ds = new DataSet();

            comandoSQL.Connection = conexionSQL;
            comandoSQL.CommandType = CommandType.StoredProcedure;
            comandoSQL.CommandText = "sp_Unidades_Sucursales_Nielsen_D_Select";

            comandoSQL.Parameters.AddWithValue("@f200_id", f200_id);
            comandoSQL.Parameters.AddWithValue("@F201_ID_SUCURSAL", F201_ID_SUCURSAL);

            try
            {

                adaptadorSQL.SelectCommand = comandoSQL;
                adaptadorSQL.Fill(ds);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                comandoSQL.Parameters.Clear();
                comandoSQL.Connection.Close();
            }

            return ds;

        }



        public static DataSet sp_Proceso_2_Criterios_Vendedores_Select(string idCriterio_VEN)
        {

            string strConexion = Leer_JSON.strConexion_Commercial_Effectiveness();
            SqlConnection conexionSQL = new SqlConnection(strConexion);
            SqlCommand comandoSQL = new SqlCommand();
            SqlDataAdapter adaptadorSQL = new SqlDataAdapter();
            DataSet ds = new DataSet();

            comandoSQL.Connection = conexionSQL;
            comandoSQL.CommandType = CommandType.StoredProcedure;
            comandoSQL.CommandText = "sp_Proceso_2_Criterios_Vendedores_Select";

            comandoSQL.Parameters.AddWithValue("@idCriterio_VEN", idCriterio_VEN);

            try
            {

                adaptadorSQL.SelectCommand = comandoSQL;
                adaptadorSQL.Fill(ds);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                comandoSQL.Parameters.Clear();
                comandoSQL.Connection.Close();
            }

            return ds;

        }


        public static void sp_Log_Guardar(LogModel_ActualizarNielsenD modelo)
        {

            string strConexion = Leer_JSON.strConexion_Commercial_Effectiveness();
            SqlConnection conexionSQL = new SqlConnection(strConexion);
            SqlCommand comandoSQL = new SqlCommand();

            comandoSQL.Connection = conexionSQL;
            comandoSQL.CommandType = CommandType.StoredProcedure;
            comandoSQL.CommandText = "sp_Log_Guardar";

            comandoSQL.Parameters.AddWithValue("@idTercero", modelo.idTercero);
            comandoSQL.Parameters.AddWithValue("@idSucursal", modelo.idSucursal);
            comandoSQL.Parameters.AddWithValue("@proceso", modelo.proceso);
            comandoSQL.Parameters.AddWithValue("@rowIdTercero", modelo.rowIdTercero);
            comandoSQL.Parameters.AddWithValue("@direccion", modelo.direccion);
            comandoSQL.Parameters.AddWithValue("@codigoPostal", modelo.codigoPostal);
            comandoSQL.Parameters.AddWithValue("@latitud", modelo.latitud);
            comandoSQL.Parameters.AddWithValue("@longitud", modelo.longitud);
            comandoSQL.Parameters.AddWithValue("@estrato", modelo.estratoNvlSocioEconomico);
            comandoSQL.Parameters.AddWithValue("@barrio", modelo.barrio);
            comandoSQL.Parameters.AddWithValue("@comunaLocalidad", modelo.comunaLocalidad);
            comandoSQL.Parameters.AddWithValue("@Zona1", modelo.Zona1);
            comandoSQL.Parameters.AddWithValue("@Zona2", modelo.Zona2);
            comandoSQL.Parameters.AddWithValue("@Zona3", modelo.Zona3);
            comandoSQL.Parameters.AddWithValue("@Zona4", modelo.Zona4);
            comandoSQL.Parameters.AddWithValue("@resultadoSitiData", modelo.resultadoSitiData);
            comandoSQL.Parameters.AddWithValue("@xml_GT", modelo.xml_GT);
            comandoSQL.Parameters.AddWithValue("@resultado_GT", modelo.resultadoGT);
            comandoSQL.Parameters.AddWithValue("@xml_UNOEE", modelo.xml_UNOEE);
            comandoSQL.Parameters.AddWithValue("@resultado_UNOEE", modelo.resultado_UNOEE);
            comandoSQL.Parameters.AddWithValue("@detalle", modelo.detalle);


            try
            {
                comandoSQL.Connection.Open();
                comandoSQL.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                comandoSQL.Connection.Close();
            }

        }


    }
}
