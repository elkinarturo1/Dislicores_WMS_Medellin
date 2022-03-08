Public Class clsEnviarDatos_ION


    Public Sub enviar_OEX_ION_DES(ByRef dt As DataTable, ByRef cia As String, ByRef co As String, ByRef tipoDoc As String, ByRef numDoc As String, ByRef rowIdEncab As String)

        Try
            '===============================================================================================

            For Each registro As DataRow In dt.Rows

                Dim objOrdersDetails As New clsModelo_OrderDetails
                Dim rowIdDetalle As String = ""
                Try

                    rowIdDetalle = registro.Item("d_susr1_rowid_detalle").ToString

                    objOrdersDetails.STORERKEY = Left(registro.Item("STORERKEY_id_cia").ToString, 15)
                    objOrdersDetails.EXTERNORDERKEY = Left(registro.Item("EXTERNORDERKEY_key_doc").ToString, 32)
                    objOrdersDetails.EXTERNLINENO = Left(registro.Item("externlineno_num_lin").ToString, 20)
                    objOrdersDetails.SKU = Left(registro.Item("SKU_referencia").ToString, 50)
                    objOrdersDetails.UOM = Left(registro.Item("uom_uni_med_wms").ToString, 10)
                    objOrdersDetails.OPENQTY = registro.Item("OPENQTY_nada").ToString
                    objOrdersDetails.ORIGINALQTY = registro.Item("qtyexpected_can_ped").ToString
                    objOrdersDetails.SUSR1 = Left(registro.Item("D_SUSR1_rowid_detalle").ToString, 30)
                    objOrdersDetails.SUSR2 = Left(registro.Item("D_SUSR2_bod_origen").ToString, 30)
                    objOrdersDetails.SUSR3 = Left(registro.Item("D_SUSR3_bod_destino").ToString, 30)
                    objOrdersDetails.SUSR5 = Left(registro.Item("D_SUSR5_motivo").ToString, 30)
                    objOrdersDetails.WHSEID = Left(registro.Item("whseid_co_docto").ToString, 30)

                    ModuloSQL.sp_WMS_ION_DOWNLOAD_INT_ORDERDETAIL(objOrdersDetails)

                Catch ex As Exception
                    ModuloSQL.A_Log_Download_OEX(True, objOrdersDetails.EXTERNORDERKEY, cia, co, tipoDoc, numDoc, rowIdEncab, rowIdDetalle, objOrdersDetails.SKU,
                    objOrdersDetails.SUSR3, objOrdersDetails.OPENQTY,, "Error al Enviar datos ION enviar_OEX_ION_PEV - " & ex.Message)
                End Try

            Next

            '===============================================================================================

            '===============================================================================================
            'Encabezado
            For Each registro As DataRow In dt.Rows

                Dim objOrders As New clsModelo_Orders

                Try

                    objOrders.STORERKEY = Left(registro.Item("STORERKEY_id_cia").ToString, 15)
                    objOrders.EXTERNORDERKEY = Left(registro.Item("EXTERNORDERKEY_key_doc").ToString, 32)
                    objOrders.TYPE = Left(registro.Item("type_tipo_doc").ToString, 10)
                    objOrders.CONSIGNEEKEY = Left(registro.Item("CONSIGNEEKEY_cliente").ToString, 15)
                    objOrders.SUSR1 = Left(registro.Item("SUSR1_rowid_encab").ToString, 30)
                    objOrders.SUSR2 = Left(registro.Item("SUSR2_zona_logistica").ToString, 30)
                    objOrders.SUSR3 = Left(registro.Item("SUSR2_co_docto").ToString, 30) 'Anteriormente Susr3
                    objOrders.SUSR4 = Left(registro.Item("SUSR4_canal").ToString, 30)
                    objOrders.B_CONTACT1 = Left(Replace(Replace(registro.Item("B_CONTACT1_ven_act").ToString, Chr(10), ""), Chr(13), ""), 30)
                    objOrders.WHSEID = Left(registro.Item("whseid_co_docto").ToString, 30)
                    objOrders.NOTES = Left(Replace(Replace(registro.Item("f350_notas").ToString, Chr(10), ""), Chr(13), ""), 60)
                    objOrders.DELIVERYDATE = CDate(registro.Item("fech_crea").ToString)

                    ModuloSQL.sp_WMS_ION_DOWNLOAD_INT_ORDER(objOrders)

                Catch ex As Exception
                    ModuloSQL.A_Log_Download_OEX(True, objOrders.EXTERNORDERKEY, cia, co, tipoDoc, numDoc, rowIdEncab,,,,,, "Error al Enviar datos ION enviar_OEX_ION_PEV - " & ex.Message)
                End Try

                'Solo se ejecuta una vez
                Exit For

            Next
            '===============================================================================================

        Catch ex As Exception
            Dim resultado As String = ex.Message
        End Try


    End Sub



    Public Sub enviar_ASN_ION_DNF(ByRef dt As DataTable, ByRef cia As String, ByRef co As String, ByRef tipoDoc As String, ByRef numDoc As String, ByRef rowIdEncab As String)

        Try

            '===============================================================================================

            For Each registro As DataRow In dt.Rows

                Dim objReceiptDetail As New clsModelo_ReceiptDetail
                Dim rowIdDetalle As String = ""

                Try

                    rowIdDetalle = registro.Item("d_susr1_rowid_detalle").ToString

                    objReceiptDetail.STORERKEY = Left(registro.Item("storerkey_id_cia").ToString, 15)
                    objReceiptDetail.EXTERNRECEIPTKEY = Left(registro.Item("EXTERNRECEIPT_KEY").ToString, 32)
                    objReceiptDetail.EXTERNLINENO = Left(registro.Item("externlineno_num_lin").ToString, 20)
                    objReceiptDetail.SKU = Left(registro.Item("sku_referencia").ToString, 50)
                    objReceiptDetail.QTYEXPECTED = Left(registro.Item("qtyexpected_can_ped").ToString, 50)
                    objReceiptDetail.UOM = Left(registro.Item("uom_uni_med_wms").ToString, 10)
                    objReceiptDetail.SUSR1 = Left(registro.Item("d_susr1_rowid_detalle").ToString, 30)
                    objReceiptDetail.SUSR2 = Left(registro.Item("d_susr2_bod_origen").ToString, 30)
                    objReceiptDetail.SUSR3 = Left(registro.Item("d_susr3_bod_destino").ToString, 30)
                    objReceiptDetail.SUSR5 = Left(registro.Item("d_susr5_motivo").ToString, 30)
                    objReceiptDetail.WHSEID = Left(registro.Item("whseid_co_docto").ToString, 30)

                    sp_WMS_ION_DOWNLOAD_INT_RECEIPTDETAIL(objReceiptDetail)

                Catch ex As Exception
                    ModuloSQL.sp_A_Registrar_Log_Download_ASN(True, objReceiptDetail.EXTERNRECEIPTKEY, cia, co, tipoDoc, numDoc, rowIdEncab, rowIdDetalle, objReceiptDetail.SKU,
                   objReceiptDetail.SUSR2, objReceiptDetail.SUSR3, objReceiptDetail.QTYEXPECTED,, "Error al Enviar datos ION enviar_OEX_ION_PEV - " & ex.Message)
                End Try

            Next

            '===============================================================================================

            '===============================================================================================
            'Encabezado
            For Each registro As DataRow In dt.Rows

                Dim objReceipt As New clsModelo_Receipt

                Try

                    objReceipt.STORERKEY = Left(registro.Item("storerkey_id_cia").ToString, 15)
                    objReceipt.EXTERNRECEIPTKEY = Left(registro.Item("EXTERNRECEIPT_KEY").ToString, 32)
                    objReceipt.TYPE = Left(registro.Item("type_tipo_doc").ToString, 10)
                    objReceipt.NOTES = Left(Replace(Replace(registro.Item("f350_notas").ToString, Chr(10), ""), Chr(13), ""), 60)
                    objReceipt.SUSR1 = Left(registro.Item("susr1_rowid_encab").ToString, 30)
                    objReceipt.SUSR2 = Left(registro.Item("susr2_co_docto").ToString, 30)
                    objReceipt.SUSR3 = Left(registro.Item("susr3_consec_docto").ToString, 30)
                    objReceipt.WHSEID = Left(registro.Item("whseid_co_docto").ToString, 30)
                    objReceipt.SUPPLIERCODE = ""

                    sp_WMS_ION_DOWNLOAD_INT_RECEIPT(objReceipt)

                Catch ex As Exception
                    ModuloSQL.sp_A_Registrar_Log_Download_ASN(True, objReceipt.EXTERNRECEIPTKEY, cia, co, tipoDoc, numDoc, rowIdEncab,,,,,,, "Error al Enviar datos ION enviar_OEX_ION_PEV - " & ex.Message)
                End Try

                'Solo se ejecuta una vez
                Exit For

            Next
            '===============================================================================================

        Catch ex As Exception
            Dim resultado As String = ex.Message
        End Try


    End Sub



    'Public Sub enviar_ASN_ION_OCP(ByRef dt As DataTable, ByRef cia As String, ByRef co As String, ByRef tipoDoc As String, ByRef numDoc As String, ByRef rowIdEncab As String)

    '    Try

    '        '===============================================================================================

    '        For Each registro As DataRow In dt.Rows

    '            Dim objPODetail As New clsModelo_PO_Detail
    '            Dim rowIdDetalle As String = ""

    '            Try

    '                objPODetail.STORERKEY = Left(registro.Item("storerkey_id_cia").ToString, 15)
    '                objPODetail.EXTERNPOKEY = Left(registro.Item("externpokey_key_docto").ToString, 50)
    '                objPODetail.EXTERNLINENO = Left(registro.Item("externlineno_num_lin").ToString, 20)
    '                objPODetail.SKU = Left(registro.Item("sku_referencia").ToString, 50)
    '                objPODetail.QTYEXPECTED = Left(registro.Item("qtyexpected_can_ped").ToString, 22)
    '                objPODetail.UOM = Left(registro.Item("uom_uni_med_wms").ToString, 10)
    '                objPODetail.WHSEID = Left(registro.Item("whseid_co_docto").ToString, 10)
    '                objPODetail.lotattribute06 = Left(registro.Item("lotattribute06_rentas").ToString, 30)
    '                objPODetail.SUSR1 = Left(registro.Item("d_susr1_rowid_detalle").ToString, 30)
    '                objPODetail.SUSR2 = Left(registro.Item("d_susr2_bod_origen").ToString, 30)
    '                objPODetail.SUSR3 = Left(registro.Item("d_susr3_bod_destino").ToString, 30)
    '                objPODetail.SUSR5 = Left(registro.Item("d_susr5_motivo").ToString, 30)

    '                'ModuloSQL.sp_WMS_ION_DOWNLOAD_INT_PODETAIL(objPODetail)

    '            Catch ex As Exception
    '                ModuloSQL.sp_A_Registrar_Log_Download_Orden_Compra_OCP(True, objPODetail.EXTERNPOKEY, cia, co, tipoDoc, numDoc, rowIdEncab, rowIdDetalle, objPODetail.SKU,
    '                objPODetail.SUSR3, objPODetail.QTYEXPECTED,, "Error al Enviar datos ION enviar_OEX_ION_PEV - " & ex.Message)
    '            End Try

    '        Next

    '        '===============================================================================================

    '        '===============================================================================================
    '        'Encabezado
    '        For Each registro As DataRow In dt.Rows

    '            Dim objPO As New clsModelo_PO

    '            Try

    '                objPO.STORERKEY = Left(registro.Item("storerkey_id_cia").ToString, 15)
    '                objPO.EXTERNPOKEY = Left(registro.Item("externpokey_key_docto").ToString, 50)
    '                objPO.TYPE = Left(registro.Item("type_tipo_doc").ToString, 10)
    '                objPO.SELLERNAME = Left(registro.Item("sellername_cod_prov").ToString, 45)
    '                objPO.WHSEID = Left(registro.Item("whseid_co_docto").ToString, 30)
    '                objPO.EXPECTEDRECEIPTDATE = Left(registro.Item("expectedreceiptdate_fec_entre").ToString, 30)
    '                objPO.SUSR1 = Left(registro.Item("susr1_rowid_encab").ToString, 30)
    '                objPO.SUSR2 = Left(registro.Item("susr2_co_docto").ToString, 30)
    '                objPO.SUSR3 = Left(registro.Item("susr3_consec_docto").ToString, 30)

    '                ModuloSQL.sp_WMS_ION_DOWNLOAD_INT_PO(objPO)

    '            Catch ex As Exception
    '                ModuloSQL.sp_A_Registrar_Log_Download_Orden_Compra_OCP(True, objPO.EXTERNPOKEY, cia, co, tipoDoc, numDoc, rowIdEncab,,,,,, "Error al Enviar datos ION enviar_OEX_ION_PEV - " & ex.Message)
    '            End Try

    '            'Solo se ejecuta una vez
    '            Exit For

    '        Next
    '        '===============================================================================================

    '    Catch ex As Exception
    '        Dim resultado As String = ex.Message
    '    End Try

    'End Sub

    'Public Sub enviar_OEX_ION_PEV(ByRef dt As DataTable, ByRef cia As String, ByRef co As String, ByRef tipoDoc As String, ByRef numDoc As String, ByRef rowIdEncab As String)

    '    Try
    '        '===============================================================================================

    '        For Each registro As DataRow In dt.Rows

    '            Dim objOrdersDetails As New clsModelo_OrderDetails
    '            Dim rowIdDetalle As String = ""
    '            Try

    '                rowIdDetalle = registro.Item("d_susr1_rowid_detalle").ToString

    '                objOrdersDetails.STORERKEY = Left(registro.Item("STORERKEY_id_cia").ToString, 15)
    '                objOrdersDetails.EXTERNORDERKEY = Left(registro.Item("EXTERNORDERKEY_key_doc").ToString, 32)
    '                objOrdersDetails.EXTERNLINENO = Left(registro.Item("EXTERNLINENO_consec_linea").ToString, 20)
    '                objOrdersDetails.SKU = Left(registro.Item("SKU_referencia").ToString, 50)
    '                objOrdersDetails.UOM = Left(registro.Item("UOM_und_wms").ToString, 10)
    '                objOrdersDetails.OPENQTY = registro.Item("OPENQTY_nada").ToString
    '                objOrdersDetails.ORIGINALQTY = registro.Item("ORIGINALQTY_cantidad_ped").ToString
    '                objOrdersDetails.SUSR1 = Left(registro.Item("D_SUSR1_rowid_detalle").ToString, 30)
    '                objOrdersDetails.SUSR2 = Left(registro.Item("D_SUSR2_bod_origen").ToString, 30)
    '                objOrdersDetails.SUSR3 = Left(registro.Item("D_SUSR3_bod_destino").ToString, 30)
    '                objOrdersDetails.SUSR5 = Left(registro.Item("D_SUSR5_motivo").ToString, 30)
    '                objOrdersDetails.WHSEID = Left(registro.Item("WHSEID_co_doc").ToString, 30)

    '                sp_WMS_ION_DOWNLOAD_INT_ORDERDETAIL(objOrdersDetails)

    '            Catch ex As Exception
    '                sp_A_Registrar_Log_Download_Pedidos_PEV(True, objOrdersDetails.EXTERNORDERKEY, cia, co, tipoDoc, numDoc, rowIdEncab, rowIdDetalle, objOrdersDetails.SKU,
    '                objOrdersDetails.SUSR3, objOrdersDetails.OPENQTY,, "Error al Enviar datos ION enviar_OEX_ION_PEV - " & ex.Message)
    '            End Try

    '        Next

    '        '===============================================================================================

    '        '===============================================================================================
    '        'Encabezado
    '        For Each registro As DataRow In dt.Rows

    '            Dim objOrders As New clsModelo_Orders

    '            Try

    '                objOrders.STORERKEY = Left(registro.Item("STORERKEY_id_cia").ToString, 15)
    '                objOrders.EXTERNORDERKEY = Left(registro.Item("EXTERNORDERKEY_key_doc").ToString, 32)
    '                objOrders.TYPE = Left(registro.Item("TYPE_tip_doc").ToString, 10)
    '                objOrders.CONSIGNEEKEY = Left(registro.Item("CONSIGNEEKEY_cliente").ToString, 15)
    '                objOrders.SUSR1 = Left(registro.Item("SUSR1_rowid_encab").ToString, 30)
    '                objOrders.SUSR2 = Left(registro.Item("SUSR2_zona_logistica").ToString, 30)
    '                objOrders.SUSR3 = Left(registro.Item("SUSR3_co_doc").ToString, 30)
    '                objOrders.SUSR4 = Left(registro.Item("SUSR4_canal").ToString, 30)
    '                objOrders.B_CONTACT1 = Left(Replace(Replace(registro.Item("B_CONTACT1_ven_act").ToString, Chr(10), ""), Chr(13), ""), 30)
    '                objOrders.WHSEID = Left(registro.Item("WHSEID_co_doc").ToString, 30)
    '                objOrders.NOTES = Left(Replace(Replace(registro.Item("NOTES_notas").ToString, Chr(10), ""), Chr(13), ""), 60)
    '                objOrders.DELIVERYDATE = CDate(registro.Item("DELIVERYDATE_fec_entre").ToString)

    '                sp_WMS_ION_DOWNLOAD_INT_ORDER(objOrders)

    '            Catch ex As Exception
    '                sp_A_Registrar_Log_Download_Pedidos_PEV(True, objOrders.EXTERNORDERKEY, cia, co, tipoDoc, numDoc, rowIdEncab,,,,,, "Error al Enviar datos ION enviar_OEX_ION_PEV - " & ex.Message)
    '            End Try

    '            'Solo se ejecuta una vez
    '            Exit For

    '        Next
    '        '===============================================================================================

    '    Catch ex As Exception
    '        Dim resultado As String = ex.Message
    '    End Try


    'End Sub

    'Public Sub enviar_OEX_ION_RQT(ByRef dt As DataTable)

    '    Try

    '        '===============================================================================================

    '        For Each registro As DataRow In dt.Rows

    '            Dim objOrdersDetails As New clsModelo_OrderDetails

    '            Try

    '                objOrdersDetails.STORERKEY = Left(registro.Item("storerkey_id_cia").ToString, 15)
    '                objOrdersDetails.EXTERNORDERKEY = Left(registro.Item("externorderkey_key_doc").ToString, 32)
    '                objOrdersDetails.EXTERNLINENO = Left(registro.Item("externlineno_consec_linea").ToString, 20)
    '                objOrdersDetails.SKU = Left(registro.Item("SKU_referencia").ToString, 50)
    '                objOrdersDetails.UOM = Left(registro.Item("uom_und_wms").ToString, 10)
    '                objOrdersDetails.OPENQTY = registro.Item("openqty_nada").ToString
    '                objOrdersDetails.ORIGINALQTY = registro.Item("originalqty_cantidad_ped").ToString
    '                objOrdersDetails.SUSR1 = Left(registro.Item("d_susr1_rowid_detalle").ToString, 30)
    '                objOrdersDetails.SUSR2 = Left(registro.Item("d_susr2_bod_origen").ToString, 30)
    '                objOrdersDetails.SUSR3 = Left(registro.Item("d_susr3_bod_destino").ToString, 30)
    '                objOrdersDetails.SUSR5 = Left(registro.Item("d_susr5_motivo").ToString, 30)
    '                objOrdersDetails.WHSEID = Left(registro.Item("whseid_co_doc").ToString, 30)

    '                sp_WMS_ION_DOWNLOAD_INT_ORDERDETAIL(objOrdersDetails)

    '            Catch ex As Exception
    '                ' ' sp_registrarLog_Download_WMS(2, 1, "RQT", objOrdersDetails.EXTERNORDERKEY, "Migrando Datos Detalle : ", "Fin", "Error", "Referencia : " & objOrdersDetails.SKU & " --- Cantidad : " & objOrdersDetails.ORIGINALQTY & " - " & ex.Message)
    '            End Try

    '        Next

    '        '===============================================================================================

    '        '===============================================================================================
    '        'Encabezado
    '        For Each registro As DataRow In dt.Rows

    '            Dim objOrders As New clsModelo_Orders

    '            Try

    '                objOrders.STORERKEY = Left(registro.Item("storerkey_id_cia").ToString, 15)
    '                objOrders.EXTERNORDERKEY = Left(registro.Item("externorderkey_key_doc").ToString, 32)
    '                objOrders.TYPE = Left(registro.Item("type_tip_doc").ToString, 10)
    '                objOrders.CONSIGNEEKEY = Left(registro.Item("consigneekey_cliente").ToString, 15)
    '                objOrders.SUSR1 = Left(registro.Item("susr1_rowid_encab").ToString, 30)
    '                objOrders.SUSR2 = Left(registro.Item("susr2_zona_logistica").ToString, 30)
    '                objOrders.SUSR3 = Left(registro.Item("susr3_co_doc").ToString, 30)
    '                objOrders.SUSR4 = Left(registro.Item("susr4_canal").ToString, 30)
    '                objOrders.B_CONTACT1 = Left(Replace(Replace(registro.Item("b_contact1_ven_act").ToString, Chr(10), ""), Chr(13), ""), 30)
    '                objOrders.WHSEID = Left(registro.Item("whseid_co_doc").ToString, 30)
    '                objOrders.NOTES = Left(Replace(Replace(registro.Item("notes_notas").ToString, Chr(10), ""), Chr(13), ""), 60)
    '                objOrders.DELIVERYDATE = CDate(registro.Item("deliverydate_fec_entre").ToString)

    '                sp_WMS_ION_DOWNLOAD_INT_ORDER(objOrders)

    '            Catch ex As Exception
    '                ' ' sp_registrarLog_Download_WMS(2, 1, "RQT", objOrders.EXTERNORDERKEY, "Migrando Datos Encabezado : ", "Fin", "Error", "Referencia : " & objOrders.EXTERNORDERKEY & ex.Message)
    '            End Try

    '            'Solo se ejecuta una vez
    '            Exit For

    '        Next
    '        '===============================================================================================

    '    Catch ex As Exception
    '        Dim resultado As String = ex.Message
    '    End Try


    'End Sub

    'Public Sub enviar_OEX_ION_RQV(ByRef dt As DataTable)

    '    Try

    '        '===============================================================================================

    '        For Each registro As DataRow In dt.Rows

    '            Dim objOrdersDetails As New clsModelo_OrderDetails

    '            Try

    '                objOrdersDetails.STORERKEY = Left(registro.Item("storerkey_id_cia").ToString, 15)
    '                objOrdersDetails.EXTERNORDERKEY = Left(registro.Item("externorderkey_key_doc").ToString, 32)
    '                objOrdersDetails.EXTERNLINENO = Left(registro.Item("externlineno_consec_linea").ToString, 20)
    '                objOrdersDetails.SKU = Left(registro.Item("SKU_referencia").ToString, 50)
    '                objOrdersDetails.UOM = Left(registro.Item("uom_und_wms").ToString, 10)
    '                objOrdersDetails.OPENQTY = registro.Item("openqty_nada").ToString
    '                objOrdersDetails.ORIGINALQTY = registro.Item("originalqty_cantidad_ped").ToString
    '                objOrdersDetails.SUSR1 = Left(registro.Item("d_susr1_rowid_detalle").ToString, 30)
    '                objOrdersDetails.SUSR2 = Left(registro.Item("d_susr2_bod_origen").ToString, 30)
    '                objOrdersDetails.SUSR3 = Left(registro.Item("d_susr3_bod_destino").ToString, 30)
    '                objOrdersDetails.SUSR5 = Left(registro.Item("d_susr5_motivo").ToString, 30)
    '                objOrdersDetails.WHSEID = Left(registro.Item("whseid_co_doc").ToString, 30)

    '                sp_WMS_ION_DOWNLOAD_INT_ORDERDETAIL(objOrdersDetails)

    '            Catch ex As Exception
    '                ' ' sp_registrarLog_Download_WMS(2, 1, "RQV", objOrdersDetails.EXTERNORDERKEY, "Migrando Datos Detalle : ", "Fin", "Error", "Referencia : " & objOrdersDetails.SKU & " --- Cantidad : " & objOrdersDetails.ORIGINALQTY & " - " & ex.Message)
    '            End Try

    '        Next

    '        '===============================================================================================

    '        '===============================================================================================
    '        'Encabezado
    '        For Each registro As DataRow In dt.Rows

    '            Dim objOrders As New clsModelo_Orders

    '            Try

    '                objOrders.STORERKEY = Left(registro.Item("storerkey_id_cia").ToString, 15)
    '                objOrders.EXTERNORDERKEY = Left(registro.Item("externorderkey_key_doc").ToString, 32)
    '                objOrders.TYPE = Left(registro.Item("type_tip_doc").ToString, 10)
    '                objOrders.CONSIGNEEKEY = Left(registro.Item("consigneekey_cliente").ToString, 15)
    '                objOrders.SUSR1 = Left(registro.Item("susr1_rowid_encab").ToString, 30)
    '                objOrders.SUSR2 = Left(registro.Item("susr2_zona_logistica").ToString, 30)
    '                objOrders.SUSR3 = Left(registro.Item("susr3_co_doc").ToString, 30)
    '                objOrders.SUSR4 = Left(registro.Item("susr4_canal").ToString, 30)
    '                objOrders.B_CONTACT1 = Left(Replace(Replace(registro.Item("b_contact1_ven_act").ToString, Chr(10), ""), Chr(13), ""), 30)
    '                objOrders.WHSEID = Left(registro.Item("whseid_co_doc").ToString, 30)
    '                objOrders.NOTES = Left(Replace(Replace(registro.Item("notes_notas").ToString, Chr(10), ""), Chr(13), ""), 60)
    '                objOrders.DELIVERYDATE = CDate(registro.Item("deliverydate_fec_entre").ToString)

    '                sp_WMS_ION_DOWNLOAD_INT_ORDER(objOrders)

    '            Catch ex As Exception
    '                ' ' sp_registrarLog_Download_WMS(2, 1, "RQV", objOrders.EXTERNORDERKEY, "Migrando Datos Encabezado : ", "Fin", "Error", "Referencia : " & objOrders.EXTERNORDERKEY & ex.Message)
    '            End Try

    '            'Solo se ejecuta una vez
    '            Exit For

    '        Next
    '        '===============================================================================================

    '    Catch ex As Exception
    '        Dim resultado As String = ex.Message
    '    End Try


    'End Sub

    'Public Sub enviar_OEX_ION_RQI(ByRef dt As DataTable)

    '    Try

    '        '===============================================================================================

    '        For Each registro As DataRow In dt.Rows

    '            Dim objOrdersDetails As New clsModelo_OrderDetails

    '            Try

    '                objOrdersDetails.STORERKEY = Left(registro.Item("storerkey_id_cia").ToString, 15)
    '                objOrdersDetails.EXTERNORDERKEY = Left(registro.Item("externorderkey_key_doc").ToString, 32)
    '                objOrdersDetails.EXTERNLINENO = Left(registro.Item("externlineno_consec_linea").ToString, 20)
    '                objOrdersDetails.SKU = Left(registro.Item("SKU_referencia").ToString, 50)
    '                objOrdersDetails.UOM = Left(registro.Item("uom_und_wms").ToString, 10)
    '                objOrdersDetails.OPENQTY = registro.Item("openqty_nada").ToString
    '                objOrdersDetails.ORIGINALQTY = registro.Item("originalqty_cantidad_ped").ToString
    '                objOrdersDetails.SUSR1 = Left(registro.Item("d_susr1_rowid_detalle").ToString, 30)
    '                objOrdersDetails.SUSR2 = Left(registro.Item("d_susr2_bod_origen").ToString, 30)
    '                objOrdersDetails.SUSR3 = Left(registro.Item("d_susr3_bod_destino").ToString, 30)
    '                objOrdersDetails.SUSR5 = Left(registro.Item("d_susr5_motivo").ToString, 30)
    '                objOrdersDetails.WHSEID = Left(registro.Item("whseid_co_doc").ToString, 30)

    '                sp_WMS_ION_DOWNLOAD_INT_ORDERDETAIL(objOrdersDetails)

    '            Catch ex As Exception
    '                ' ' sp_registrarLog_Download_WMS(2, 1, "RQI", objOrdersDetails.EXTERNORDERKEY, "Migrando Datos Detalle : ", "Fin", "Error", "Referencia : " & objOrdersDetails.SKU & " --- Cantidad : " & objOrdersDetails.ORIGINALQTY & " - " & ex.Message)
    '            End Try

    '        Next

    '        '===============================================================================================

    '        '===============================================================================================
    '        'Encabezado
    '        For Each registro As DataRow In dt.Rows

    '            Dim objOrders As New clsModelo_Orders

    '            Try

    '                objOrders.STORERKEY = Left(registro.Item("storerkey_id_cia").ToString, 15)
    '                objOrders.EXTERNORDERKEY = Left(registro.Item("externorderkey_key_doc").ToString, 32)
    '                objOrders.TYPE = Left(registro.Item("type_tip_doc").ToString, 10)
    '                objOrders.CONSIGNEEKEY = Left(registro.Item("consigneekey_cliente").ToString, 15)
    '                objOrders.SUSR1 = Left(registro.Item("susr1_rowid_encab").ToString, 30)
    '                objOrders.SUSR2 = Left(registro.Item("susr2_zona_logistica").ToString, 30)
    '                objOrders.SUSR3 = Left(registro.Item("susr3_co_doc").ToString, 30)
    '                objOrders.SUSR4 = Left(registro.Item("susr4_canal").ToString, 30)
    '                objOrders.B_CONTACT1 = Left(Replace(Replace(registro.Item("b_contact1_ven_act").ToString, Chr(10), ""), Chr(13), ""), 30)
    '                objOrders.WHSEID = Left(registro.Item("whseid_co_doc").ToString, 30)
    '                objOrders.NOTES = Left(Replace(Replace(registro.Item("notes_notas").ToString, Chr(10), ""), Chr(13), ""), 60)
    '                objOrders.DELIVERYDATE = CDate(registro.Item("deliverydate_fec_entre").ToString)

    '                sp_WMS_ION_DOWNLOAD_INT_ORDER(objOrders)

    '            Catch ex As Exception
    '                ' ' sp_registrarLog_Download_WMS(2, 1, "RQI", objOrders.EXTERNORDERKEY, "Migrando Datos Encabezado : ", "Fin", "Error", "Referencia : " & objOrders.EXTERNORDERKEY & ex.Message)
    '            End Try

    '            'Solo se ejecuta una vez
    '            Exit For

    '        Next
    '        '===============================================================================================

    '    Catch ex As Exception
    '        Dim resultado As String = ex.Message
    '    End Try


    'End Sub





    'Public Sub enviar_ASN_ION_PDC(ByRef dt As DataTable)

    '    Try

    '        '===============================================================================================

    '        For Each registro As DataRow In dt.Rows

    '            Dim objReceiptDetail As New clsModelo_ReceiptDetail

    '            Try

    '                objReceiptDetail.STORERKEY = Left(registro.Item("storerkey_id_cia").ToString, 15)
    '                objReceiptDetail.EXTERNRECEIPTKEY = Left(registro.Item("externreceiptkey_key_doc").ToString, 32)
    '                objReceiptDetail.EXTERNLINENO = Left(registro.Item("externlineno_orden_linea").ToString, 20)
    '                objReceiptDetail.SKU = Left(registro.Item("sku_referencia").ToString, 50)
    '                objReceiptDetail.QTYEXPECTED = Left(registro.Item("qtyexpected_cant").ToString, 50)
    '                objReceiptDetail.UOM = Left(registro.Item("uom_und_wms").ToString, 10)
    '                objReceiptDetail.SUSR1 = Left(registro.Item("d_susr1_rowid_det").ToString, 30)
    '                objReceiptDetail.SUSR2 = Left(registro.Item("d_susr2_rowid_bod_sal").ToString, 30)
    '                objReceiptDetail.SUSR3 = Left(registro.Item("d_susr3_rowid_bod_ent").ToString, 30)
    '                objReceiptDetail.SUSR5 = Left(registro.Item("d_susr5_motivo").ToString, 30)
    '                objReceiptDetail.WHSEID = Left(registro.Item("whseid_co_docto").ToString, 30)

    '                sp_WMS_ION_DOWNLOAD_INT_RECEIPTDETAIL(objReceiptDetail)

    '            Catch ex As Exception
    '                ' ' sp_registrarLog_Download_WMS(2, 1, "PDC", objReceiptDetail.EXTERNRECEIPTKEY, "Migrando Datos Detalle : ", "Fin", "Error", "Referencia : " & objReceiptDetail.SKU & " --- Cantidad : " & objReceiptDetail.QTYEXPECTED & " - " & ex.Message)
    '            End Try

    '        Next

    '        '===============================================================================================

    '        '===============================================================================================
    '        'Encabezado
    '        For Each registro As DataRow In dt.Rows

    '            Dim objReceipt As New clsModelo_Receipt

    '            Try

    '                objReceipt.STORERKEY = Left(registro.Item("storerkey_id_cia").ToString, 15)
    '                objReceipt.EXTERNRECEIPTKEY = Left(registro.Item("externreceiptkey_key_doc").ToString, 32)
    '                objReceipt.TYPE = Left(registro.Item("type_tip_doc").ToString, 10)
    '                objReceipt.NOTES = Left(Replace(Replace(registro.Item("notes_notas").ToString, Chr(10), ""), Chr(13), ""), 60)
    '                objReceipt.SUSR1 = Left(registro.Item("susr1_rowid_encab").ToString, 30)
    '                objReceipt.SUSR2 = Left(registro.Item("susr2_co_doc_org").ToString, 30)
    '                objReceipt.SUSR3 = Left(registro.Item("susr3_consec_doc").ToString, 30)
    '                objReceipt.WHSEID = Left(registro.Item("whseid_co_docto").ToString, 30)
    '                objReceipt.SUPPLIERCODE = CDate(registro.Item("suppliercode_cod_clil").ToString)

    '                sp_WMS_ION_DOWNLOAD_INT_RECEIPT(objReceipt)

    '            Catch ex As Exception
    '                ' ' sp_registrarLog_Download_WMS(2, 1, "PDC", objReceipt.EXTERNRECEIPTKEY, "Migrando Datos Encabezado : ", "Fin", "Error", "Referencia : " & objReceipt.EXTERNRECEIPTKEY & ex.Message)
    '            End Try

    '            'Solo se ejecuta una vez
    '            Exit For

    '        Next
    '        '===============================================================================================

    '    Catch ex As Exception
    '        Dim resultado As String = ex.Message
    '    End Try

    'End Sub





    'Public Sub enviar_SKU_ION(ByRef ds As DataSet)

    '    If ds.Tables.Count > 0 Then
    '        If ds.Tables(0).Rows.Count > 0 Then

    '            For Each registro As DataRow In ds.Tables(0).Rows

    '                Dim objDatos As New clsModelo_SKU

    '                Try

    '                    Dim strSKU As String = Left(registro.Item("sku_referencia").ToString, 15)

    '                    objDatos.SKU = strSKU
    '                    objDatos.BUSR1 = Left(registro.Item("busr1_linprov").ToString, 15)
    '                    objDatos.BUSR2 = Left(registro.Item("busr2_grup").ToString, 15)
    '                    objDatos.BUSR3 = Left(registro.Item("busr3_cat").ToString, 15)
    '                    objDatos.BUSR4 = Left(registro.Item("busr4_tipo").ToString, 15)
    '                    objDatos.BUSR5 = Left(registro.Item("busr5_marca").ToString, 15)
    '                    objDatos.STORERKEY = Left(registro.Item("storerkey_cia").ToString, 15)
    '                    objDatos.DESCR = Left(registro.Item("descr_des").ToString, 15)
    '                    objDatos.PACKKEY = Left(registro.Item("packkey_pack").ToString, 15)
    '                    objDatos.STDCUBE = Left(registro.Item("stdcube_vol_individual").ToString, 15)
    '                    objDatos.STDGROSSWGT = Left(registro.Item("stdgrosswgt_peso_individual").ToString, 15)
    '                    objDatos.STDNETWGT = Left(registro.Item("stdnetwgt_peso_individual").ToString, 15)
    '                    objDatos.TARE = Left(registro.Item("tare_peso_tara").ToString, 15)
    '                    objDatos.SHELFLIFEINDICATOR = Left(registro.Item("shelflifeindicator_val_vidutil").ToString, 15)
    '                    objDatos.SHELFLIFEONRECEIVING = Left(registro.Item("shelflifeonreceiving_vutilent").ToString, 15)
    '                    objDatos.SHELFLIFE = Left(registro.Item("shelflife_vutilent").ToString, 15)
    '                    objDatos.SHELFLIFECODETYPE = Left(registro.Item("shelflifecodetype_valfechvence").ToString, 15)

    '                    sp_WMS_ION_Limpiar_SKU(strSKU)
    '                    sp_WMS_ION_DOWNLOAD_INT_SKU(objDatos)

    '                Catch ex As Exception
    '                    ' ' sp_registrarLog_Download_WMS(,,, objDatos.SKU, "Migrando SKU : ", "Fin", "Error", ex.Message)
    '                End Try

    '            Next

    '            System.Threading.Thread.Sleep(10000)

    '        End If
    '    End If

    'End Sub


    'Public Sub enviar_STORER_ION(ByRef ds As DataSet)

    '    If ds.Tables.Count > 0 Then
    '        If ds.Tables(0).Rows.Count > 0 Then

    '            For Each registro As DataRow In ds.Tables(0).Rows

    '                Dim objDatos As New clsModelo_Storers

    '                Try

    '                    Dim strStorerKey As String = Left(registro.Item("storerkey_key_client").ToString, 15)

    '                    objDatos.STORERKEY = strStorerKey
    '                    objDatos.TYPE = Left(registro.Item("type_tipo_client").ToString, 30)
    '                    objDatos.COMPANY = Left(registro.Item("company_des_client").ToString, 45)
    '                    objDatos.ADDRESS1 = Left(Replace(Replace(registro.Item("address1_dir1").ToString, Chr(10), ""), Chr(13), ""), 45)
    '                    objDatos.ADDRESS5 = Left(registro.Item("address5_nit").ToString, 45)
    '                    objDatos.ADDRESS6 = Left(registro.Item("address6_id_suc").ToString, 45)
    '                    objDatos.ADDRESS2 = Left(Replace(Replace(registro.Item("address2_barrio").ToString, Chr(10), ""), Chr(13), ""), 14)
    '                    objDatos.CITY = Left(registro.Item("city_ciudad").ToString, 45)
    '                    objDatos.STATE = Left(registro.Item("state_depto").ToString, 45)
    '                    objDatos.COUNTRY = Left(registro.Item("country_pais").ToString, 30)
    '                    objDatos.CONTACT1 = Left(Replace(Replace(registro.Item("contact1_contacto").ToString, Chr(10), ""), Chr(13), ""), 30)
    '                    objDatos.PHONE1 = Left(Replace(Replace(registro.Item("phone1_tel1").ToString, Chr(10), ""), Chr(13), ""), 18)
    '                    objDatos.PHONE2 = Left(Replace(Replace(registro.Item("phone2_cel1").ToString, Chr(10), ""), Chr(13), ""), 18)
    '                    objDatos.EMAIL1 = Left(Replace(Replace(registro.Item("email1_mail1").ToString, Chr(10), ""), Chr(13), ""), 50)
    '                    objDatos.SUSR1 = Left(registro.Item("susr1_canal").ToString, 30)
    '                    objDatos.SUSR2 = Left(registro.Item("susr2_zona_logist").ToString, 30)
    '                    objDatos.SUSR3 = Left(registro.Item("susr3_vend_act").ToString, 30)
    '                    objDatos.SUSR4 = Left(registro.Item("susr4_subcanal").ToString, 30)
    '                    objDatos.SUSR5 = Left(registro.Item("susr5_segmento").ToString, 30)
    '                    objDatos.SUSR6 = Left(registro.Item("susr6_subsegmento").ToString, 30)

    '                    sp_WMS_ION_Limpiar_STORERS(strStorerKey)
    '                    sp_WMS_ION_DOWNLOAD_INT_STORER(objDatos)

    '                Catch ex As Exception
    '                    ' ' sp_registrarLog_Download_WMS(,,, objDatos.STORERKEY, "Migrando STORER : ", "Fin", "Error", ex.Message)
    '                End Try

    '            Next

    '            System.Threading.Thread.Sleep(10000)

    '        End If
    '    End If

    'End Sub





End Class
