using Sauron_Monitor_Integraciones.Shared;
using System.Data;
using System.Data.SqlClient;

namespace Sauron_Monitor_Integraciones.DAO
{
    public static class UsuariosDAO
    {
        public static DataSet sp_Autenticacion(string strConexion, string codigo, string clave)
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
                comandoSQL.CommandText = "sp_Autenticacion";
                
                comandoSQL.Parameters.AddWithValue("@codigo", codigo);
                comandoSQL.Parameters.AddWithValue("@clave", clave);

                adaptador.SelectCommand = comandoSQL;
                adaptador.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ds;

        }


        public static DataSet sp_Usuarios_Select(string strConexion,int id, string codigo, string clave)
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
                comandoSQL.CommandText = "sp_Usuarios_Select";

                comandoSQL.Parameters.AddWithValue("@id", id);
                comandoSQL.Parameters.AddWithValue("@codigo", codigo);
                comandoSQL.Parameters.AddWithValue("@clave", clave);

                adaptador.SelectCommand = comandoSQL;
                adaptador.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ds;

        }

        public static void sp_Usuarios_Crear(string strConexion, UsuariosModel model)
        {
            SqlConnection conexionSQL = new SqlConnection(strConexion);
            SqlCommand comandoSQL = new SqlCommand();
          
            try
            {
                comandoSQL.CommandTimeout = 0;
                comandoSQL.Connection = conexionSQL;
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.CommandText = "sp_Usuarios_Crear";

                comandoSQL.Parameters.AddWithValue("@codigo", model.codigo);
                comandoSQL.Parameters.AddWithValue("@nombre", model.usuario);
                comandoSQL.Parameters.AddWithValue("@clave", model.clave);

                comandoSQL.Connection.Open();                    
                comandoSQL.ExecuteNonQuery();

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

        }


        public static void sp_Usuarios_Actualizar(string strConexion, UsuariosModel model)
        {
            SqlConnection conexionSQL = new SqlConnection(strConexion);
            SqlCommand comandoSQL = new SqlCommand();

            try
            {
                comandoSQL.CommandTimeout = 0;
                comandoSQL.Connection = conexionSQL;
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.CommandText = "sp_Usuarios_Actualizar";

                comandoSQL.Parameters.AddWithValue("@id", model.id);
                comandoSQL.Parameters.AddWithValue("@codigo", model.codigo);
                comandoSQL.Parameters.AddWithValue("@nombre", model.usuario);
                comandoSQL.Parameters.AddWithValue("@clave", model.clave);

                comandoSQL.Connection.Open();
                comandoSQL.ExecuteNonQuery();

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

        }

        public static void sp_Usuarios_Eliminar(string strConexion, int id)
        {
            SqlConnection conexionSQL = new SqlConnection(strConexion);
            SqlCommand comandoSQL = new SqlCommand();

            try
            {
                comandoSQL.CommandTimeout = 0;
                comandoSQL.Connection = conexionSQL;
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.CommandText = "sp_Usuarios_Eliminar";

                comandoSQL.Parameters.AddWithValue("@id", id);
                
                comandoSQL.Connection.Open();
                comandoSQL.ExecuteNonQuery();

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

        }

    }
}
