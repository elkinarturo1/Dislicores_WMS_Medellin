Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

Public Class Upload_TCO_TCE_SQL

    Dim strConexionSQL As String = System.Configuration.ConfigurationManager.AppSettings.Item("strConexionWMS").ToString
    Dim strConexionINTSCE As String = System.Configuration.ConfigurationManager.AppSettings.Item("strConexionINTSCE").ToString
    Dim strConexionSCPRD As String = System.Configuration.ConfigurationManager.AppSettings.Item("strConexionSCPRD").ToString


    Public Function sp_WMS_UPLOAD_Entrada_TCE_desde_TCO_ws_Migrar_Blazor(ByRef bitError As String, ByRef resultado As String) As DataSet

        Dim ds As New DataSet
        Dim sqlConexion As New SqlConnection(strConexionSQL)
        Dim sqlAdaptador As New SqlDataAdapter
        Dim sqlComando As SqlCommand = New SqlCommand

        Try

            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_UPLOAD_Entrada_TCE_desde_TCO_ws_Migrar_Blazor"
            sqlComando.CommandTimeout = 0

            sqlConexion.Open()
            sqlAdaptador.SelectCommand = sqlComando
            sqlAdaptador.Fill(ds)

        Catch ex As Exception
            bitError = True
            resultado = ex.Message
        Finally
            sqlConexion.Close()
            sqlComando.Parameters.Clear()
            sqlComando.Connection.Close()
        End Try

        Return ds

    End Function

    Public Function sp_WMS_UPLOAD_Entrada_TCE_desde_TCO_ws_Detalle_Blazor(ByRef bitError As String, ByRef resultado As String, ByVal paquete As String) As DataSet

        Dim ds As New DataSet
        Dim sqlConexion As New SqlConnection(strConexionSQL)
        Dim sqlAdaptador As New SqlDataAdapter
        Dim sqlComando As SqlCommand = New SqlCommand

        Try

            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_UPLOAD_Entrada_TCE_desde_TCO_ws_Detalle_Blazor"
            sqlComando.CommandTimeout = 0

            sqlComando.Parameters.AddWithValue("@paquete", paquete)

            sqlConexion.Open()
            sqlAdaptador.SelectCommand = sqlComando
            sqlAdaptador.Fill(ds)

        Catch ex As Exception
            bitError = True
            resultado = ex.Message
        Finally
            sqlConexion.Close()
            sqlComando.Parameters.Clear()
            sqlComando.Connection.Close()
        End Try

        Return ds

    End Function


    Public Function sp_WMS_Validar_Upload_TCO_TCE(ByRef bitError As String, ByRef resultado As String,
                                                  ByVal Cia As String,
                                                  ByVal Co As String,
                                                  ByVal TipoDoc As String,
                                                  ByVal NumDoc As String) As DataSet


        Dim ds As New DataSet
        Dim sqlConexion As New SqlConnection(strConexionSQL)
        Dim sqlAdaptador As New SqlDataAdapter
        Dim sqlComando As SqlCommand = New SqlCommand

        Try

            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_Validar_Upload_TEB"
            sqlComando.CommandTimeout = 0

            sqlComando.Parameters.AddWithValue("@Cia", Cia)
            sqlComando.Parameters.AddWithValue("@Co", Co)
            sqlComando.Parameters.AddWithValue("@TipoDoc", TipoDoc)
            sqlComando.Parameters.AddWithValue("@NumDoc", NumDoc)


            sqlConexion.Open()
            sqlAdaptador.SelectCommand = sqlComando
            sqlAdaptador.Fill(ds)

        Catch ex As Exception
            bitError = True
            resultado = ex.Message
        Finally
            sqlConexion.Close()
            sqlComando.Parameters.Clear()
            sqlComando.Connection.Close()
        End Try

        Return ds

    End Function



End Class
