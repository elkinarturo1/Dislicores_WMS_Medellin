Imports System.Data.SqlClient

Module ModuloSQL

    Dim strConexionSQL As String = ""
    Dim strConexionWMS As String = ""
    Dim strConexionION As String = ""


    Public Function sp_WMS_DOWNLOAD_Devoluciones_DNF_Migrar() As DataSet

        Dim sqlConexion As New SqlConnection(strConexionSQL)
        Dim sqlAdaptador As New SqlDataAdapter
        Dim sqlComando As SqlCommand = New SqlCommand
        Dim ds As New DataSet

        Try

            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_DOWNLOAD_Devoluciones_DNF_Migrar"
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



    Public Function sp_WMS_DOWNLOAD_Ensambles_ENS_OEX() As DataSet

        Dim sqlConexion As New SqlConnection(strConexionSQL)
        Dim sqlAdaptador As New SqlDataAdapter
        Dim sqlComando As SqlCommand = New SqlCommand
        Dim ds As New DataSet

        Try

            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_DOWNLOAD_Ensambles_ENS_OEX"
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


    Public Function sp_WMS_DOWNLOAD_Devoluciones_DNF_ASN() As DataSet

        Dim sqlConexion As New SqlConnection(strConexionSQL)
        Dim sqlAdaptador As New SqlDataAdapter
        Dim sqlComando As SqlCommand = New SqlCommand
        Dim ds As New DataSet

        Try

            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_DOWNLOAD_Devoluciones_DNF_ASN"
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


    Public Sub sp_WMS_ION_Limpiar_RECEIPT(ByVal EXTERNRECEIPTKEY As String)

        Dim sqlConexion As SqlConnection
        Dim sqlComando As SqlCommand = New SqlCommand

        Try

            sqlConexion = New SqlConnection(strConexionSQL)

            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_ION_Limpiar_RECEIPT"
            'sqlComando.CommandText = "sp_WMS_ION_Limpiar_RECEIPT_Pruebas"
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



    Sub New()

        If My.Settings.bitPruebas Then
            strConexionSQL = My.Settings.strConexionSQL_Pruebas
            strConexionWMS = My.Settings.strConexionWMS_Pruebas
            strConexionION = My.Settings.strConexion_ION_Pruebas
        Else
            strConexionSQL = My.Settings.strConexionSQL
            'strConexionWMS = My.Settings.strConexionWMS
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


    Public Sub sp_WMS_ION_DOWNLOAD_INT_RECEIPT(ByVal objReceipt As clsModelo_Receipt)


        Dim sqlConexion As SqlConnection
        Dim sqlComando As SqlCommand = New SqlCommand

        Try

            sqlConexion = New SqlConnection(strConexionSQL)

            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_ION_DOWNLOAD_INT_RECEIPT"
            'sqlComando.CommandText = "sp_WMS_ION_DOWNLOAD_INT_RECEIPT_Pruebas"
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
            'sqlComando.CommandText = "sp_WMS_ION_DOWNLOAD_INT_RECEIPTDETAIL_Pruebas"
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


    Public Sub sp_A_Registrar_Log_Download_ASN(Optional bitResultado As Boolean = False,
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

        Dim sqlConexion As SqlConnection
        Dim sqlComando As SqlCommand = New SqlCommand

        Try

            sqlConexion = New SqlConnection(My.Settings.strConexionSQL)

            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_A_Registrar_Log_Download_ASN"
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


    Public Sub A_Log_Download_OEX(Optional bitResultado As Boolean = False,
                                  Optional EXTERNORDERKEY_key_doc As String = "",
                                  Optional cia As String = "",
                                  Optional co As String = "",
                                  Optional tipoDoc As String = "",
                                  Optional numDoc As String = "",
                                  Optional SUSR1_rowid_encab As String = "",
                                  Optional D_SUSR1_rowid_detalle As String = "",
                                  Optional SKU_referencia As String = "",
                                  Optional D_SUSR3_bod_destino As String = "",
                                  Optional ORIGINALQTY_cantidad_ped As String = "",
                                  Optional datosEnviados As String = "",
                                  Optional detalleResultado As String = "")

        Dim sqlConexion As SqlConnection
        Dim sqlComando As SqlCommand = New SqlCommand

        Try

            sqlConexion = New SqlConnection(My.Settings.strConexionSQL)

            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "A_Log_Download_OEX"
            sqlComando.CommandTimeout = 0

            sqlComando.Parameters.AddWithValue("@bitResultado", bitResultado)
            sqlComando.Parameters.AddWithValue("@EXTERNORDERKEY_key_doc", EXTERNORDERKEY_key_doc)
            sqlComando.Parameters.AddWithValue("@cia", cia)
            sqlComando.Parameters.AddWithValue("@co", co)
            sqlComando.Parameters.AddWithValue("@tipoDoc", tipoDoc)
            sqlComando.Parameters.AddWithValue("@numDoc", numDoc)
            sqlComando.Parameters.AddWithValue("@SUSR1_rowid_encab", SUSR1_rowid_encab)
            sqlComando.Parameters.AddWithValue("@D_SUSR1_rowid_detalle", D_SUSR1_rowid_detalle)
            sqlComando.Parameters.AddWithValue("@SKU_referencia", SKU_referencia)
            sqlComando.Parameters.AddWithValue("@D_SUSR3_bod_destino", D_SUSR3_bod_destino)
            sqlComando.Parameters.AddWithValue("@ORIGINALQTY_cantidad_ped", ORIGINALQTY_cantidad_ped)
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
