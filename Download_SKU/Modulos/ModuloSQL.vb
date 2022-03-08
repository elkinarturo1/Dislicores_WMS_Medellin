Imports System.Data.SqlClient

Module ModuloSQL

    Dim strConexionSQL As String = ""
    Dim strConexionWMS As String = ""
    Dim strConexionION As String = ""



    Sub New()

        If My.Settings.bitPruebas Then
            strConexionSQL = My.Settings.strConexionSQL_Pruebas
            strConexionWMS = My.Settings.strConexionWMS_Pruebas
            strConexionION = My.Settings.strConexion_ION_Pruebas
        Else
            strConexionSQL = My.Settings.strConexionSQL
            strConexionWMS = My.Settings.strConexionWMS
            strConexionION = My.Settings.strConexion_ION
        End If

    End Sub





    Public Function sp_WMS_DOWNLOAD_SKU() As DataSet

        Dim sqlConexion As New SqlConnection(strConexionSQL)
        Dim sqlAdaptador As New SqlDataAdapter
        Dim sqlComando As SqlCommand = New SqlCommand
        Dim ds As New DataSet

        Try
            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_DOWNLOAD_SKU"
            sqlComando.CommandTimeout = 0

            'sqlComando.Parameters.AddWithValue("@paquete", paquete)

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


    Public Sub select_Tablas_SQL(ByRef ds As DataSet, ByVal nombreTabla As String)

        Dim sqlConexion As New SqlConnection(strConexionSQL)
        Dim sqlAdaptador As New SqlDataAdapter
        Dim sqlComando As SqlCommand = New SqlCommand

        Try

            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.Text
            sqlComando.CommandText = "select * from " & nombreTabla
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

    End Sub


    Public Sub ejecutar_sp_Download_SQL(ByRef ds As DataSet, ByVal nombreSP As String)

        Dim sqlConexion As New SqlConnection(strConexionSQL)
        Dim sqlAdaptador As New SqlDataAdapter
        Dim sqlComando As SqlCommand = New SqlCommand

        Try

            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = nombreSP
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

    End Sub



    Public Sub sp_WMS_ION_Limpiar_SKU(ByVal SKU As String)

        Dim sqlConexion As SqlConnection
        Dim sqlComando As SqlCommand = New SqlCommand

        Try

            sqlConexion = New SqlConnection(strConexionSQL)

            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_ION_Limpiar_SKU"
            sqlComando.CommandTimeout = 0

            sqlComando.Parameters.AddWithValue("@SKU", SKU)

            sqlComando.Connection.Open()
            sqlComando.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        Finally
            sqlConexion.Close()
            sqlComando.Parameters.Clear()
            sqlComando.Connection.Close()
        End Try

    End Sub

    Public Sub sp_WMS_ION_DOWNLOAD_INT_SKU(ByVal objDatos As clsModelo_SKU)

        Dim sqlConexion As SqlConnection
        Dim sqlComando As SqlCommand = New SqlCommand

        Try

            sqlConexion = New SqlConnection(strConexionSQL)

            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_ION_DOWNLOAD_INT_SKU"
            sqlComando.CommandTimeout = 0

            sqlComando.Parameters.AddWithValue("@SKU", objDatos.SKU)
            sqlComando.Parameters.AddWithValue("@BUSR1", objDatos.BUSR1)
            sqlComando.Parameters.AddWithValue("@BUSR2", objDatos.BUSR2)
            sqlComando.Parameters.AddWithValue("@BUSR3", objDatos.BUSR3)
            sqlComando.Parameters.AddWithValue("@BUSR4", objDatos.BUSR4)
            sqlComando.Parameters.AddWithValue("@BUSR5", objDatos.BUSR5)
            sqlComando.Parameters.AddWithValue("@STORERKEY", objDatos.STORERKEY)
            sqlComando.Parameters.AddWithValue("@DESCR", objDatos.DESCR)
            sqlComando.Parameters.AddWithValue("@PACKKEY", objDatos.PACKKEY)
            sqlComando.Parameters.AddWithValue("@STDCUBE", objDatos.STDCUBE)
            sqlComando.Parameters.AddWithValue("@STDGROSSWGT", objDatos.STDGROSSWGT)
            sqlComando.Parameters.AddWithValue("@STDNETWGT", objDatos.STDNETWGT)
            sqlComando.Parameters.AddWithValue("@TARE", objDatos.TARE)
            sqlComando.Parameters.AddWithValue("@SHELFLIFEINDICATOR", objDatos.SHELFLIFEINDICATOR)
            sqlComando.Parameters.AddWithValue("@SHELFLIFEONRECEIVING", objDatos.SHELFLIFEONRECEIVING)
            sqlComando.Parameters.AddWithValue("@SHELFLIFE", objDatos.SHELFLIFE)
            sqlComando.Parameters.AddWithValue("@SHELFLIFECODETYPE", objDatos.SHELFLIFECODETYPE)

            sqlComando.Connection.Open()
            sqlComando.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        Finally
            sqlConexion.Close()
            sqlComando.Parameters.Clear()
            sqlComando.Connection.Close()
        End Try

    End Sub

    Public Sub Guardar_en_BD_x_BulkCopy(ByRef Datos As DataTable, ByVal strNombreTabla As String)

        Dim sqlConexion As New SqlConnection(strConexionSQL)
        Dim sqlComando As New SqlCommand
        Dim sqlAdaptador As New SqlDataAdapter

        Try
            sqlConexion.Open()

            Using bulkCopy As SqlBulkCopy = New SqlBulkCopy(sqlConexion)
                bulkCopy.DestinationTableName = strNombreTabla
                bulkCopy.WriteToServer(Datos)
            End Using

        Catch ex As Exception
            'MsgBox("Error en Micros_chk_dtl : " & ex.Message)
            Throw ex
        Finally
            sqlConexion.Close()
        End Try

    End Sub


    Public Sub sp_A_Registrar_Log_Download_SKU(Optional bitResultado As Boolean = False,
                                    Optional sku_referencia As String = "",
                                    Optional datosEnviados As String = "",
                                    Optional detalleResultado As String = "")

        Dim sqlConexion As SqlConnection
        Dim sqlComando As SqlCommand = New SqlCommand

        Try

            sqlConexion = New SqlConnection(strConexionSQL)

            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_A_Registrar_Log_Download_SKU"
            sqlComando.CommandTimeout = 0

            sqlComando.Parameters.AddWithValue("@bitResultado", bitResultado)
            sqlComando.Parameters.AddWithValue("@sku_referencia", sku_referencia)
            sqlComando.Parameters.AddWithValue("@datosEnviados", datosEnviados)
            sqlComando.Parameters.AddWithValue("@detalleResultado", detalleResultado)

            sqlComando.Connection.Open()
            sqlComando.ExecuteNonQuery()

        Catch ex As Exception

        Finally
            sqlConexion.Close()
            sqlComando.Parameters.Clear()
            sqlComando.Connection.Close()
        End Try

    End Sub

End Module
