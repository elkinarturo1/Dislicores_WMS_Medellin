Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

Public Class Download_RQI_SQL

    Dim strConexionSQL As String = System.Configuration.ConfigurationManager.AppSettings.Item("strConexionWMS").ToString
    Dim strConexionINTSCE As String = System.Configuration.ConfigurationManager.AppSettings.Item("strConexionINTSCE").ToString
    Dim strConexionSCPRD As String = System.Configuration.ConfigurationManager.AppSettings.Item("strConexionSCPRD").ToString


    Public Function sp_WMS_DOWNLOAD_Requisiciones_RQI(ByVal cia As Integer, ByVal co As String, ByVal tipoDoc As String, ByVal numDoc As Integer) As DataSet

        Dim ds As New DataSet
        Dim sqlConexion As New SqlConnection(strConexionSQL)
        Dim sqlAdaptador As New SqlDataAdapter
        Dim sqlComando As SqlCommand = New SqlCommand

        Try

            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_DOWNLOAD_Requisiciones_RQI"
            sqlComando.CommandTimeout = 0

            'sqlComando.Parameters.AddWithValue("@cia", cia)
            sqlComando.Parameters.AddWithValue("@co", co)
            'sqlComando.Parameters.AddWithValue("@tipoDoc", tipoDoc)
            sqlComando.Parameters.AddWithValue("@numDoc", numDoc)

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
