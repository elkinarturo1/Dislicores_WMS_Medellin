Imports System.Data
Imports Microsoft.VisualBasic

Public Class Proceso_Upload_OCP_ECP

    Dim objSQL As New Upload_OCP_ECP_SQL

    Public Sub ejecutarProceso(ByRef bitError As Boolean, ByRef resultado As String, ByVal cia As String, ByVal co As String, ByVal tipoDoc As String, ByVal numDoc As String)

        Dim paquete As String = ""
        Dim strXML As String = ""
        Dim dsDatosSQL As New DataSet
        Dim dsDatosGT As New DataSet
        Dim strXML_GT As String = ""
        Dim plano As String = ""

        '//////////////////////////////////////////////////////////////////////////////////////////////////
        'Paso 1 - Capturando Datos a enviar
        If bitError = False Then
            Try
                paquete = cia.Trim & "-" & co.Trim & "-" & tipoDoc.Trim & "-" & numDoc.Trim
                dsDatosSQL = objSQL.sp_WMS_UPLOAD_Entrada_ECP_desde_OCP_Detalle_ws_Blazor(bitError, resultado, paquete)
            Catch ex As Exception
                bitError = True
                resultado = "Error Paso 1 Capturando datos a enviar : " & ex.Message
            End Try
        End If
        '////////////////////////////////////////////////////////////////////////////////////////////////// 


        '//////////////////////////////////////////////////////////////////////////////////////////////////
        'Paso 2 - Armando XML
        If Not bitError Then
            If dsDatosSQL.Tables.Count > 0 Then
                If dsDatosSQL.Tables(0).Rows.Count Then
                    Try
                        strXML_GT &= "<MyDataSet>"

                        strXML_GT &= "<Inicial>"
                        strXML_GT &= "<F_CIA>" & cia & "</F_CIA>"
                        strXML_GT &= "</Inicial>"


                        For Each registro As DataRow In dsDatosSQL.Tables(0).Rows

                            'Dim arregloFecha As Array = registro.Item("f350_fecha").ToString.Split("/")
                            'Dim fechaDoc As String = arregloFecha(2).ToString.Substring(0, 4) & Left(arregloFecha(1).ToString, 2) & Left(arregloFecha(0).ToString, 2)

                            Dim fechaDoc As String = Now.Date.ToString("yyyyMMdd")

                            strXML_GT &= "<Documentos>"
                            strXML_GT &= "<F_CIA>" & registro.Item("f420_id_cia").ToString & "</F_CIA>"
                            strXML_GT &= "<f350_id_co>" & registro.Item("f420_id_co").ToString & "</f350_id_co>"
                            strXML_GT &= "<f350_id_tipo_docto>" & registro.Item("f420_id_tipo_docto").ToString & "</f350_id_tipo_docto>"
                            strXML_GT &= "<f350_consec_docto>" & registro.Item("f420_consec_docto").ToString & "</f350_consec_docto>"
                            strXML_GT &= "<f350_fecha>" & fechaDoc & "</f350_fecha>"
                            strXML_GT &= "<f350_id_tercero>" & registro.Item("f350_id_tercero").ToString & "</f350_id_tercero>"
                            strXML_GT &= "<f350_notas>" & registro.Item("f350_notas").ToString & "</f350_notas>"
                            strXML_GT &= "<f451_id_sucursal_prov>" & registro.Item("f451_id_sucursal_prov").ToString & "</f451_id_sucursal_prov>"
                            strXML_GT &= "<f451_id_tercero_comprador>" & registro.Item("f451_id_tercero_comprador").ToString & "</f451_id_tercero_comprador>"
                            strXML_GT &= "<f451_num_docto_referencia>" & registro.Item("f451_num_docto_referencia").ToString & "</f451_num_docto_referencia>"
                            strXML_GT &= "<f451_id_moneda_docto>" & registro.Item("f451_id_moneda_docto").ToString & "</f451_id_moneda_docto>"
                            strXML_GT &= "<f451_id_moneda_conv>" & registro.Item("f451_id_moneda_conv").ToString & "</f451_id_moneda_conv>"
                            strXML_GT &= "<f451_tasa_conv>" & CInt(registro.Item("f451_tasa_conv").ToString) & "</f451_tasa_conv>"
                            strXML_GT &= "<f451_tasa_local>" & CInt(registro.Item("f451_tasa_local").ToString) & "</f451_tasa_local>"
                            strXML_GT &= "<f420_id_co_docto>" & co & "</f420_id_co_docto>"
                            strXML_GT &= "<f420_id_tipo_docto>" & tipoDoc & "</f420_id_tipo_docto>"
                            strXML_GT &= "<f420_consec_docto>" & numDoc & "</f420_consec_docto>"
                            strXML_GT &= "</Documentos>"
                        Next


                        For Each registro As DataRow In dsDatosSQL.Tables(1).Rows

                            'Dim arregloFecha As Array = registro.Item("f421_fecha_entrega").ToString.Split("/")
                            'Dim fechaEntrega As String = arregloFecha(2).ToString.Substring(0, 4) & Left(arregloFecha(1).ToString, 2) & Left(arregloFecha(0).ToString, 2)


                            strXML_GT &= "<Movimientos>"
                            strXML_GT &= "<F_CIA>" & registro.Item("f420_id_cia").ToString & "</F_CIA>"
                            strXML_GT &= "<f470_id_co>" & registro.Item("f420_id_co").ToString & "</f470_id_co>"
                            strXML_GT &= "<f470_id_tipo_docto>" & registro.Item("f420_id_tipo_docto").ToString & "</f470_id_tipo_docto>"
                            strXML_GT &= "<f470_consec_docto>" & registro.Item("f420_consec_docto").ToString & "</f470_consec_docto>"
                            strXML_GT &= "<NumRegistro>" & registro.Item("NumRegistro").ToString & "</NumRegistro>"
                            strXML_GT &= "<f470_id_bodega>" & registro.Item("f470_id_bodega").ToString & "</f470_id_bodega>"
                            strXML_GT &= "<f470_id_unidad_medida>" & registro.Item("f470_id_unidad_medida").ToString & "</f470_id_unidad_medida>"
                            strXML_GT &= "<f421_fecha_entrega>" & registro.Item("f421_fecha_entrega").ToString & "</f421_fecha_entrega>"
                            strXML_GT &= "<f470_cant_base>" & CInt(registro.Item("cantidad").ToString) & "</f470_cant_base>"
                            strXML_GT &= "<f470_referencia_item>" & registro.Item("f470_referencia_item").ToString & "</f470_referencia_item>"
                            strXML_GT &= "<f470_id_ccosto_movto></f470_id_ccosto_movto>"
                            strXML_GT &= "</Movimientos>"
                        Next


                        For Each registro As DataRow In dsDatosSQL.Tables(2).Rows
                            If CInt(registro.Item("f471_tasa").ToString) > 0 Then
                                strXML_GT &= "<Descuentos>"
                                strXML_GT &= "<F_CIA>" & registro.Item("f420_id_cia").ToString & "</F_CIA>"
                                strXML_GT &= "<f471_id_co>" & registro.Item("f420_id_co").ToString & "</f471_id_co>"
                                strXML_GT &= "<f471_id_tipo_docto>" & registro.Item("f420_id_tipo_docto").ToString & "</f471_id_tipo_docto>"
                                strXML_GT &= "<f471_consec_docto>" & registro.Item("f420_consec_docto").ToString & "</f471_consec_docto>"
                                strXML_GT &= "<NumRegistro>" & registro.Item("NumRegistro").ToString & "</NumRegistro>"
                                strXML_GT &= "<f471_orden>" & "1" & "</f471_orden>"
                                strXML_GT &= "<f471_tasa>" & registro.Item("f471_tasa").ToString & "</f471_tasa>"
                                strXML_GT &= "<f471_vlr_tot>" & CInt(registro.Item("f471_vlr_tot").ToString) & "</f471_vlr_tot>"
                                strXML_GT &= "</Descuentos>"
                            End If
                        Next

                        strXML_GT &= "<Final>"
                        strXML_GT &= "<F_CIA>" & cia & "</F_CIA>"
                        strXML_GT &= "</Final>"

                        strXML_GT &= "</MyDataSet>"

                    Catch ex As Exception
                        bitError = True
                        resultado = "Error Paso 2 Capturando Armando XML" & ex.Message
                    End Try
                Else
                    bitError = True
                    resultado = "Error Paso 2 Capturando Armando XML No hay datos en la consulta para enviar"
                End If
            Else
                bitError = True
                resultado = "Error Paso 2 Capturando Armando XML No hay tablas en la consulta para enviar"
            End If
        End If
        '//////////////////////////////////////////////////////////////////////////////////////////////////


        '//////////////////////////////////////////////////////////////////////////////////////////////////
        'Paso 3 - Convirtiendo a DataSet
        If Not bitError Then
            dsDatosGT = convertirXML_to_DataSet(bitError, resultado, strXML_GT)
        End If
        '//////////////////////////////////////////////////////////////////////////////////////////////////


        '//////////////////////////////////////////////////////////////////////////////////////////////////
        'Paso 4 - Consumiendo GT
        If bitError = False Then
            plano = ModuloConsumosGT.ConsumoGT(bitError, resultado, 77709, "WMS_ENTRADA_DESDE_OC_ECP", cia, dsDatosGT)
        End If
        '//////////////////////////////////////////////////////////////////////////////////////////////////


        '//////////////////////////////////////////////////////////////////////////////////////////////////
        'Paso 5 - Convirtiendo a DataSet
        If bitError = False Then
            Try
                ModuloConsumoUNOEE.CargasWSUNOEE(bitError, resultado, cia, plano)
            Catch ex As Exception
                Throw ex
            End Try
        End If
        '//////////////////////////////////////////////////////////////////////////////////////////////////

    End Sub


End Class
