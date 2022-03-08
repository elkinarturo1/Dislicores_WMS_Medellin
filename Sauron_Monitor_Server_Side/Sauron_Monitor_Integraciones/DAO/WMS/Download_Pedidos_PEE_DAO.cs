using Sauron_Monitor_Integraciones.Helpers;
using Sauron_Monitor_Integraciones.Shared.WMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Sauron_Monitor_Integraciones.DAO.WMS
{
    public class Download_Pedidos_PEE_DAO
    {

        string strConexion = "";

        public Download_Pedidos_PEE_DAO()
        {
            strConexion = Leer_JSON.leerJson_strConexion_WMS();
        }


        public DataSet sp_WMS_DOWNLOAD_Pedidos_PEE(string nit)
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
                comandoSQL.CommandText = "sp_WMS_DOWNLOAD_Pedidos_PEE";

                comandoSQL.Parameters.AddWithValue("@nit", nit);
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




        public void sp_WMS_ION_Limpiar_ORDERS(string EXTERNORDERKEY)
        {
            SqlConnection conexionSQL = new SqlConnection(strConexion);
            SqlCommand comandoSQL = new SqlCommand();
            DataSet ds = new DataSet();

            try
            {
                comandoSQL.CommandTimeout = 0;
                comandoSQL.Connection = conexionSQL;
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.CommandText = "sp_WMS_ION_Limpiar_ORDERS";

                comandoSQL.Parameters.AddWithValue("@EXTERNORDERKEY", EXTERNORDERKEY);
                //comandoSQL.Parameters.AddWithValue("@clave", login.clave);

                comandoSQL.Connection.Open();
                comandoSQL.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public void sp_WMS_ION_DOWNLOAD_INT_ORDERDETAIL(OrderDetails_Model objOrdersDetails)
        {
            SqlConnection conexionSQL = new SqlConnection(strConexion);
            SqlCommand comandoSQL = new SqlCommand();
            DataSet ds = new DataSet();

            try
            {
                comandoSQL.CommandTimeout = 0;
                comandoSQL.Connection = conexionSQL;
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.CommandText = "sp_WMS_ION_DOWNLOAD_INT_ORDERDETAIL";

                comandoSQL.Parameters.AddWithValue("@STORERKEY", objOrdersDetails.STORERKEY);
                comandoSQL.Parameters.AddWithValue("@EXTERNORDERKEY", objOrdersDetails.EXTERNORDERKEY);
                comandoSQL.Parameters.AddWithValue("@EXTERNLINENO", objOrdersDetails.EXTERNLINENO);
                comandoSQL.Parameters.AddWithValue("@SKU", objOrdersDetails.SKU);
                comandoSQL.Parameters.AddWithValue("@UOM", objOrdersDetails.UOM);
                comandoSQL.Parameters.AddWithValue("@OPENQTY", objOrdersDetails.OPENQTY);
                comandoSQL.Parameters.AddWithValue("@ORIGINALQTY", objOrdersDetails.ORIGINALQTY);
                comandoSQL.Parameters.AddWithValue("@SUSR1", objOrdersDetails.SUSR1);
                comandoSQL.Parameters.AddWithValue("@SUSR2", objOrdersDetails.SUSR2);
                comandoSQL.Parameters.AddWithValue("@SUSR3", objOrdersDetails.SUSR3);
                comandoSQL.Parameters.AddWithValue("@SUSR5", objOrdersDetails.SUSR5);
                comandoSQL.Parameters.AddWithValue("@WHSEID", objOrdersDetails.WHSEID);
                comandoSQL.Parameters.AddWithValue("@LOTATTRIBUTE06", objOrdersDetails.LOTATTRIBUTE06);
                //comandoSQL.Parameters.AddWithValue("@clave", login.clave);

                comandoSQL.Connection.Open();
                comandoSQL.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                comandoSQL.Connection.Close();
                comandoSQL.Parameters.Clear();
            }

        }


        public void sp_WMS_ION_DOWNLOAD_INT_ORDER(Orders_Model objOrders)
        {
            SqlConnection conexionSQL = new SqlConnection(strConexion);
            SqlCommand comandoSQL = new SqlCommand();
            DataSet ds = new DataSet();

            try
            {
                comandoSQL.CommandTimeout = 0;
                comandoSQL.Connection = conexionSQL;
                comandoSQL.CommandType = CommandType.StoredProcedure;
                comandoSQL.CommandText = "sp_WMS_ION_DOWNLOAD_INT_ORDER";


                comandoSQL.Parameters.AddWithValue("@STORERKEY", objOrders.STORERKEY);
                comandoSQL.Parameters.AddWithValue("@EXTERNORDERKEY", objOrders.EXTERNORDERKEY);
                comandoSQL.Parameters.AddWithValue("@TYPE", objOrders.TYPE);
                comandoSQL.Parameters.AddWithValue("@CONSIGNEEKEY", objOrders.CONSIGNEEKEY);
                comandoSQL.Parameters.AddWithValue("@SUSR1", objOrders.SUSR1);
                comandoSQL.Parameters.AddWithValue("@SUSR2", objOrders.SUSR2);
                comandoSQL.Parameters.AddWithValue("@SUSR3", objOrders.SUSR3);
                comandoSQL.Parameters.AddWithValue("@SUSR4", objOrders.SUSR4);
                comandoSQL.Parameters.AddWithValue("@B_CONTACT1", objOrders.B_CONTACT1);
                comandoSQL.Parameters.AddWithValue("@WHSEID", objOrders.WHSEID);
                comandoSQL.Parameters.AddWithValue("@NOTES", objOrders.NOTES);
                comandoSQL.Parameters.AddWithValue("@DELIVERYDATE", objOrders.DELIVERYDATE);

                //comandoSQL.Parameters.AddWithValue("@clave", login.clave);

                comandoSQL.Connection.Open();
                comandoSQL.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                comandoSQL.Connection.Close();
                comandoSQL.Parameters.Clear();
            }

        }
    }
}