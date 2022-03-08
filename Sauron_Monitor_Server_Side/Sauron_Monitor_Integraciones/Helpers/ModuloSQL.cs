using System.Data;
using System.Data.SqlClient;

namespace Sauron_Monitor_Integraciones.Helpers
{
    public class ModuloSQL
    {

        public static void limpiarTabla(string strConexion, string nombreTabla)
        {            
            SqlConnection conexionSQL = new SqlConnection(strConexion);
            SqlCommand comandoSQL = new SqlCommand();
            SqlDataAdapter adaptador = new SqlDataAdapter();
            DataSet ds = new DataSet();

            comandoSQL.Connection = conexionSQL;
            comandoSQL.CommandType = CommandType.Text;
            comandoSQL.CommandText = "delete from " + nombreTabla;            

            try
            {
                comandoSQL.Connection.Open();
                comandoSQL.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                string resultado;
                resultado = ex.Message.ToString();
            }
            finally
            {
                comandoSQL.Connection.Close();
            }

        }

        public static void Guardar_en_BD_x_BulkCopy(string strConexion,DataTable Datos, string nombreTabla)
        {
            //SqlConnection conexionSQL = new SqlConnection("Data Source=192.168.0.54;Initial Catalog=IntegracionesDislicores;User ID=sa;Password=Sa123456;");
            SqlConnection conexionSQL = new SqlConnection(strConexion);
            SqlCommand comandoSQL = new SqlCommand();
            SqlDataAdapter adaptador = new SqlDataAdapter();
            DataSet ds = new DataSet();

            try
            {
                conexionSQL.Open();

                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conexionSQL))
                {
                    bulkCopy.DestinationTableName = nombreTabla;
                    bulkCopy.WriteToServer(Datos);
                }
            }
            catch (Exception ex)
            {

            }

        }

    }
}
