Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

Public Class Download_PEE_SQL

    Dim strConexionSQL As String = System.Configuration.ConfigurationManager.AppSettings.Item("strConexionWMS").ToString
    Dim strConexionINTSCE As String = System.Configuration.ConfigurationManager.AppSettings.Item("strConexionINTSCE").ToString
    Dim strConexionSCPRD As String = System.Configuration.ConfigurationManager.AppSettings.Item("strConexionSCPRD").ToString


    Public Function sp_WMS_DOWNLOAD_Pedidos_PEE_Agrup(ByVal nit As String) As DataSet

        Dim ds As New DataSet
        Dim sqlConexion As New SqlConnection(strConexionSQL)
        Dim sqlAdaptador As New SqlDataAdapter
        Dim sqlComando As SqlCommand = New SqlCommand

        Try

            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_DOWNLOAD_Pedidos_PEE_Agrup"
            sqlComando.CommandTimeout = 0

            sqlComando.Parameters.AddWithValue("@nit", nit)

            sqlConexion.Open()
            sqlAdaptador.SelectCommand = sqlComando
            sqlAdaptador.Fill(ds)

        Catch ex As Exception
            Throw ex
        Finally
            sqlConexion.Close()
            sqlComando.Parameters.Clear()
            sqlComando.Connection.Close()
        End Try

        Return ds

    End Function



    Public Function sp_WMS_DOWNLOAD_Pedidos_PEE_Detalle(ByVal nit As String) As DataSet

        Dim ds As New DataSet
        Dim sqlConexion As New SqlConnection(strConexionSQL)
        Dim sqlAdaptador As New SqlDataAdapter
        Dim sqlComando As SqlCommand = New SqlCommand

        Try

            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_DOWNLOAD_Pedidos_PEE_Detalle"
            sqlComando.CommandTimeout = 0

            sqlComando.Parameters.AddWithValue("@nit", nit)

            sqlConexion.Open()
            sqlAdaptador.SelectCommand = sqlComando
            sqlAdaptador.Fill(ds)

        Catch ex As Exception
            Throw ex
        Finally
            sqlConexion.Close()
            sqlComando.Parameters.Clear()
            sqlComando.Connection.Close()
        End Try

        Return ds

    End Function




    Public Function sp_WMS_DOWNLOAD_Pedidos_PEE(ByVal nit As Integer) As DataSet

        Dim ds As New DataSet
        Dim sqlConexion As New SqlConnection(strConexionSQL)
        Dim sqlAdaptador As New SqlDataAdapter
        Dim sqlComando As SqlCommand = New SqlCommand

        Try

            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_DOWNLOAD_Pedidos_PEE"
            sqlComando.CommandTimeout = 0

            sqlComando.Parameters.AddWithValue("@nit", nit)

            sqlConexion.Open()
            sqlAdaptador.SelectCommand = sqlComando
            sqlAdaptador.Fill(ds)

        Catch ex As Exception
            Throw ex
        Finally
            sqlConexion.Close()
            sqlComando.Parameters.Clear()
            sqlComando.Connection.Close()
        End Try

        Return ds

    End Function

    Public Function sp_WMS_DOWNLOAD_Pedidos_PEE_Consultar(ByVal p_nit As String) As DataSet

        Dim ds As New DataSet
        Dim sqlConexion As New SqlConnection(strConexionSQL)
        Dim sqlAdaptador As New SqlDataAdapter
        Dim sqlComando As SqlCommand = New SqlCommand

        Try

            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_DOWNLOAD_Pedidos_PEE_Consultar"
            sqlComando.CommandTimeout = 0

            sqlComando.Parameters.AddWithValue("@p_nit", p_nit)

            sqlConexion.Open()
            sqlAdaptador.SelectCommand = sqlComando
            sqlAdaptador.Fill(ds)

        Catch ex As Exception
            Throw ex
        Finally
            sqlConexion.Close()
            sqlComando.Parameters.Clear()
            sqlComando.Connection.Close()
        End Try

        Return ds

    End Function

    Public Function sp_WMS_DOWNLOAD_SKU_Pedidos_PEE() As DataSet

        Dim ds As New DataSet
        Dim sqlConexion As New SqlConnection(strConexionSQL)
        Dim sqlAdaptador As New SqlDataAdapter
        Dim sqlComando As SqlCommand = New SqlCommand

        Try

            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.Text
            sqlComando.CommandText = "sp_WMS_DOWNLOAD_SKU_Pedidos_PEE"
            sqlComando.CommandTimeout = 0

            sqlConexion.Open()
            sqlAdaptador.SelectCommand = sqlComando
            sqlAdaptador.Fill(ds)

        Catch ex As Exception
            Throw ex
        Finally
            sqlConexion.Close()
            sqlComando.Parameters.Clear()
            sqlComando.Connection.Close()
        End Try

        Return ds

    End Function


    Public Function sp_WMS_DOWNLOAD_Pedidos_PEE_Paquetes(ByVal p_nit As String) As DataSet

        Dim ds As New DataSet
        Dim sqlConexion As New SqlConnection(strConexionSQL)
        Dim sqlAdaptador As New SqlDataAdapter
        Dim sqlComando As SqlCommand = New SqlCommand

        Try

            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_DOWNLOAD_Pedidos_PEE_Paquetes"
            sqlComando.CommandTimeout = 0

            sqlComando.Parameters.AddWithValue("@p_nit", p_nit)

            sqlConexion.Open()
            sqlAdaptador.SelectCommand = sqlComando
            sqlAdaptador.Fill(ds)

        Catch ex As Exception
            Throw ex
        Finally
            sqlConexion.Close()
            sqlComando.Parameters.Clear()
            sqlComando.Connection.Close()
        End Try

        Return ds

    End Function


End Class
