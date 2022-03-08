Imports System.Data.SqlClient

Module ModuloSQL

    Dim strConexionSQL As String = ""
    Dim strConexionWMS As String = ""
    Dim strConexionION As String = ""

    Public Function sp_WMS_DOWNLOAD_Ordenes_Compra_OCP() As DataSet

        Dim sqlConexion As New SqlConnection(strConexionSQL)
        Dim sqlAdaptador As New SqlDataAdapter
        Dim sqlComando As SqlCommand = New SqlCommand
        Dim ds As New DataSet

        Try

            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_DOWNLOAD_Ordenes_Compra_OCP"
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

    Public Sub ejecutar_sp_Execute_SQL(ByVal nombreSP As String)

        Dim sqlConexion As SqlConnection
        Dim sqlComando As SqlCommand = New SqlCommand

        Try

            sqlConexion = New SqlConnection(strConexionSQL)

            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = nombreSP
            sqlComando.CommandTimeout = 0

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


    Public Sub sp_WMS_ION_Limpiar_PO(ByVal EXTERNPOKEY As String)

        Dim sqlConexion As SqlConnection
        Dim sqlComando As SqlCommand = New SqlCommand

        Try

            sqlConexion = New SqlConnection(strConexionSQL)

            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_ION_Limpiar_PO"
            sqlComando.CommandTimeout = 0

            sqlComando.Parameters.AddWithValue("@EXTERNPOKEY", EXTERNPOKEY)

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



    Public Function sp_Siesa_Pedidos() As DataSet

        Dim sqlConexion As New SqlConnection(strConexionSQL)
        Dim sqlAdaptador As New SqlDataAdapter
        Dim sqlComando As SqlCommand = New SqlCommand
        Dim ds As New DataSet

        Try
            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_Siesa_Pedidos"
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


    Public Sub limpiarTabla(ByVal strNombreTabla As String)

        Dim sqlConexion As SqlConnection
        Dim sqlComando As SqlCommand = New SqlCommand

        Try

            sqlConexion = New SqlConnection(strConexionSQL)

            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.Text
            sqlComando.CommandText = "delete from " & strNombreTabla
            sqlComando.CommandTimeout = 0

            sqlComando.Connection.Open()
            sqlComando.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
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


    Public Sub sp_WMS_ION_DOWNLOAD_INT_PO(ByVal objReceipt As clsModelo_PO)


        Dim sqlConexion As SqlConnection
        Dim sqlComando As SqlCommand = New SqlCommand

        Try

            sqlConexion = New SqlConnection(strConexionSQL)

            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_ION_DOWNLOAD_INT_PO"
            sqlComando.CommandTimeout = 0

            sqlComando.Parameters.AddWithValue("@STORERKEY", objReceipt.STORERKEY)
            sqlComando.Parameters.AddWithValue("@EXTERNPOKEY", objReceipt.EXTERNPOKEY)
            sqlComando.Parameters.AddWithValue("@TYPE", objReceipt.TYPE)
            sqlComando.Parameters.AddWithValue("@SELLERNAME", objReceipt.SELLERNAME)
            sqlComando.Parameters.AddWithValue("@WHSEID", objReceipt.WHSEID)
            sqlComando.Parameters.AddWithValue("@EXPECTEDRECEIPTDATE", objReceipt.EXPECTEDRECEIPTDATE)
            sqlComando.Parameters.AddWithValue("@SUSR1", objReceipt.SUSR1)
            sqlComando.Parameters.AddWithValue("@SUSR2", objReceipt.SUSR2)
            sqlComando.Parameters.AddWithValue("@SUSR3", objReceipt.SUSR3)


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

    Public Sub sp_WMS_ION_DOWNLOAD_INT_PODETAIL(ByVal objReceipt As clsModelo_PO_Detail)


        Dim sqlConexion As SqlConnection
        Dim sqlComando As SqlCommand = New SqlCommand

        Try

            sqlConexion = New SqlConnection(strConexionSQL)

            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_ION_DOWNLOAD_INT_PODETAIL"
            sqlComando.CommandTimeout = 0

            sqlComando.Parameters.AddWithValue("@STORERKEY", objReceipt.STORERKEY)
            sqlComando.Parameters.AddWithValue("@EXTERNPOKEY", objReceipt.EXTERNPOKEY)
            sqlComando.Parameters.AddWithValue("@EXTERNLINENO", objReceipt.EXTERNLINENO)
            sqlComando.Parameters.AddWithValue("@SKU", objReceipt.SKU)
            sqlComando.Parameters.AddWithValue("@QTYEXPECTED", objReceipt.QTYEXPECTED)
            sqlComando.Parameters.AddWithValue("@UOM", objReceipt.UOM)
            sqlComando.Parameters.AddWithValue("@WHSEID", objReceipt.WHSEID)
            sqlComando.Parameters.AddWithValue("@lotattribute06", objReceipt.lotattribute06)
            sqlComando.Parameters.AddWithValue("@SUSR1", objReceipt.SUSR1)
            sqlComando.Parameters.AddWithValue("@SUSR2", objReceipt.SUSR2)
            sqlComando.Parameters.AddWithValue("@SUSR3", objReceipt.SUSR3)
            sqlComando.Parameters.AddWithValue("@SUSR5", objReceipt.SUSR5)


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


    Public Sub sp_A_Registrar_Log_Download_Orden_Compra_OCP(Optional bitResultado As Boolean = False,
                                     Optional externpokey_key_docto As String = "",
                                     Optional cia As String = "",
                                     Optional co As String = "",
                                     Optional tipoDoc As String = "",
                                     Optional numDoc As String = "",
                                     Optional SUSR1_rowid_encab As String = "",
                                     Optional D_SUSR1_rowid_detalle As String = "",
                                     Optional SKU_referencia As String = "",
                                     Optional D_SUSR3_bod_destino As String = "",
                                     Optional qtyexpected_can_ped As String = "",
                                     Optional datosEnviados As String = "",
                                     Optional detalleResultado As String = "")

        Dim sqlConexion As SqlConnection
        Dim sqlComando As SqlCommand = New SqlCommand

        Try

            sqlConexion = New SqlConnection(My.Settings.strConexionSQL)

            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_A_Registrar_Log_Download_Orden_Compra_OCP"
            sqlComando.CommandTimeout = 0

            sqlComando.Parameters.AddWithValue("@bitResultado", bitResultado)
            sqlComando.Parameters.AddWithValue("@externpokey_key_docto", externpokey_key_docto)
            sqlComando.Parameters.AddWithValue("@cia", cia)
            sqlComando.Parameters.AddWithValue("@co", co)
            sqlComando.Parameters.AddWithValue("@tipoDoc", tipoDoc)
            sqlComando.Parameters.AddWithValue("@numDoc", numDoc)
            sqlComando.Parameters.AddWithValue("@SUSR1_rowid_encab", SUSR1_rowid_encab)
            sqlComando.Parameters.AddWithValue("@D_SUSR1_rowid_detalle", D_SUSR1_rowid_detalle)
            sqlComando.Parameters.AddWithValue("@SKU_referencia", SKU_referencia)
            sqlComando.Parameters.AddWithValue("@D_SUSR3_bod_destino", D_SUSR3_bod_destino)
            sqlComando.Parameters.AddWithValue("@qtyexpected_can_ped", qtyexpected_can_ped)
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
