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





    Public Function sp_WMS_DOWNLOAD_Receptores() As DataSet

        Dim sqlConexion As New SqlConnection(strConexionSQL)
        Dim sqlAdaptador As New SqlDataAdapter
        Dim sqlComando As SqlCommand = New SqlCommand
        Dim ds As New DataSet

        Try
            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_DOWNLOAD_Receptores"
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



    Public Sub sp_WMS_ION_Limpiar_STORERS(ByVal strStorer As String)

        Dim sqlConexion As SqlConnection
        Dim sqlComando As SqlCommand = New SqlCommand

        Try

            sqlConexion = New SqlConnection(strConexionSQL)

            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_ION_Limpiar_STORERS"
            sqlComando.CommandTimeout = 0

            sqlComando.Parameters.AddWithValue("@STORERKEY", strStorer)

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

    Public Sub sp_WMS_ION_DOWNLOAD_INT_STORER(ByVal objDatos As clsModelo_Storers)

        Dim sqlConexion As SqlConnection
        Dim sqlComando As SqlCommand = New SqlCommand

        Try

            sqlConexion = New SqlConnection(strConexionSQL)

            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_ION_DOWNLOAD_INT_STORER"
            sqlComando.CommandTimeout = 0

            sqlComando.Parameters.AddWithValue("@STORERKEY", objDatos.STORERKEY)
            sqlComando.Parameters.AddWithValue("@TYPE", objDatos.TYPE)
            sqlComando.Parameters.AddWithValue("@COMPANY ", objDatos.COMPANY)
            sqlComando.Parameters.AddWithValue("@ADDRESS1", objDatos.ADDRESS1)
            sqlComando.Parameters.AddWithValue("@ADDRESS5", objDatos.ADDRESS5)
            sqlComando.Parameters.AddWithValue("@ADDRESS6", objDatos.ADDRESS6)
            sqlComando.Parameters.AddWithValue("@ADDRESS2", objDatos.ADDRESS2)
            sqlComando.Parameters.AddWithValue("@CITY", objDatos.CITY)
            sqlComando.Parameters.AddWithValue("@STATE", objDatos.STATE)
            sqlComando.Parameters.AddWithValue("@COUNTRY", objDatos.COUNTRY)
            sqlComando.Parameters.AddWithValue("@CONTACT1", objDatos.CONTACT1)
            sqlComando.Parameters.AddWithValue("@PHONE1", objDatos.PHONE1)
            sqlComando.Parameters.AddWithValue("@PHONE2", objDatos.PHONE2)
            sqlComando.Parameters.AddWithValue("@EMAIL1", objDatos.EMAIL1)
            sqlComando.Parameters.AddWithValue("@SUSR1", objDatos.SUSR1)
            sqlComando.Parameters.AddWithValue("@SUSR2", objDatos.SUSR2)
            sqlComando.Parameters.AddWithValue("@SUSR3", objDatos.SUSR3)
            sqlComando.Parameters.AddWithValue("@SUSR4", objDatos.SUSR4)
            sqlComando.Parameters.AddWithValue("@SUSR5", objDatos.SUSR5)
            sqlComando.Parameters.AddWithValue("@SUSR6", objDatos.SUSR6)


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
            Throw ex
        Finally
            sqlConexion.Close()
        End Try

    End Sub


    Public Sub sp_A_Registrar_Log_Download_Receptores(Optional bitResultado As Boolean = False,
                                    Optional storerkey_key_client As String = "",
                                    Optional address5_nit As String = "",
                                    Optional datosEnviados As String = "",
                                    Optional detalleResultado As String = "")

        Dim sqlConexion As SqlConnection
        Dim sqlComando As SqlCommand = New SqlCommand

        Try

            sqlConexion = New SqlConnection(strConexionSQL)

            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_A_Registrar_Log_Download_Receptores"
            sqlComando.CommandTimeout = 0

            sqlComando.Parameters.AddWithValue("@bitResultado", bitResultado)
            sqlComando.Parameters.AddWithValue("@storerkey_key_client", storerkey_key_client)
            sqlComando.Parameters.AddWithValue("@address5_nit", address5_nit)
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
