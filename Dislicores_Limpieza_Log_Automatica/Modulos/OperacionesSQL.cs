using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dislicores_Limpieza_Log_Automatica.Modulos
{
    public static class OperacionesSQL
    {

        public static void sp_A_Limpiar_DB()
        {
            SqlConnection conexionSQL = new SqlConnection(Properties.Settings.Default.strConexion);
            SqlCommand comandoSQL = new SqlCommand();


            comandoSQL.CommandTimeout = 0;
            comandoSQL.Connection = conexionSQL;
            comandoSQL.CommandType = CommandType.StoredProcedure;
            comandoSQL.CommandText = "sp_A_Limpiar_DB";

            try
            {

                //comandoSQL.Parameters.AddWithValue("@isError", datos.isError);
                //comandoSQL.Parameters.AddWithValue("@tipo", datos.type);
                //comandoSQL.Parameters.AddWithValue("@message", datos.message);

               //Se usa para operaciones que no generan un Dataset
                comandoSQL.Connection.Open();
                comandoSQL.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //objLog.bitError = true;
                //objLog.detalle = "Error Paso 2 guardando datos en SQL : " + ex.Message;
                //SQL_DTO.sp_Proceso_4_Log_Guardar(objLog);
            }
            finally
            {
                comandoSQL.Parameters.Clear();
                comandoSQL.Connection.Close();
            }

        }

    }
}
