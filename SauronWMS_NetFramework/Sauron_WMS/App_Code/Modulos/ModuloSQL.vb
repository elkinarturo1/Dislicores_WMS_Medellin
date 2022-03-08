Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

Public Module ModuloSQL

    Dim strConexionSQL As String = System.Configuration.ConfigurationManager.AppSettings.Item("strConexionWMS").ToString
    Dim strConexionINTSCE As String = System.Configuration.ConfigurationManager.AppSettings.Item("strConexionINTSCE").ToString
    Dim strConexionSCPRD As String = System.Configuration.ConfigurationManager.AppSettings.Item("strConexionSCPRD").ToString


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


    Public Sub ejecutar_sp_Download_SQL(ByVal nombreSP As String)

        Dim sqlConexion As New SqlConnection(strConexionSQL)
        Dim sqlComando As SqlCommand = New SqlCommand

        Try

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



    Public Function sp_WMS_DOWNLOAD_Terceros_PEE() As DataSet

        Dim ds As New DataSet
        Dim sqlConexion As New SqlConnection(strConexionSQL)
        Dim sqlAdaptador As New SqlDataAdapter
        Dim sqlComando As SqlCommand = New SqlCommand

        Try

            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.Text
            sqlComando.CommandText = "sp_WMS_DOWNLOAD_Terceros_PEE"
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


    Public Sub sp_A_Registrar_Log_Download_Requiciones_RQI(Optional bitResultado As Boolean = False,
                                     Optional externpokey_key_docto As String = "",
                                     Optional cia As String = "",
                                     Optional co As String = "",
                                     Optional tipoDoc As String = "",
                                     Optional numDoc As String = "",
                                     Optional SUSR1_rowid_encab As String = "",
                                     Optional D_SUSR1_rowid_detalle As String = "",
                                     Optional SKU_referencia As String = "",
                                     Optional D_SUSR2_rowid_bod_sal As String = "",
                                     Optional D_SUSR3_bod_destino As String = "",
                                     Optional qtyexpected_can_ped As String = "",
                                     Optional datosEnviados As String = "",
                                     Optional detalleResultado As String = "")


        Dim sqlConexion As New SqlConnection(strConexionSQL)
        Dim sqlComando As SqlCommand = New SqlCommand

        Try

            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_A_Registrar_Log_Download_Requiiciones_RQI"
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
            sqlComando.Parameters.AddWithValue("@D_SUSR2_rowid_bod_sal", D_SUSR2_rowid_bod_sal)
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

    Public Function sp_WMS_DOWNLOAD_SKU_Pedidos() As DataSet

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








    'Public Sub sp_WMS_DOWNLOAD_Pedidos_Pev(ByRef ds As DataSet)

    '    Dim sqlConexion As New SqlConnection(strConexionSQL)
    '    Dim sqlAdaptador As New SqlDataAdapter
    '    Dim sqlComando As SqlCommand = New SqlCommand

    '    Try

    '        sqlComando.Connection = sqlConexion
    '        sqlComando.CommandType = CommandType.StoredProcedure
    '        sqlComando.CommandText = "sp_WMS_DOWNLOAD_Pedidos_Pev"
    '        sqlComando.CommandTimeout = 0

    '        sqlConexion.Open()
    '        sqlAdaptador.SelectCommand = sqlComando
    '        sqlAdaptador.Fill(ds)

    '    Catch ex As Exception
    '        Throw ex
    '    Finally
    '        sqlConexion.Close()
    '        sqlComando.Parameters.Clear()
    '        sqlComando.Connection.Close()
    '    End Try

    'End Sub

    'Public Sub sp_WMS_DOWNLOAD_Clientes_Pedidos(ByRef ds As DataSet)

    '    Dim sqlConexion As New SqlConnection(strConexionSQL)
    '    Dim sqlAdaptador As New SqlDataAdapter
    '    Dim sqlComando As SqlCommand = New SqlCommand

    '    Try

    '        sqlComando.Connection = sqlConexion
    '        sqlComando.CommandType = CommandType.StoredProcedure
    '        sqlComando.CommandText = "sp_WMS_DOWNLOAD_Clientes_Pedidos"
    '        sqlComando.CommandTimeout = 0

    '        sqlConexion.Open()
    '        sqlAdaptador.SelectCommand = sqlComando
    '        sqlAdaptador.Fill(ds)

    '    Catch ex As Exception
    '        Throw ex
    '    Finally
    '        sqlConexion.Close()
    '        sqlComando.Parameters.Clear()
    '        sqlComando.Connection.Close()
    '    End Try

    'End Sub

    'Public Function sp_WMS_DOWNLOAD_Pedidos_Pev_Det() As DataSet

    '    Dim sqlConexion As New SqlConnection(strConexionSQL)
    '    Dim sqlAdaptador As New SqlDataAdapter
    '    Dim sqlComando As SqlCommand = New SqlCommand
    '    Dim ds As New DataSet

    '    Try

    '        sqlComando.Connection = sqlConexion
    '        sqlComando.CommandType = CommandType.StoredProcedure
    '        sqlComando.CommandText = "sp_WMS_DOWNLOAD_Pedidos_Pev_Det"
    '        sqlComando.CommandTimeout = 0

    '        sqlConexion.Open()
    '        sqlAdaptador.SelectCommand = sqlComando
    '        sqlAdaptador.Fill(ds)

    '    Catch ex As Exception
    '        Throw ex
    '    Finally
    '        sqlConexion.Close()
    '        sqlComando.Parameters.Clear()
    '        sqlComando.Connection.Close()
    '    End Try

    '    Return ds

    'End Function

    'Public Function sp_WMS_DOWNLOAD_Pedidos_Pev_Enc() As DataSet

    '    Dim sqlConexion As New SqlConnection(strConexionSQL)
    '    Dim sqlAdaptador As New SqlDataAdapter
    '    Dim sqlComando As SqlCommand = New SqlCommand
    '    Dim ds As New DataSet

    '    Try

    '        sqlComando.Connection = sqlConexion
    '        sqlComando.CommandType = CommandType.StoredProcedure
    '        sqlComando.CommandText = "sp_WMS_DOWNLOAD_Pedidos_Pev_Enc"
    '        sqlComando.CommandTimeout = 0

    '        sqlConexion.Open()
    '        sqlAdaptador.SelectCommand = sqlComando
    '        sqlAdaptador.Fill(ds)

    '    Catch ex As Exception
    '        Throw ex
    '    Finally
    '        sqlConexion.Close()
    '        sqlComando.Parameters.Clear()
    '        sqlComando.Connection.Close()
    '    End Try

    '    Return ds

    'End Function

    'Public Sub sp_WMS_DOWNLOAD_SKU_Pedidos(ByRef ds As DataSet)

    '    Dim sqlConexion As New SqlConnection(strConexionSQL)
    '    Dim sqlAdaptador As New SqlDataAdapter
    '    Dim sqlComando As SqlCommand = New SqlCommand

    '    Try

    '        sqlComando.Connection = sqlConexion
    '        sqlComando.CommandType = CommandType.StoredProcedure
    '        sqlComando.CommandText = "sp_WMS_DOWNLOAD_SKU_Pedidos"
    '        sqlComando.CommandTimeout = 0

    '        sqlConexion.Open()
    '        sqlAdaptador.SelectCommand = sqlComando
    '        sqlAdaptador.Fill(ds)

    '    Catch ex As Exception
    '        Throw ex
    '    Finally
    '        sqlConexion.Close()
    '        sqlComando.Parameters.Clear()
    '        sqlComando.Connection.Close()
    '    End Try

    'End Sub

    Public Function V_WMS_DOWNLOAD_PEDIDOS_CLIENTES() As DataSet

        Dim sqlConexion As New SqlConnection(strConexionSQL)
        Dim sqlAdaptador As New SqlDataAdapter
        Dim sqlComando As SqlCommand = New SqlCommand
        Dim ds As New DataSet

        Try

            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.Text
            sqlComando.CommandText = "SELECT * FROM V_WMS_DOWNLOAD_PEDIDOS_CLIENTES"
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

    'Public Function V_WMS_DOWNLOAD_PEDIDOS_SKU() As DataSet

    '    Dim sqlConexion As New SqlConnection(strConexionSQL)
    '    Dim sqlAdaptador As New SqlDataAdapter
    '    Dim sqlComando As SqlCommand = New SqlCommand
    '    Dim ds As New DataSet

    '    Try

    '        sqlComando.Connection = sqlConexion
    '        sqlComando.CommandType = CommandType.Text
    '        sqlComando.CommandText = "SELECT * FROM V_WMS_DOWNLOAD_PEDIDOS_SKU"
    '        sqlComando.CommandTimeout = 0

    '        sqlConexion.Open()
    '        sqlAdaptador.SelectCommand = sqlComando
    '        sqlAdaptador.Fill(ds)

    '    Catch ex As Exception
    '        Throw ex
    '    Finally
    '        sqlConexion.Close()
    '        sqlComando.Parameters.Clear()
    '        sqlComando.Connection.Close()
    '    End Try

    '    Return ds

    'End Function

    'Public Function V_WMS_VALIDAR_PEDIDOS_PENDIENTES() As DataSet

    '    Dim sqlConexion As New SqlConnection(strConexionSQL)
    '    Dim sqlAdaptador As New SqlDataAdapter
    '    Dim sqlComando As SqlCommand = New SqlCommand
    '    Dim ds As New DataSet

    '    Try

    '        sqlComando.Connection = sqlConexion
    '        sqlComando.CommandType = CommandType.Text
    '        sqlComando.CommandText = "SELECT * FROM V_WMS_VALIDAR_PEDIDOS_PENDIENTES"
    '        sqlComando.CommandTimeout = 0

    '        sqlConexion.Open()
    '        sqlAdaptador.SelectCommand = sqlComando
    '        sqlAdaptador.Fill(ds)

    '    Catch ex As Exception
    '        Throw ex
    '    Finally
    '        sqlConexion.Close()
    '        sqlComando.Parameters.Clear()
    '        sqlComando.Connection.Close()
    '    End Try

    '    Return ds

    'End Function


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

    Public Sub sp_WMS_ION_Limpiar_RECEIPT(ByVal EXTERNRECEIPTKEY As String)

        Dim sqlConexion As SqlConnection
        Dim sqlComando As SqlCommand = New SqlCommand

        Try

            sqlConexion = New SqlConnection(strConexionSQL)

            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_ION_Limpiar_RECEIPT"
            sqlComando.CommandTimeout = 0

            sqlComando.Parameters.AddWithValue("@EXTERNRECEIPTKEY", EXTERNRECEIPTKEY)

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

    Public Sub sp_WMS_ION_Limpiar_ORDERS(ByVal EXTERNORDERKEY As String)

        Dim sqlConexion As SqlConnection
        Dim sqlComando As SqlCommand = New SqlCommand

        Try

            sqlConexion = New SqlConnection(strConexionSQL)

            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_ION_Limpiar_ORDERS"
            sqlComando.CommandTimeout = 0

            sqlComando.Parameters.AddWithValue("@EXTERNORDERKEY", EXTERNORDERKEY)

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



    'Sub New()

    '    If My.Settings.bitPruebas Then
    '        strConexionSQL = My.Settings.strConexionSQL_Pruebas
    '        strConexionWMS = My.Settings.strConexionWMS_Pruebas
    '        strConexionION = My.Settings.strConexion_ION_Pruebas
    '    Else
    '        strConexionSQL = My.Settings.strConexionSQL
    '        strConexionWMS = My.Settings.strConexionWMS
    '        strConexionION = My.Settings.strConexion_ION
    '    End If

    'End Sub



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


    Public Function sp_Siesa_Update_OC_Pedidos(ByVal numdoc As String, ByVal oc As String) As DataSet

        Dim sqlConexion As New SqlConnection(strConexionSQL)
        Dim sqlAdaptador As New SqlDataAdapter
        Dim sqlComando As SqlCommand = New SqlCommand
        Dim ds As New DataSet

        Try
            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_Siesa_Update_OC_Pedidos"
            sqlComando.CommandTimeout = 0

            sqlComando.Parameters.AddWithValue("@cia", "2")
            sqlComando.Parameters.AddWithValue("@co", "001")
            sqlComando.Parameters.AddWithValue("@tipodoc", "PEE")
            sqlComando.Parameters.AddWithValue("@numdoc", numdoc)
            sqlComando.Parameters.AddWithValue("@oc", oc)

            sqlComando.Connection.Open()
            sqlComando.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        Finally
            sqlConexion.Close()
            sqlComando.Parameters.Clear()
            sqlComando.Connection.Close()
        End Try

        Return ds

    End Function


    Public Function sp_WMS_DOWNLOAD_Requsiciones_Migrar() As DataSet

        Dim sqlConexion As New SqlConnection(strConexionSQL)
        Dim sqlAdaptador As New SqlDataAdapter
        Dim sqlComando As SqlCommand = New SqlCommand
        Dim ds As New DataSet

        Try
            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_DOWNLOAD_Requsiciones_Migrar"
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

        Return ds

    End Function


    Public Function sp_WMS_DOWNLOAD_Requsiciones_Packs() As DataSet

        Dim sqlConexion As New SqlConnection(strConexionSQL)
        Dim sqlAdaptador As New SqlDataAdapter
        Dim sqlComando As SqlCommand = New SqlCommand
        Dim ds As New DataSet

        Try
            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_DOWNLOAD_Requsiciones_Packs"
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

    Public Function sp_WMS_DOWNLOAD_Requsiciones(ByVal paquete As String) As DataSet

        Dim sqlConexion As New SqlConnection(strConexionSQL)
        Dim sqlAdaptador As New SqlDataAdapter
        Dim sqlComando As SqlCommand = New SqlCommand
        Dim ds As New DataSet

        Try
            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_DOWNLOAD_Requsiciones"
            sqlComando.CommandTimeout = 0

            sqlComando.Parameters.AddWithValue("@paquete", paquete)

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


    Public Sub sp_WMS_ION_DOWNLOAD_INT_RECEIPT(ByVal objReceipt As clsModelo_Receipt)


        Dim sqlConexion As SqlConnection
        Dim sqlComando As SqlCommand = New SqlCommand

        Try

            sqlConexion = New SqlConnection(strConexionSQL)

            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_ION_DOWNLOAD_INT_RECEIPT"
            sqlComando.CommandTimeout = 0

            sqlComando.Parameters.AddWithValue("@STORERKEY", objReceipt.STORERKEY)
            sqlComando.Parameters.AddWithValue("@EXTERNRECEIPTKEY", objReceipt.EXTERNRECEIPTKEY)
            sqlComando.Parameters.AddWithValue("@TYPE", objReceipt.TYPE)
            sqlComando.Parameters.AddWithValue("@NOTES", objReceipt.NOTES)
            sqlComando.Parameters.AddWithValue("@SUSR1", objReceipt.SUSR1)
            sqlComando.Parameters.AddWithValue("@SUSR2", objReceipt.SUSR2)
            sqlComando.Parameters.AddWithValue("@SUSR3", objReceipt.SUSR3)
            sqlComando.Parameters.AddWithValue("@WHSEID", objReceipt.WHSEID)
            sqlComando.Parameters.AddWithValue("@SUPPLIERCODE", objReceipt.SUPPLIERCODE)


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

    Public Sub sp_WMS_ION_DOWNLOAD_INT_RECEIPTDETAIL(ByVal objReceiptDetail As clsModelo_ReceiptDetail)

        Dim sqlConexion As SqlConnection
        Dim sqlComando As SqlCommand = New SqlCommand

        Try

            sqlConexion = New SqlConnection(strConexionSQL)

            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_ION_DOWNLOAD_INT_RECEIPTDETAIL"
            sqlComando.CommandTimeout = 0

            sqlComando.Parameters.AddWithValue("@STORERKEY", objReceiptDetail.STORERKEY)
            sqlComando.Parameters.AddWithValue("@EXTERNRECEIPTKEY", objReceiptDetail.EXTERNRECEIPTKEY)
            sqlComando.Parameters.AddWithValue("@EXTERNLINENO", objReceiptDetail.EXTERNLINENO)
            sqlComando.Parameters.AddWithValue("@SKU", objReceiptDetail.SKU)
            sqlComando.Parameters.AddWithValue("@QTYEXPECTED", objReceiptDetail.QTYEXPECTED)
            sqlComando.Parameters.AddWithValue("@UOM", objReceiptDetail.UOM)
            sqlComando.Parameters.AddWithValue("@SUSR1", objReceiptDetail.SUSR1)
            sqlComando.Parameters.AddWithValue("@SUSR2", objReceiptDetail.SUSR2)
            sqlComando.Parameters.AddWithValue("@SUSR3", objReceiptDetail.SUSR3)
            sqlComando.Parameters.AddWithValue("@SUSR5", objReceiptDetail.SUSR5)
            sqlComando.Parameters.AddWithValue("@WHSEID", objReceiptDetail.WHSEID)

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

    Public Sub sp_WMS_ION_DOWNLOAD_INT_ORDER(ByVal objOrders As clsModelo_Orders)


        Dim sqlConexion As SqlConnection
        Dim sqlComando As SqlCommand = New SqlCommand

        Try

            sqlConexion = New SqlConnection(strConexionSQL)

            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_ION_DOWNLOAD_INT_ORDER"
            sqlComando.CommandTimeout = 0

            sqlComando.Parameters.AddWithValue("@STORERKEY", objOrders.STORERKEY)
            sqlComando.Parameters.AddWithValue("@EXTERNORDERKEY", objOrders.EXTERNORDERKEY)
            sqlComando.Parameters.AddWithValue("@TYPE", objOrders.TYPE)
            sqlComando.Parameters.AddWithValue("@CONSIGNEEKEY", objOrders.CONSIGNEEKEY)
            sqlComando.Parameters.AddWithValue("@SUSR1", objOrders.SUSR1)
            sqlComando.Parameters.AddWithValue("@SUSR2", objOrders.SUSR2)
            sqlComando.Parameters.AddWithValue("@SUSR3", objOrders.SUSR3)
            sqlComando.Parameters.AddWithValue("@SUSR4", objOrders.SUSR4)
            sqlComando.Parameters.AddWithValue("@B_CONTACT1", objOrders.B_CONTACT1)
            sqlComando.Parameters.AddWithValue("@WHSEID", objOrders.WHSEID)
            sqlComando.Parameters.AddWithValue("@NOTES", objOrders.NOTES)
            sqlComando.Parameters.AddWithValue("@DELIVERYDATE", objOrders.DELIVERYDATE)
            'sqlComando.Parameters.AddWithValue("@Fecha_erp", objOrders.Fecha_erp)
            'sqlComando.Parameters.AddWithValue("@Fecha_ION", objOrders.Fecha_ION)
            'sqlComando.Parameters.AddWithValue("@ION_flag", objOrders.ION_flag)


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

    Public Sub sp_WMS_ION_DOWNLOAD_INT_ORDERDETAIL(ByVal objOrdersDetails As clsModelo_OrderDetails)

        Dim sqlConexion As SqlConnection
        Dim sqlComando As SqlCommand = New SqlCommand

        Try

            sqlConexion = New SqlConnection(strConexionSQL)

            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_ION_DOWNLOAD_INT_ORDERDETAIL"
            sqlComando.CommandTimeout = 0

            sqlComando.Parameters.AddWithValue("@STORERKEY", objOrdersDetails.STORERKEY)
            sqlComando.Parameters.AddWithValue("@EXTERNORDERKEY", objOrdersDetails.EXTERNORDERKEY)
            sqlComando.Parameters.AddWithValue("@EXTERNLINENO", objOrdersDetails.EXTERNLINENO)
            sqlComando.Parameters.AddWithValue("@SKU", objOrdersDetails.SKU)
            sqlComando.Parameters.AddWithValue("@UOM", objOrdersDetails.UOM)
            sqlComando.Parameters.AddWithValue("@OPENQTY", objOrdersDetails.OPENQTY)
            sqlComando.Parameters.AddWithValue("@ORIGINALQTY", objOrdersDetails.ORIGINALQTY)
            sqlComando.Parameters.AddWithValue("@SUSR1", objOrdersDetails.SUSR1)
            sqlComando.Parameters.AddWithValue("@SUSR2", objOrdersDetails.SUSR2)
            sqlComando.Parameters.AddWithValue("@SUSR3", objOrdersDetails.SUSR3)
            sqlComando.Parameters.AddWithValue("@SUSR5", objOrdersDetails.SUSR5)
            sqlComando.Parameters.AddWithValue("@WHSEID", objOrdersDetails.WHSEID)
            sqlComando.Parameters.AddWithValue("@LOTATTRIBUTE06", objOrdersDetails.LOTATTRIBUTE06)
            'sqlComando.Parameters.AddWithValue("@Fecha_erp", objOrdersDetails.Fecha_erp)
            'sqlComando.Parameters.AddWithValue("@Fecha_ION", objOrdersDetails.Fecha_ION)
            'sqlComando.Parameters.AddWithValue("@ION_flag", objOrdersDetails.ION_flag)


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
            MsgBox(ex.Message)
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
            MsgBox(ex.Message)
        Finally
            sqlConexion.Close()
            sqlComando.Parameters.Clear()
            sqlComando.Connection.Close()
        End Try

    End Sub

    Public Sub sp_registrarLog_Download_WMS(Optional cia As String = "",
                                    Optional co As String = "",
                                    Optional tipoDoc As String = "",
                                    Optional numDoc As String = "",
                                    Optional proceso As String = "",
                                    Optional estado As String = "",
                                    Optional resultado As String = "",
                                    Optional resultadoDetalle As String = "")

        Dim sqlConexion As SqlConnection
        Dim sqlComando As SqlCommand = New SqlCommand

        Try

            sqlConexion = New SqlConnection(strConexionSQL)

            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_registrarLog_Download_WMS"
            sqlComando.CommandTimeout = 0

            sqlComando.Parameters.AddWithValue("@cia", cia)
            sqlComando.Parameters.AddWithValue("@co", co)
            sqlComando.Parameters.AddWithValue("@tipoDoc", tipoDoc)
            sqlComando.Parameters.AddWithValue("@numDoc", numDoc)
            sqlComando.Parameters.AddWithValue("@proceso", proceso)
            sqlComando.Parameters.AddWithValue("@estado", estado)
            sqlComando.Parameters.AddWithValue("@resultado", resultado)
            sqlComando.Parameters.AddWithValue("@resultadoDetalle", resultadoDetalle)

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
