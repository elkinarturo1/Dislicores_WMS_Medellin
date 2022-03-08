using Sauron_Monitor_Integraciones.DAO;
using Sauron_Monitor_Integraciones.Helpers;
using Sauron_Monitor_Integraciones.Shared;
using System.Data;

namespace Sauron_Monitor_Integraciones.Bussines
{
    public class UsuariosBL
    {

        RespuestaJson respuestaJson = new RespuestaJson();
        string strConexion = "";


        public UsuariosBL()
        {
            strConexion = Leer_JSON.leerJson_strConexion();
        }


        public RespuestaJson autenticacion(string usuario, string clave)
        {

            List<UsuariosModel> listadoDatos = new List<UsuariosModel>();
            DataSet ds = new DataSet();

            try
            {
                ds = UsuariosDAO.sp_Autenticacion(strConexion, usuario, clave);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow registro in ds.Tables[0].Rows)
                        {
                            UsuariosModel objMapeo = new UsuariosModel();

                            objMapeo.id = int.Parse(registro["id"].ToString());
                            objMapeo.codigo = registro["codigo"].ToString();
                            objMapeo.usuario = registro["nombre"].ToString();
                            objMapeo.clave = registro["clave"].ToString();

                            listadoDatos.Add(objMapeo);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                respuestaJson.bitError = true;
                respuestaJson.resultado = ex.Message;
            }


            //string jsonString = JsonSerializer.Serialize(objResultado);          
            respuestaJson.datos = listadoDatos;
            return respuestaJson;

        }


        public RespuestaJson consultarUsuarios(int id,string codigo, string clave)
        {

            List<UsuariosModel> listadoDatos = new List<UsuariosModel>();
            DataSet ds = new DataSet();

            try
            {
                ds = UsuariosDAO.sp_Usuarios_Select(strConexion,id, codigo, clave);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow registro in ds.Tables[0].Rows)
                        {
                            UsuariosModel objMapeo = new UsuariosModel();

                            objMapeo.id = int.Parse(registro["id"].ToString());
                            objMapeo.codigo = registro["codigo"].ToString();
                            objMapeo.usuario = registro["nombre"].ToString();
                            objMapeo.clave = registro["clave"].ToString();

                            listadoDatos.Add(objMapeo);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                respuestaJson.bitError = true;
                respuestaJson.resultado = ex.Message;
            }


            //string jsonString = JsonSerializer.Serialize(objResultado);          
            respuestaJson.datos = listadoDatos;
            return respuestaJson;

        }



        public RespuestaJson Usuario_Crear(UsuariosModel model)
        {

            try
            {
                UsuariosDAO.sp_Usuarios_Crear(strConexion, model);
                respuestaJson.resultado = "Proceso Terminado Correctamente";
            }
            catch (Exception ex)
            {
                respuestaJson.bitError = true;
                respuestaJson.resultado = ex.Message;
            }

            return respuestaJson;

        }


        public RespuestaJson Usuario_Actualizar(UsuariosModel model)
        {

            try
            {
                UsuariosDAO.sp_Usuarios_Actualizar(strConexion, model);
                respuestaJson.resultado = "Proceso Terminado Correctamente";
            }
            catch (Exception ex)
            {
                respuestaJson.bitError = true;
                respuestaJson.resultado = ex.Message;
            }

            return respuestaJson;

        }

        public RespuestaJson Usuario_Eliminar(int id)
        {

            try
            {
                UsuariosDAO.sp_Usuarios_Eliminar(strConexion, id);
                respuestaJson.resultado = "Proceso Terminado Correctamente";
            }
            catch (Exception ex)
            {
                respuestaJson.bitError = true;
                respuestaJson.resultado = ex.Message;
            }

            return respuestaJson;

        }


    }

}
